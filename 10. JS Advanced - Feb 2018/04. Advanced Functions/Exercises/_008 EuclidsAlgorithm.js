function euclidsAlgorithm(num1, num2) {
    while (!(num1 <= 0 || num2 <= 0)) {
        let remainder = num1 % num2;
        let left = Math.floor(num1 / num2);

        let formula = num2 * left + remainder;
        if (formula === num1) {
            num1 = num2;
            num2 = remainder;
        }
    }

    return Math.max(num1, num2);
}

euclidsAlgorithm([252, 105]);