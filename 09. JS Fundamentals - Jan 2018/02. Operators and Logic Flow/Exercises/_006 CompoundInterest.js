function compoundInterest(input) {
    let principalSum = input[0];
    let interestRate = input[1];
    let compoundingPeriod = input[2];
    let timespan = input[3];

    let nt = 12 / compoundingPeriod * timespan;
    let inner = 1 + interestRate / (100 * (12 / compoundingPeriod));
    let result = principalSum * Math.pow(inner, nt);

    console.log(result.toFixed(2));
}

compoundInterest([1500, 4.3, 3, 6]);