package server

import (
	"fmt"
	"gateway/internal/handlers"
	prx "gateway/internal/proxy"
	"gateway/internal/proxy/config"
	"net/http"
	"net/url"

	"github.com/gorilla/mux"
)

func Run() error {
	cfg, err := config.NewConfig()
	if err != nil {
		panic(err)
	}

	router := mux.NewRouter()
	staticFileDirectory := http.Dir("./web/static/")
	staticFileHandler := http.StripPrefix("/static/", http.FileServer(staticFileDirectory))
	router.PathPrefix("/static/").Handler(staticFileHandler)

	router.HandleFunc("/", handlers.HandleHomepage).Methods("GET")
	router.HandleFunc("/home", handlers.HandleHomepage).Methods("GET")
	router.HandleFunc("/create/player", handlers.HandleCreatePlayerPage).Methods("GET")
	router.HandleFunc("/create/team", handlers.HandleCreateTeamPage).Methods("GET")
	router.HandleFunc("/edit/player/{id}", handlers.HandleEditPlayerPage).Methods("GET")
	router.HandleFunc("/edit/team/{id}", handlers.HandleEditTeamPage).Methods("GET")
	router.HandleFunc("/methods/player/{id}", handlers.HandlePlayerMethodsPage).Methods("GET")

	for _, resource := range cfg.Resources {
		url, _ := url.Parse(resource.Destination_URL)
		proxy := prx.NewProxy(url)
		router.HandleFunc(resource.Endpoint, prx.ProxyHandler(proxy, url, resource.Endpoint)).Methods(resource.Method)
	}
	fmt.Println("Listening on port 8080...")
	if err := http.ListenAndServe(fmt.Sprintf("%s:%s", cfg.Server.Host, cfg.Server.Port), router); err != nil {
		panic(err)
	}
	return nil
}
