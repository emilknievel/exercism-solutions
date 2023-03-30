use time::PrimitiveDateTime as DateTime;
use time::Duration;

// Returns a DateTime one billion seconds after start.
// 1Gs = 1,000,000,000s
pub fn after(start: DateTime) -> DateTime {
    start + Duration::seconds(1000000000)
}
