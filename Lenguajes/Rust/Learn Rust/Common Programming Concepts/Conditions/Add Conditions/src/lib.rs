pub fn fizz_if_foo(fizzish: &str) -> &str {
    if fizzish == "fizz" {
        return "foo";
    } else if fizzish == "fuzz" {
        return "bar";
    } 
    "baz"
}

