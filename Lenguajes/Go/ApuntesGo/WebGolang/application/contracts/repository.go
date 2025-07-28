package contracts

import "WebGolang/application/models"

type IRepository interface {
	GetById(id int) (models.WeatherForecastDto, error)
}
