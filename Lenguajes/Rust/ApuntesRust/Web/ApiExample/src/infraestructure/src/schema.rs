// @generated automatically by Diesel CLI.

diesel::table! {
    weatherforecast (id) {
        id -> Integer,
        temperature -> Nullable<Integer>,
    }
}
