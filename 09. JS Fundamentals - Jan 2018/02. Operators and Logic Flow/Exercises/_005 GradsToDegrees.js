function gradsToDegrees(grad) {
    let degrees = 0;

    grad = grad % 400;
    if (grad < 0) {
        grad += 400;
    }

    let degreesToDivide = 100 / grad;
    degrees += 90 / degreesToDivide;

    console.log(degrees % 360);
}

gradsToDegrees(100);