function distanceIn3D(input) {
    let x1 = input[0];
    let y1 = input[1];
    let z1 = input[2];
    let x2 = input[3];
    let y2 = input[4];
    let z2 = input[5];
    let a = x1 - x2;
    let b = y1 - y2;
    let c = z1 - z2;
    let result = Math.sqrt(Math.pow(a, 2) + Math.pow(b, 2) + Math.pow(c, 2));
    console.log(result);
}

distanceIn3D([3.5, 0, 1, 0, 2, -1]);