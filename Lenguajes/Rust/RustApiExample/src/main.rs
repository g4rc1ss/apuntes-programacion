#[macro_use] extern crate rocket;

use rocket::serde::{json::Json, Deserialize, Serialize};

#[get("/")]
fn  index() -> &'static str {
    "Hola desde Rocket!"
}

#[derive(Debug, Serialize, Deserialize)]
#[serde(crate = "rocket::serde")]
struct Persona {
    nombre: String,
    edad: u8,
}

#[post("/persona", format = "json", data = "<persona>")]
fn crear_persona(persona: Json<Persona>) -> Json<Persona> {
    println!("Recibido: {:?}", persona);
    persona
}

#[launch]
fn rocket() -> _ {
    rocket::build()
        .mount("/", routes![index, crear_persona])
}
