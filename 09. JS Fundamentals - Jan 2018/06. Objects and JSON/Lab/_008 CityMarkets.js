function cityMarkets(input) {
    let result = new Map();
    let re = new RegExp(/ -> | : /, 'g');
    for (let i = 0; i < input.length; i++) {
        let data = input[i].split(re);
        let town = data[0];
        let product = data[1];
        let amountOfSales = Number(data[2]);
        let priceForOneUnit = Number(data[3]);

        if (!result.has(town)) {
            result.set(town, new Map());
        }

        if (!result.get(town).has(product)) {
            result.get(town).set(product, amountOfSales * priceForOneUnit);
        }
        else {
            let priceToAdd = result.get(town).get(product);
            result.get(town).set(product, amountOfSales * priceForOneUnit + priceToAdd);
        }
    }

    for (let town of result) {
        console.log(`Town - ${town[0]}`);
        for (let item of town[1]) {
            console.log(`$$$${item[0]} : ${item[1]}`);
        }
    }
}

cityMarkets([
    'Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3'
]);