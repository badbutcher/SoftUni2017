function evenPositionElement(input) {
    let sum = [];
    for (let i = 0; i < input.length; i += 2) {
        sum.push(input[i]);
    }

    console.log(sum.join(' '));
}

evenPositionElement(['20', '30', '40']);