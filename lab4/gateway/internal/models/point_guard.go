package models

type PointGuard struct {
	ID                 int     `json:"id"`
	Assists            int     `json:"assists"`
	ThreePointMakes    int     `json:"three_point_makes"`
	AssistsPerGame     float64 `json:"assists_per_game"`
	ThreePointsPerGame float64 `json:"three_points_per_game"`
}
