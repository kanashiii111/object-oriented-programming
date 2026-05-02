package services

import (
	"fmt"
	"gateway/internal/models"
)

func ValidatePointGuard(pointGuard *models.PointGuard) error {
	if pointGuard.Assists < 0 {
		return fmt.Errorf("assists cannot be negative")
	}
	if pointGuard.ThreePointMakes < 0 {
		return fmt.Errorf("three-point makes cannot be negative")
	}
	return nil
}

func CalculatePointGuardStats(pointGuard *models.PointGuard, gamesPlayed int) {
	if gamesPlayed > 0 {
		pointGuard.AssistsPerGame = float64(pointGuard.Assists) / float64(gamesPlayed)
		pointGuard.ThreePointsPerGame = (float64(pointGuard.ThreePointMakes) / float64(gamesPlayed))
	} else {
		pointGuard.AssistsPerGame = 0
		pointGuard.ThreePointsPerGame = 0
	}
}
