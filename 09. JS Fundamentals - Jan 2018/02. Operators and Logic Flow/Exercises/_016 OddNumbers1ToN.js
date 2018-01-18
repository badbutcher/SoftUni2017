function oddNumbers1ToN(number) {
    for (let i = 0; i <= number; i++) {
        if (i % 2 === 1) {
            console.log(i);
        }
    }
}

oddNumbers1ToN(7);