package uses_cases

import (
	"WebGolang/application/contracts"
	"WebGolang/application/models"
)

type WeatherForecastUseCases struct {
	WeatherRepository contracts.IRepository
}

func (weatherUseCase *WeatherForecastUseCases) Execute(id int) models.WeatherForecastDto {
	dto, error := weatherUseCase.WeatherRepository.GetById(id)
	if error != nil {
		panic(error)
	}
	return dto
}
