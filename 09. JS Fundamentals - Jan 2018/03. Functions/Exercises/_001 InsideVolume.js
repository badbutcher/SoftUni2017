function insideVolume(input) {
    for (let i = 0; i < input.length; i += 3) {
        if (input[i] >= 10 &&
            input[i] <= 50 &&
            input[i + 1] >= 20 &&
            input[i + 1] <= 80 &&
            input[i + 2] >= 15 &&
            input[i + 2] <= 50) {
            console.log('inside');
        }
        else {
            console.log('outside');
        }
    }
}

insideVolume([13.1, 50, 31.5,
    50, 80, 50,
    -5, 18, 43]
);