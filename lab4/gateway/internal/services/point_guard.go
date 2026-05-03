package services

import (
	"gateway/internal/models"
)

func ValidatePointGuard(pointGuard *models.PointGuard) map[string]any {
	var errorMap map[string]any = nil

	addError := func(key string, value any) {
		if errorMap == nil {
			errorMap = make(map[string]any)
		}
		errorMap[key] = value
	}

	if pointGuard.Assists < 0 {
		addError("assists", "Количество ассистов не может быть отрицательным")
	}
	if pointGuard.ThreePointMakes < 0 {
		addError("three_point_makes", "Количество трехочковых попаданий не может быть отрицательным")
	}
	return errorMap
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
