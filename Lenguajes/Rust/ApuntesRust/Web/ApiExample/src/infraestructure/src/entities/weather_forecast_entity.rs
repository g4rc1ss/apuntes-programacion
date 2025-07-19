use diesel::{Queryable, Selectable};

// #[derive(Queryable, Selectable)]
pub struct WeatherForecastEntity {
    pub(crate) id: i32,
    pub(crate) temperature: i32,
}