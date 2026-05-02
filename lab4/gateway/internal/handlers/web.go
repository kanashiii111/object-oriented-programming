package handlers

import (
	"encoding/json"
	"fmt"
	"gateway/internal/cache"
	"gateway/internal/models"
	"gateway/internal/services"
	"net/http"
	"sort"
	"text/template"
	"time"
)

var (
	playerCache *cache.Cache
)

func HandleHomepage(w http.ResponseWriter, r *http.Request) {
	if playerCache != nil {
		cachedPlayers := playerCache.GetAll()
		var players []models.Player
		for _, item := range cachedPlayers {
			if player, ok := item.(models.Player); ok {
				players = append(players, player)
			}
		}
		if len(players) > 0 {
			fmt.Println("Serving players from cache")
			sort.Slice(players, func(i, j int) bool {
				return players[i].ID < players[j].ID
			})
			tmpl := template.Must(template.ParseFiles("web/templates/homepage.html"))
			tmpl.Execute(w, players)
			return
		}
	} else {
		playerCache = cache.NewCache(5*time.Minute, 10*time.Minute)
	}
	responce, err := http.Get("http://localhost:8080/api/players")
	if err != nil {
		http.Error(w, "Error fetching players", http.StatusInternalServerError)
		return
	}
	defer responce.Body.Close()

	var players []models.Player
	json.NewDecoder(responce.Body).Decode(&players)

	for i := range players {
		services.CalculatePlayerStats(&players[i])
		playerCache.Set(fmt.Sprintf("player_%d", players[i].ID), players[i], 5*time.Minute)
	}

	tmpl := template.Must(template.ParseFiles("web/templates/homepage.html"))
	tmpl.Execute(w, players)
}

func HandleCreatePlayerPage(w http.ResponseWriter, r *http.Request) {
	tmpl := template.Must(template.ParseFiles("web/templates/create_player.html"))
	tmpl.Execute(w, nil)
	fmt.Println("Create player page served")
}

func HandleCreateTeamPage(w http.ResponseWriter, r *http.Request) {
	tmpl := template.Must(template.ParseFiles("web/templates/create_team.html"))
	tmpl.Execute(w, nil)
	fmt.Println("Create team page served")
}

func HandleEditPlayerPage(w http.ResponseWriter, r *http.Request) {
	tmpl := template.Must(template.ParseFiles("web/templates/edit_player.html"))
	tmpl.Execute(w, nil)
	fmt.Println("Edit player page served")
}

func HandleEditTeamPage(w http.ResponseWriter, r *http.Request) {
	tmpl := template.Must(template.ParseFiles("web/templates/edit_team.html"))
	tmpl.Execute(w, nil)
	fmt.Println("Edit team page served")
}

func HandlePlayerMethodsPage(w http.ResponseWriter, r *http.Request) {
	tmpl := template.Must(template.ParseFiles("web/templates/player_methods.html"))
	tmpl.Execute(w, nil)
	fmt.Println("Player methods page served")
}
