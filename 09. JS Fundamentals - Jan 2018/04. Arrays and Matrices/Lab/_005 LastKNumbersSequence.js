function lastKNumbersSequence(length, elementsToSum) {
    let result = [1];
    for (let i = 1; i < length; i++) {
        let start = Math.max(0, result.length - elementsToSum);
        let end = elementsToSum + i;

        result[i] = result.slice(start, end)
            .reduce((a, b) => a + b);
    }

    console.log(result);
}

lastKNumbersSequence(6, 3);