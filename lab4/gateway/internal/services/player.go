package services

import (
	"fmt"
	"gateway/internal/models"
)

func ValidatePlayer(player *models.Player) error {
	if player.Name == "" {
		return fmt.Errorf("player name cannot be empty")
	}
	if player.Height < 150 || player.Height > 240 {
		return fmt.Errorf("player height must be between 150 and 240 cm")
	}
	if player.JerseyNumber < 0 || player.JerseyNumber > 99 {
		return fmt.Errorf("jersey number must be between 0 and 99")
	}
	if player.Type != 1 && player.Type != 0 {
		return fmt.Errorf("player type must be 0 (point guard), 1 (center)")
	}
	if player.Type == int(models.CenterType) {
		errs := ValidateCenter(player.Center)
		if errs != nil {
			return errs
		}
	} else if player.Type == int(models.PointGuardType) {
		errs := ValidatePointGuard(player.PointGuard)
		if errs != nil {
			return errs
		}
	}
	return nil
}

func CalculatePlayerStats(player *models.Player) {
	if player.Type == int(models.CenterType) && player.Center != nil {
		CalculateCenterStats(player.Center, player.GamesPlayed)
	} else if player.Type == int(models.PointGuardType) && player.PointGuard != nil {
		CalculatePointGuardStats(player.PointGuard, player.GamesPlayed)
	}
}
