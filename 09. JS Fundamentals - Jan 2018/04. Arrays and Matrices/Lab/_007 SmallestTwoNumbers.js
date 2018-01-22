function smallestTwoNumbers(input) {
    let result = input.sort(sortNumber).slice(0, 2);
    console.log(result);

    function sortNumber(a, b) {
        return a - b;
    }
}

smallestTwoNumbers([30, 15, 50, 5]);