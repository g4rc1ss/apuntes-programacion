use std::env;
use crate::entities::weather_forecast_entity::WeatherForecastEntity;
use crate::schema::weatherforecast::dsl::weatherforecast;
use crate::schema::weatherforecast::{id, temperature};
use diesel::{Connection, ExpressionMethods, QueryDsl, RunQueryDsl, SqliteConnection};

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
    async fn execute(&self, weather_id: i32) -> WeatherForecastEntity {
        let current_dir = env::current_dir().unwrap();
        println!("Directorio actual: {:?}", current_dir);

        let database_url = "src/infraestructure/src/database.sqlite";
        let mut connection = SqliteConnection::establish(database_url)
            .unwrap_or_else(|_| panic!("Error connecting to {}", database_url));

        let result = weatherforecast
            .filter(id.eq(weather_id))
            .select((id, temperature))
            .first::<WeatherForecastEntity>(&mut connection)
            .unwrap_or_else(|_| panic!("Error loading weather forecast: {}", weather_id));

        result
    }
}
