package handlers

import (
	"fmt"
	"net/http"
	"text/template"
)

func HandleHomepage(w http.ResponseWriter, r *http.Request) {
	tmpl := template.Must(template.ParseFiles("web/templates/homepage.html"))
	tmpl.Execute(w, nil)
	fmt.Println("Homepage served")
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
