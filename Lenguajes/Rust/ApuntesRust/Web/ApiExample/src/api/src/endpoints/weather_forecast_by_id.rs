use application::uses_cases::get_weather_forecast::get_weather_forecast::{
    GetWeatherForecast, IGetWeatherForecast,
};
use actix_web::{get, web, HttpResponse};
use serde::Serialize;

#[derive(Serialize)]
struct WeatherForecastResponse {
    id: i32,
    temperature: i32,
}

#[get("/weather-forecast-id/{id}")]
pub async fn weather_forecast_by_id(param: web::Path<i32>) -> HttpResponse {
    let id = param.into_inner();

    let get_weather_impl = GetWeatherForecast::new();
    let weather = IGetWeatherForecast::execute(&get_weather_impl, id).await;

    if let Ok(_weather) = weather {
        HttpResponse::Ok().json(WeatherForecastResponse {
            id,
            temperature: _weather.temperature,
        })
    } else {
        HttpResponse::NotFound().finish()
    }
}
