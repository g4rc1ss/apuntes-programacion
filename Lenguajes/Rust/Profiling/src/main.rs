use std::thread::{sleep, Thread};
use std::time::Duration;

fn main() {
    Hello()
}


pub fn Hello() {
    sleep(Duration::from_secs(2));
    println!("Hello, world!");
}