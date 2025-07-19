use infraestructure::entities::weather_forecast_entity::WeatherForecastEntity;

pub struct WeatherForecastDto {
    pub id: i32,
    pub temperature: i32,
}

impl WeatherForecastDto {
    pub fn new(id: i32, temperature: i32) -> WeatherForecastDto {
        WeatherForecastDto { id, temperature }
    }
}

pub trait WeatherForecastEntityMappers {
    fn to_dto(&self) -> WeatherForecastDto;
}

impl WeatherForecastEntityMappers for WeatherForecastEntity {
    fn to_dto(&self) -> WeatherForecastDto {
        WeatherForecastDto::new(self.id, self.temperature.unwrap())
    }
}
