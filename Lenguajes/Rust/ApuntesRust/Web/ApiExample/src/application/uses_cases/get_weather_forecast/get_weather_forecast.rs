use crate::application::uses_cases::get_weather_forecast::weather_forecast_dto::WeatherForecastDto;
use crate::infraestructure::repository::weather_forecast_by_id::weather_by_id_repository::*;
use std::io::Error;

pub trait IGetWeatherForecast {
    async fn execute(&self, id: i32) -> Result<WeatherForecastDto, Error>;
}

pub struct GetWeatherForecast {}
impl IGetWeatherForecast for GetWeatherForecast {
    async fn execute(&self, id: i32) -> Result<WeatherForecastDto, Error> {
        let weather_repo_impl = WeatherForecastByIdRepositoryImpl::new();
        let weather = WeatherForecastByIdRepository::execute(&weather_repo_impl, id).await;

        Ok(weather)
    }
}

impl GetWeatherForecast {
    pub fn new() -> Self {
        Self {}
    }
}
