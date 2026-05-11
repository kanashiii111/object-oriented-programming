package services

import (
	"gateway/internal/models"
)

func ValidateCenter(center *models.Center) map[string]any {
	var errorMap map[string]any = nil

	addError := func(key string, value any) {
		if errorMap == nil {
			errorMap = make(map[string]any)
		}
		errorMap[key] = value
	}

	// if center.Blocks == nil && center.Rebounds == nil {
	// 	addError("blocks", "Одно из полей блоки/подборы обязательно")
	// 	addError("rebounds", "Одно из полей блоки/подборы обязательно")
	// 	return errorMap
	// }

	if center.Blocks != nil && center.Rebounds == nil {
		if *center.Blocks < 0 {
			addError("blocks", "Количество блоков не может быть отрицательным")
		}
	} else if center.Blocks == nil && center.Rebounds != nil {
		if *center.Rebounds < 0 {
			addError("rebounds", "Количество подборов не может быть отрицательным")
		}
	} else if center.Blocks != nil && center.Rebounds != nil {
		if *center.Blocks < 0 {
			addError("blocks", "Количество блоков не может быть отрицательным")
		}
		if *center.Rebounds < 0 {
			addError("rebounds", "Количество подборов не может быть отрицательным")
		}
	}

	return errorMap
}

func CalculateCenterStats(center *models.Center, gamesPlayed int) {
	if gamesPlayed > 0 && center.Blocks != nil && center.Rebounds != nil {
		center.BlocksPerGame = float64(*center.Blocks) / float64(gamesPlayed)
		center.ReboundsPerGame = float64(*center.Rebounds) / float64(gamesPlayed)
	} else {
		center.BlocksPerGame = 0
		center.ReboundsPerGame = 0
	}
}
