function gradsToDegrees(grad) {
    let degrees = 0;
    let currentGrad = 100;

    if (grad < 0) {
        grad += 400;
    }

    while (currentGrad <= grad) {
        degrees += 90;
        currentGrad += 100;
    }

    if (currentGrad - 100 < grad) {
        currentGrad = currentGrad - grad;
        let degreesToAdd = 100 / currentGrad;
        degrees += 90 / degreesToAdd;
    }

    console.log(degrees % 360);
}

gradsToDegrees(-50);