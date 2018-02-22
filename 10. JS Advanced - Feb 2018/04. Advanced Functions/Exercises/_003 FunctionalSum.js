function functionalSum(input) {
    let sum = 0;

    function add(num) {
        sum += num;
        return sum;
    }

    return add;
}

functionalSum(1)(6)(-3);