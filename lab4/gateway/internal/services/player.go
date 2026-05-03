package services

import (
	"fmt"
	"gateway/internal/models"
	"strings"

	vgo "github.com/bube054/validatorgo"
)

func ValidatePlayer(player *models.Player) map[string]any {
	var errorMap map[string]any = nil

	addError := func(key string, value any) {
		if errorMap == nil {
			errorMap = make(map[string]any)
		}
		errorMap[key] = value
	}

	if vgo.IsEmpty(player.Name, &vgo.IsEmptyOpts{IgnoreWhitespace: true}) || strings.TrimSpace(player.Name) == "" {
		addError("name", "Имя не должно быть пустым")
	}
	if player.Height < 150 || player.Height > 240 {
		addError("height", "Рост должен быть между 150 и 240 см")
	}
	if player.JerseyNumber < 0 || player.JerseyNumber > 99 {
		addError("jersey_number", "Номер на футболке должен быть между 0 и 99")
	}
	if player.Type != 1 && player.Type != 0 {
		addError("type", "Тип игрока должен быть 0 (point guard), 1 (center)")
	}
	if player.GamesPlayed < 0 {
		addError("games_played", "Количество игр не может быть отрицательным")
	}
	if player.Type == int(models.CenterType) {
		fmt.Println("Validating center stats...")
		errs := ValidateCenter(player.Center)
		if errs != nil {
			addError("blocks", errs["blocks"])
			addError("rebounds", errs["rebounds"])
		}
	} else if player.Type == int(models.PointGuardType) {
		fmt.Println("Validating point guard stats...")
		errs := ValidatePointGuard(player.PointGuard)
		if errs != nil {
			addError("assists", errs["assists"])
			addError("three_point_makes", errs["three_point_makes"])
		}
	}
	return errorMap
}

func CalculatePlayerStats(player *models.Player) {
	if player.Type == int(models.CenterType) && player.Center != nil {
		CalculateCenterStats(player.Center, player.GamesPlayed)
	} else if player.Type == int(models.PointGuardType) && player.PointGuard != nil {
		CalculatePointGuardStats(player.PointGuard, player.GamesPlayed)
	}
}
