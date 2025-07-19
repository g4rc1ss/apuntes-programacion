use diesel::{Queryable, Selectable};
use crate::schema::weatherforecast;

#[derive(Queryable, Selectable)]
#[diesel(table_name = weatherforecast)]
pub struct WeatherForecastEntity {
    pub id: i32,
    pub temperature: Option<i32>,
}