function validityChecker(input) {
    let x1 = input[0];
    let y1 = input[1];
    let x2 = input[2];
    let y2 = input[3];

    let pointOne = point(x1, y1, 0, 0);
    let pointTwo = point(x2, y2, 0, 0);
    let pointThree = point(x1, y1, x2, y2);

    function point(x1, y1, x2, y2) {
        let result = Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
        if (result % 1 === 0) {
            return `{${x1}, ${y1}} to {${x2}, ${y2}} is valid`;
        }
        else {
            return `{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`;
        }
    }

    console.log(pointOne);
    console.log(pointTwo);
    console.log(pointThree);
}


validityChecker([2, 1, 1, 1]);