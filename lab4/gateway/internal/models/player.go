package models

type PlayerType int

const (
	CenterType     PlayerType = 1
	PointGuardType PlayerType = 0
)

type Player struct {
	ID           int         `json:"id"`
	Name         string      `json:"name"`
	Height       int         `json:"height"`
	JerseyNumber int         `json:"jersey_number"`
	Type         int         `json:"type"`
	TeamID       int         `json:"team_id"`
	GamesPlayed  int         `json:"games_played"`
	Center       *Center     `json:"center,omitempty"`
	PointGuard   *PointGuard `json:"point_guard,omitempty"`
}
