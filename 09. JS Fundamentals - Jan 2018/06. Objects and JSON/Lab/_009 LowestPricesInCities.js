function lowestPricesInCities(input) {
    let result = new Map();
    let re = new RegExp(/ \| /, 'g');
    for (let i = 0; i < input.length; i++) {
        let data = input[i].split(re);
        let town = data[0];
        let product = data[1];
        let price = Number(data[2]);

        if (!result.has(product)) {
            result.set(product, new Map())
        }

        result.get(product).set(town, price)
    }

    for (let [product, insideMap] of result) {
        let lowestPrice = Number.POSITIVE_INFINITY;
        let townWithLowestPrice = "";
        for (let [town, price] of insideMap) {
            if (price < lowestPrice) {
                lowestPrice = price;
                townWithLowestPrice = town;
            }
        }

        console.log(`${product} -> ${lowestPrice} (${townWithLowestPrice})`);
    }
}

lowestPricesInCities(['Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999',
    'New York City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Mexico City | Audi | 100000',
    'Washington City | Mercedes | 1000'
]);