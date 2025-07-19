use crate::entities::weather_forecast_entity::WeatherForecastEntity;

pub trait WeatherForecastByIdRepository {
    async fn execute(&self, id: i32) -> WeatherForecastEntity;
}

pub struct WeatherForecastByIdRepositoryImpl {}

impl WeatherForecastByIdRepositoryImpl {
    pub fn new() -> Self {
        Self {}
    }
}

impl WeatherForecastByIdRepository for WeatherForecastByIdRepositoryImpl {
    async fn execute(&self, id: i32) -> WeatherForecastEntity {
        WeatherForecastEntity {
            id: 1,
            temperature: 6547890,
        }
    }
}
