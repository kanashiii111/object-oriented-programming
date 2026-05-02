package models

type Center struct {
	ID              int     `json:"id"`
	Blocks          int     `json:"blocks"`
	Rebounds        int     `json:"rebounds"`
	BlocksPerGame   float64 `json:"blocks_per_game"`
	ReboundsPerGame float64 `json:"rebounds_per_game"`
}
