use crate::application::uses_cases::get_weather_forecast::weather_forecast_dto::WeatherForecastDto;

pub trait WeatherForecastByIdRepository {
    async fn execute(&self, id: i32) -> WeatherForecastDto;
}

pub struct WeatherForecastByIdRepositoryImpl {}

impl WeatherForecastByIdRepositoryImpl {
    pub fn new() -> Self {
        Self {}
    }
}

impl WeatherForecastByIdRepository for WeatherForecastByIdRepositoryImpl {
    async fn execute(&self, id: i32) -> WeatherForecastDto {
        WeatherForecastDto { temperature: 6547890 }
    }
}
