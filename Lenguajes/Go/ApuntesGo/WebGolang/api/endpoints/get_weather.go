package endpoints

import (
	"WebGolang/application/contracts"
	uses_cases "WebGolang/application/uses-cases"
	"WebGolang/infraestructure/repositories"
	"net/http"
	"strconv"

	"github.com/gin-gonic/gin"
)

func GetWeather(c *gin.Context) {
	id, err := strconv.Atoi(c.Param("id"))
	if err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": "Invalid ID"})
		return
	}

	var repository contracts.IRepository = repositories.WeatherForecast{}

	weatherUseCase := uses_cases.WeatherForecastUseCases{
		WeatherRepository: repository,
	}

	dto := weatherUseCase.Execute(id)

	c.JSON(http.StatusOK, dto)
}
