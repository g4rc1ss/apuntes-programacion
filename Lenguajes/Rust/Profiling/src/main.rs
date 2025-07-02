use std::io::stdin;
use std::thread::{sleep, Thread};
use std::time::Duration;

fn main() {
    Hello()
}


pub fn Hello() {
    
    // let mut nombre = String::new();
    // println!("Escribe texto");
    // stdin()
    //     .read_line(&mut nombre)
    //     .expect("Failed to read line");
    
    sleep(Duration::from_secs(2));
    println!("Hello, world!");
}