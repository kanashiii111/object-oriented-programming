package handlers

import (
	"encoding/json"
	"fmt"
	"gateway/internal/cache"
	"gateway/internal/models"
	"gateway/internal/services"
	"net/http"
	"sort"
	"sync"
	"text/template"
	"time"

	"github.com/gorilla/mux"
)

type Data struct {
	Players []models.Player
	Teams   []models.Team
}

var (
	PlayerCache = cache.NewCache(5*time.Minute, 10*time.Second)
	TeamCache   = cache.NewCache(5*time.Minute, 10*time.Second)
	tmpl        = template.Must(template.ParseFiles("web/templates/homepage.html"))
)

func getPlayersFromCache() []models.Player {
	var players []models.Player
	for _, item := range PlayerCache.GetAll() {
		if p, ok := item.(models.Player); ok {
			players = append(players, p)
		}
	}
	return players
}

func fetchAndCachePlayers() []models.Player {
	resp, err := http.Get("http://localhost:8080/api/players")
	if err != nil {
		fmt.Printf("Error fetching players: %v\n", err)
		return nil
	}
	defer resp.Body.Close()

	var players []models.Player
	if err := json.NewDecoder(resp.Body).Decode(&players); err != nil {
		return nil
	}

	for i := range players {
		services.CalculatePlayerStats(&players[i])
		PlayerCache.Set(fmt.Sprintf("player_%d", players[i].ID), players[i], 5*time.Minute)
	}
	return players
}

func getTeamsFromCache() []models.Team {
	var teams []models.Team
	for _, item := range TeamCache.GetAll() {
		if t, ok := item.(models.Team); ok {
			teams = append(teams, t)
		}
	}
	return teams
}

func fetchAndCacheTeams() []models.Team {
	resp, err := http.Get("http://localhost:8080/api/teams")
	if err != nil {
		fmt.Printf("Error fetching teams: %v\n", err)
		return nil
	}
	defer resp.Body.Close()

	var teams []models.Team
	if err := json.NewDecoder(resp.Body).Decode(&teams); err != nil {
		return nil
	}

	for i := range teams {
		TeamCache.Set(fmt.Sprintf("team_%d", teams[i].ID), teams[i], 5*time.Minute)
	}
	return teams
}

func HandleHomepage(w http.ResponseWriter, r *http.Request) {
	players := getPlayersFromCache()
	teams := getTeamsFromCache()

	var wg sync.WaitGroup

	if len(players) == 0 {
		wg.Add(1)
		go func() {
			defer wg.Done()
			players = fetchAndCachePlayers()
			fmt.Println("[ PROXY SERVER ] Done loading players from api call")
		}()
	} else {
		fmt.Println("[ CACHE ] Players loaded from cache")
	}
	if len(teams) == 0 {
		wg.Add(1)
		go func() {
			defer wg.Done()
			teams = fetchAndCacheTeams()
			fmt.Println("[ PROXY SERVER ] Done loading teams from api call")
		}()
	} else {
		fmt.Println("[ CACHE ] Teams loaded from cache")
	}
	wg.Wait()

	sort.Slice(players, func(i, j int) bool { return players[i].ID < players[j].ID })
	sort.Slice(teams, func(i, j int) bool { return teams[i].ID < teams[j].ID })

	data := Data{Players: players, Teams: teams}
	if err := tmpl.Execute(w, data); err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
	}
}

func HandleCreatePlayerPage(w http.ResponseWriter, r *http.Request) {
	responce, err := http.Get("http://localhost:8080/api/teams")
	if err != nil {
		http.Error(w, "Error fetching teams", http.StatusInternalServerError)
		return
	}
	defer responce.Body.Close()

	var teams []models.Team
	json.NewDecoder(responce.Body).Decode(&teams)

	tmpl := template.Must(template.ParseFiles("web/templates/create_player.html"))
	tmpl.Execute(w, teams)
}

func HandleCreateTeamPage(w http.ResponseWriter, r *http.Request) {
	tmpl := template.Must(template.ParseFiles("web/templates/create_team.html"))
	tmpl.Execute(w, nil)
}

func HandleEditPlayerPage(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)
	player_id := vars["id"]
	responce, err := http.Get("http://localhost:8080/api/players/" + player_id)
	if err != nil {
		http.Error(w, "Error fetching player", http.StatusInternalServerError)
		return
	}
	defer responce.Body.Close()

	var player models.Player
	json.NewDecoder(responce.Body).Decode(&player)

	responce, err = http.Get("http://localhost:8080/api/teams")
	if err != nil {
		http.Error(w, "Error fetching teams", http.StatusInternalServerError)
		return
	}
	defer responce.Body.Close()

	var teams []models.Team
	json.NewDecoder(responce.Body).Decode(&teams)

	tmpl := template.Must(template.ParseFiles("web/templates/edit_player.html"))
	tmpl.Execute(w, map[string]interface{}{
		"Player": player,
		"Teams":  teams,
	})
}

func HandleEditTeamPage(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)
	team_id := vars["id"]
	responce, err := http.Get("http://localhost:8080/api/teams/" + team_id)
	if err != nil {
		http.Error(w, "Error fetching player", http.StatusInternalServerError)
		return
	}
	defer responce.Body.Close()

	var team models.Team
	json.NewDecoder(responce.Body).Decode(&team)
	tmpl := template.Must(template.ParseFiles("web/templates/edit_team.html"))
	tmpl.Execute(w, team)
}

func HandlePlayerMethodsPage(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)
	player_id := vars["id"]
	responce, err := http.Get("http://localhost:8080/api/players/" + player_id)
	if err != nil {
		http.Error(w, "Error fetching player", http.StatusInternalServerError)
		return
	}
	defer responce.Body.Close()

	var player models.Player
	json.NewDecoder(responce.Body).Decode(&player)
	tmpl := template.Must(template.ParseFiles("web/templates/player_methods.html"))
	tmpl.Execute(w, player)
}
