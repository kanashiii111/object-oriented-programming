package proxy

import (
	"bytes"
	"encoding/json"
	"fmt"
	"gateway/internal/handlers"
	"gateway/internal/models"
	"gateway/internal/services"
	"io"
	"net/http"
	"net/http/httputil"
	"net/url"
	"strings"
)

func HandlePlayers(w http.ResponseWriter, r *http.Request) bool {
	body, err := io.ReadAll(r.Body)
	if err != nil {
		http.Error(w, "Ошибка чтения", http.StatusBadRequest)
		return false
	}

	var player models.Player
	if err := json.Unmarshal(body, &player); err != nil {
		w.Header().Set("Content-Type", "application/json")
		w.WriteHeader(http.StatusBadRequest)
		json.NewEncoder(w).Encode(map[string]string{"message": "Некорректный JSON"})
		return false
	}

	if errorMap := services.ValidatePlayer(&player); errorMap != nil {
		w.Header().Set("Content-Type", "application/json")
		w.WriteHeader(http.StatusBadRequest)
		json.NewEncoder(w).Encode(errorMap)
		return false
	}

	r.Body = io.NopCloser(bytes.NewBuffer(body))
	r.ContentLength = int64(len(body))
	return true
}

func HandleTeams(w http.ResponseWriter, r *http.Request) bool {
	body, err := io.ReadAll(r.Body)
	if err != nil {
		http.Error(w, "Ошибка чтения", http.StatusBadRequest)
		return false
	}

	var team models.Team
	if err := json.Unmarshal(body, &team); err != nil {
		http.Error(w, "Некорректный формат JSON", http.StatusBadRequest)
		return false
	}

	if errorMap := services.ValidateTeam(&team); errorMap != nil {
		w.Header().Set("Content-Type", "application/json")
		w.WriteHeader(http.StatusBadRequest)
		json.NewEncoder(w).Encode(errorMap)
		return false
	}

	r.Body = io.NopCloser(bytes.NewBuffer(body))
	r.ContentLength = int64(len(body))
	return true
}

func NewProxy(target *url.URL) *httputil.ReverseProxy {
	return httputil.NewSingleHostReverseProxy(target)
}

func ProxyHandler(proxy *httputil.ReverseProxy, url *url.URL, endpoint string) func(http.ResponseWriter, *http.Request) {
	return func(w http.ResponseWriter, r *http.Request) {
		fmt.Printf("[ PROXY SERVER ] Request received at %s\n", r.URL)
		r.URL.Host = url.Host
		r.URL.Scheme = url.Scheme
		r.Host = url.Host

		if r.Method == http.MethodPost || r.Method == http.MethodPut {
			if r.URL.Path == "/api/teams" {
				if isOk := HandleTeams(w, r); !isOk {
					fmt.Printf("[ PROXY SERVER ] Request forwarded to [%s %s] has been rejected: [TEAM VALIDATION FAILED]\n", r.Method, r.URL)
					return
				}
				handlers.TeamCache.ForceCleanup()
				fmt.Println("[ CACHE ] Invalidating TeamCache due to POST/PUT mutation")
			} else {
				if isOk := HandlePlayers(w, r); !isOk {
					fmt.Printf("[ PROXY SERVER ] Request forwarded to [%s %s] has been rejected: [PLAYER VALIDATION FAILED]\n", r.Method, r.URL)
					return
				}
				handlers.PlayerCache.ForceCleanup()
				fmt.Println("[ CACHE ] Invalidating PlayerCache due to POST/PUT mutation")
			}
		}
		if r.Method == http.MethodDelete {
			if strings.Contains(r.URL.Path, "/api/teams") {
				handlers.TeamCache.ForceCleanup()
				// handlers.PlayerCache.ForceCleanup()
				fmt.Println("[ CACHE ] Invalidating TeamCache due to DELETE mutation")
			} else {
				handlers.PlayerCache.ForceCleanup()
				fmt.Println("[ CACHE ] Invalidating PlayerCache due to DELETE mutation")
			}
		}

		path := r.URL.Path
		r.URL.Path = strings.TrimPrefix(path, "/api")

		fmt.Printf("[ PROXY SERVER ] Forwarding request to [%s %s]\n", r.Method, r.URL)

		proxy.ServeHTTP(w, r)
	}
}
