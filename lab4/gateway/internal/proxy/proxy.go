package proxy

import (
	"fmt"
	"net/http"
	"net/http/httputil"
	"net/url"
	"strings"
	"time"
)

func NewProxy(target *url.URL) *httputil.ReverseProxy {
	return httputil.NewSingleHostReverseProxy(target)
}

func ProxyHandler(proxy *httputil.ReverseProxy, url *url.URL, endpoint string) func(http.ResponseWriter, *http.Request) {
	return func(w http.ResponseWriter, r *http.Request) {
		// fmt.Printf("[ PROXY SERVER ] Request received at %s at %s\n", r.URL, time.Now().UTC())
		// r.URL.Host = url.Host
		// r.URL.Scheme = url.Scheme

		// r.Header.Set("X-Forwarded-Host", r.Header.Get("Host"))
		// r.Host = url.Host

		// path := r.URL.Path
		// r.URL.Path = strings.TrimPrefix(path, "/api")

		// fmt.Printf("[ PROXY SERVER ] Forwarding request to [%s %s at %s]\n", r.Method, r.URL, time.Now().UTC().Add(3*time.Hour))

		// proxy.ServeHTTP(w, r)

		// if r.Method == http.MethodGet {
		// 	// Читаем тело запроса
		// 	body, err := io.ReadAll(r.Body)
		// 	if err == nil {
		// 		var players []models.Player
		// 		if err := json.Unmarshal(body, &players); err == nil {
		// 			for _, player := range players {
		// 				fmt.Printf("Player: %+v\n", player)
		// 				err := services.ValidatePlayer(&player)
		// 				if err != nil {
		// 					fmt.Printf("Error validating player: %v\n", err)
		// 				}
		// 				services.CalculatePlayerStats(&player)
		// 				// Собираем новый JSON с посчитанными данными
		// 				newBody, _ := json.Marshal(players)
		// 				r.Body = io.NopCloser(bytes.NewBuffer(newBody))
		// 				r.ContentLength = int64(len(newBody))
		// 				r.Header.Set("Content-Length", fmt.Sprint(len(newBody)))
		// 			}
		// 		}
		// 	}
		// }

		// if r.Method == http.MethodPost || r.Method == http.MethodPut {

		// 	// Читаем тело запроса
		// 	body, err := io.ReadAll(r.Body)
		// 	if err == nil {
		// 		var player models.Player
		// 		if err := json.Unmarshal(body, &player); err == nil {

		// 			// Вызываем вашу логику!
		// 			services.CalculatePlayerStats(&player)

		// 			// Собираем новый JSON с посчитанными данными
		// 			newBody, _ := json.Marshal(player)

		// 			// Подменяем тело запроса для отправки в Python
		// 			r.Body = io.NopCloser(bytes.NewBuffer(newBody))
		// 			r.ContentLength = int64(len(newBody))
		// 			r.Header.Set("Content-Length", fmt.Sprint(len(newBody)))
		// 		}
		// 	}
		// }

		// // --- 2. ПРОКСИРОВАНИЕ ---
		// path := r.URL.Path
		// r.URL.Path = strings.TrimPrefix(path, "/api")
		// r.URL.Host = url.Host
		// r.URL.Scheme = url.Scheme
		// r.Header.Set("X-Forwarded-Host", r.Header.Get("Host"))
		// r.Host = url.Host

		// fmt.Printf("[ PROXY SERVER ] Forwarding request to [%s %s at %s]\n", r.Method, r.URL, time.Now().UTC().Add(3*time.Hour))

		// proxy.ServeHTTP(w, r)

		fmt.Printf("[ PROXY SERVER ] Request received at %s at %s\n", r.URL, time.Now().UTC())
		r.URL.Host = url.Host
		r.URL.Scheme = url.Scheme

		r.Header.Set("X-Forwarded-Host", r.Header.Get("Host"))
		r.Host = url.Host

		path := r.URL.Path
		r.URL.Path = strings.TrimPrefix(path, "/api")

		fmt.Printf("[ PROXY SERVER ] Forwarding request to [%s %s at %s]\n", r.Method, r.URL, time.Now().UTC().Add(3*time.Hour))

		proxy.ServeHTTP(w, r)
	}
}
