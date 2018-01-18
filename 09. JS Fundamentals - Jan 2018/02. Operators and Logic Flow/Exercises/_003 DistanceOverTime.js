function distanceOverTime(input) {
    let dist1 = (input[0] / 3.6) * input[2];
    let dist2 = (input[1] / 3.6) * input[2];
    let result = Math.abs(dist1 - dist2);
    console.log(result);
}

distanceOverTime([11, 10, 120]);