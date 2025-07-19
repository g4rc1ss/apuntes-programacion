use actix_web::{App, HttpServer};

#[actix_web::main]
async fn main() -> std::io::Result<()> {
    HttpServer::new(|| {
        App::new().service(api::endpoints::weather_forecast_by_id::weather_forecast_by_id)
    })
    .bind(("127.0.0.1", 37456))?
    .run()
    .await
}
