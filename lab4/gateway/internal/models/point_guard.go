package models

type PointGuard struct {
	ID                 int     `json:"id"`
	Assists            *int    `json:"assists,omitempty"`
	ThreePointMakes    *int    `json:"three_point_makes,omitempty"`
	AssistsPerGame     float64 `json:"assists_per_game"`
	ThreePointsPerGame float64 `json:"three_points_per_game"`
}
