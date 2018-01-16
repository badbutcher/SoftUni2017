function sumAndVAT(input) {
    let sum = 0;
    for (let number of input) {
        sum += number;
    }

    console.log("sum = " + sum);
    console.log("VAT = " + sum * 0.20);
    console.log("total = " + sum * 1.20);
}

sumAndVAT([1.20, 2.60, 3.50]);