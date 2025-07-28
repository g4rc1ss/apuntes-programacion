package main

import (
	"WebGolang/api/endpoints"

	"github.com/gin-gonic/gin"
)

func main() {
	router := gin.Default()

	router.GET("weather-forecast/:id", endpoints.GetWeather)
	router.Run(":8090")
}
