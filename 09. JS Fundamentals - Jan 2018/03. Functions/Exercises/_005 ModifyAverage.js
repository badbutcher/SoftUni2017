function modifyAverage(input) {
    let numbers = input.toString().split('');
    numbers = numbers.map(Number);

    while (numbers.reduce(function(a, b) { return a + b; }) / numbers.length <= 5)
    {
        numbers.push(9);
    }

    console.log(numbers.join(''));
}

modifyAverage(101);