function rounding(input) {
    let number = input[0];
    let precision = input[1];

    if (precision >= 15) {
        precision = 15;
    }

    let result = parseFloat(number.toFixed(precision));
    console.log(result);
}

rounding([10123.5, 3]);