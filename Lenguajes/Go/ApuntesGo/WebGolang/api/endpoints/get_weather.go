package endpoints

import (
	"WebGolang/application/contracts"
	uses_cases "WebGolang/application/uses-cases"
	"WebGolang/infraestructure/repositories"
)

func GetWeather() {
	var repository contracts.IRepository = repositories.WeatherForecast{}

	weatherUseCase := uses_cases.WeatherForecastUseCases{
		WeatherRepository: repository,
	}

	dto := weatherUseCase.Execute(1)

	print(dto.Temperature)
}
