package services

import (
	"gateway/internal/models"
	"strings"

	vgo "github.com/bube054/validatorgo"
)

func ValidateTeam(team *models.Team) map[string]any {
	errorMap := make(map[string]any)
	if vgo.IsEmpty(team.Name, &vgo.IsEmptyOpts{IgnoreWhitespace: true}) || strings.TrimSpace(team.Name) == "" {
		errorMap["name"] = "Название команды не может быть пустым"
		return errorMap
	}
	return nil
}
