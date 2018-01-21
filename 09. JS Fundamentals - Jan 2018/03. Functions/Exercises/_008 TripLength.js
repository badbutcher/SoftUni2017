function tripLength(input) {
    let x1 = input[0];
    let y1 = input[1];
    let x2 = input[2];
    let y2 = input[3];
    let x3 = input[4];
    let y3 = input[5];

    let pointOne = point(x1, y1, x2, y2);
    let pointTwo = point(x2, y2, x3, y3);
    let pointThree = point(x1, y1, x3, y3);

    if (pointOne <= pointThree && pointThree >= pointTwo) {
        console.log(`1->2->3: ${pointOne + pointTwo}`);
    }
    else if (pointOne <= pointTwo && pointThree <= pointTwo) {
        console.log(`2->1->3: ${pointOne + pointThree}`);
    }
    else if (pointThree <= pointOne && pointOne >= pointTwo) {
        console.log(`1->3->2: ${pointTwo + pointThree}`);
    }

    function point(x1, y1, x2, y2) {
        let result = Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
        return result;
    }
}

tripLength([0, 0, 2, 0, 4, 0]);
console.log();
tripLength([5, 1, 1, 1, 5, 4]);
console.log();
tripLength([-1, -2, 3.5, 0, 0, 2]);