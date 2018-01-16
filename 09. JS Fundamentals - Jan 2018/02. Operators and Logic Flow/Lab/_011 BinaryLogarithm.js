function binaryLogarithm(numbers) {
    for (let number of numbers) {
        let log = Math.log2(number);
        console.log(log);
    }
}

binaryLogarithm([1024, 1048576, 256, 1, 2, 50, 100]);