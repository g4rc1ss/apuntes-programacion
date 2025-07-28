package repositories

import (
	"WebGolang/application/models"
)

type WeatherForecast struct{}

func (w WeatherForecast) GetById(id int) (models.WeatherForecastDto, error) {
	return models.WeatherForecastDto{
		id,
		10,
	}, nil
}
