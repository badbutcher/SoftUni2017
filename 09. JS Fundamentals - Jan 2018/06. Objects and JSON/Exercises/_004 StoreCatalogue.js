function storeCatalogue(input) {
    let products = new Map();

    for (let value of input) {
        let data = value.split(' : ');
        let product = data[0];
        let quantity = Number(data[1]);

        if (!products.has(product)) {
            products.set(product, 0)
        }

        products.set(product, quantity + products.get(product));
    }

    let result = Array.from(products).sort();
    let currentLetter = result[0][0][0];
    console.log(currentLetter);
    for (let [key, value] of result) {
        if (currentLetter !== key[0]) {
            currentLetter = key[0];
            console.log(currentLetter);
        }

        console.log(`  ${key}: ${value}`);
    }
}

storeCatalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);