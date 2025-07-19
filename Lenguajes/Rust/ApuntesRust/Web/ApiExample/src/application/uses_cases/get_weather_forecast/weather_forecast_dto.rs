pub struct WeatherForecastDto {
    pub temperature: i32,
}

impl WeatherForecastDto {
    pub fn new(temp: i32) -> WeatherForecastDto {
       WeatherForecastDto { temperature: temp }
    }
}
