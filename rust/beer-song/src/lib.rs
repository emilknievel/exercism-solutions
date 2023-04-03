pub fn verse(n: u32) -> String {
    let string = match n {
        0 => {
            "No more bottles of beer on the wall, no more bottles of beer.
Go to the store and buy some more, 99 bottles of beer on the wall.\n"
        }

        1 => {
            "1 bottle of beer on the wall, 1 bottle of beer.
Take it down and pass it around, no more bottles of beer on the wall.\n"
        }

        2 => {
            "2 bottles of beer on the wall, 2 bottles of beer.
Take one down and pass it around, 1 bottle of beer on the wall.\n"
        }

        3.. => {
            return format!(
                "{} bottles of beer on the wall, {} bottles of beer.
Take one down and pass it around, {} bottles of beer on the wall.\n",
                n,
                n,
                n - 1
            )
            .to_owned()
        }
    };
    return string.to_owned();
}

pub fn sing(start: u32, end: u32) -> String {
    let mut song = String::new();

    for v in (end..=start).rev() {
        song.push_str(&format!("{}", &verse(v)));
        if v > end {
            song.push_str("\n");
        }
    }

    return song.to_owned();
}
