function negativePositiveNumbers(input) {
    let array = [];
    for (let value of input) {
        if (value < 0) {
            array.unshift(value);
        }
        else {
            array.push(value);
        }
    }

    console.log(array);
}

negativePositiveNumbers([3, -2, 0, -1]);