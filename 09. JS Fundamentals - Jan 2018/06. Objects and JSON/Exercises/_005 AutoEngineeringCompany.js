function autoEngineeringCompany(input) {
    let brands = new Map();

    for (let value of input) {
        let data = value.split(' | ');
        let brand = data[0];
        let car = data[1];
        let carsMade = Number(data[2]);

        if (!brands.has(brand)) {
            brands.set(brand, new Map())
        }

        if (!brands.get(brand).has(car)) {
            brands.get(brand).set(car, 0)
        }

        brands.get(brand).set(car, brands.get(brand).get(car) + carsMade)
    }

    for (let brand of brands) {
        console.log(`${brand[0]}`);

        for (let car of brand[1]) {
            console.log(`###${car[0]} -> ${car[1]}`);
        }
    }
}

autoEngineeringCompany(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'
]);