package services

import (
	"fmt"
	"gateway/internal/models"
)

func ValidateCenter(center *models.Center) error {
	if center.Blocks < 0 {
		return fmt.Errorf("blocks cannot be negative")
	}
	if center.Rebounds < 0 {
		return fmt.Errorf("rebounds cannot be negative")
	}
	return nil
}

func CalculateCenterStats(center *models.Center, gamesPlayed int) {
	if gamesPlayed > 0 {
		center.BlocksPerGame = float64(center.Blocks) / float64(gamesPlayed)
		center.ReboundsPerGame = float64(center.Rebounds) / float64(gamesPlayed)
	} else {
		center.BlocksPerGame = 0
		center.ReboundsPerGame = 0
	}
}
