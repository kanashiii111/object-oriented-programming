package main

import (
	server "gateway/internal/server"
	"log"
)

func main() {
	if err := server.Run(); err != nil {
		log.Fatalf("Could not start the server: %v", err)
		panic(err)
	}
}

// filters
