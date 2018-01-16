function triangleArea(a, b, c) {
    let halfP = (a + b + c) / 2;
    let area = Math.sqrt(halfP * (halfP - a) * (halfP - b) * (halfP - c));
    console.log(area);
}

triangleArea(2, 3.5, 4);