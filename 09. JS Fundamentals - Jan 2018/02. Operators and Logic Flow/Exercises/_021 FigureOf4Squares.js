function figureOf4Squares(n) {
    if (n % 2 === 0) {
        for (let i = 0; i < n - 1; i++) {
            if (i === 0 || i === n - 2 || i % Math.ceil(n / 2 - 1) === 0) {
                console.log(`+${Array(n - 1).join("-")}+${Array(n - 1).join("-")}+`);
            }
            else {
                console.log(`|${Array(n - 1).join(" ")}|${Array(n - 1).join(" ")}|`);
            }

        }
    }
    else {
        for (let i = 0; i < n; i++) {
            if (i === 0 || i === n - 1 || i % Math.ceil(n / 2 - 1) === 0) {
                console.log(`+${Array(n - 1).join("-")}+${Array(n - 1).join("-")}+`);
            }
            else {
                console.log(`|${Array(n - 1).join(" ")}|${Array(n - 1).join(" ")}|`);
            }

        }
    }
}

figureOf4Squares(2);