function triangleOfStars(number) {
    if (number === 1) {
        console.log('*');
    }
    else {
        for (let i = 0; i < number; i++) {
            console.log('*'.repeat(i));
        }

        console.log('*'.repeat(number));

        for (let i = number - 1; i >= 0; i--) {
            console.log('*'.repeat(i));
        }
    }
}

triangleOfStars(5);