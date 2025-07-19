use crate::application::uses_cases::get_weather_forecast::weather_forecast_dto::WeatherForecastDto;
use std::io::Error;

pub trait IGetWeatherForecast {
    async fn execute(&self) -> Result<WeatherForecastDto, Error>;
}

pub struct GetWeatherForecast {}
impl IGetWeatherForecast for GetWeatherForecast {
    async fn execute(&self) -> Result<WeatherForecastDto, Error> {
        Ok(WeatherForecastDto::new(30))
    }
}

impl GetWeatherForecast {
    pub fn new() -> Self {
        Self {}
    }
}
