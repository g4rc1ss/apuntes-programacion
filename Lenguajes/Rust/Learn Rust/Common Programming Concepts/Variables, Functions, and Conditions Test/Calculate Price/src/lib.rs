pub fn calculate_price(count: i32) -> i32 {
    if count >= 40 {
        return count * 1;
    }
    count * 2
}
