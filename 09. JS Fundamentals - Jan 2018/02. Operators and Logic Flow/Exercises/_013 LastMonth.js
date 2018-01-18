function lastMonth(input) {
    let days = input[0];
    let months = input[1];
    let year = input[2];

    let date = new Date(year, months - 1, 0);
    console.log(date.getDate());
}

lastMonth([13, 12, 2004]);