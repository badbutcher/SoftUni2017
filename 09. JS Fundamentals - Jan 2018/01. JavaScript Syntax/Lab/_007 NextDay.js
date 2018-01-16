function nextDay(year, month, day) {
    let date = new Date(year, month - 1, day);
    date.setTime(date.getTime() + 1 * 86400000);

    console.log(date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate());
}

nextDay(2016, 9, 30);