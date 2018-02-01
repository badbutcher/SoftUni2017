function populationsInTowns(input) {
    let result = {};
    let re = new RegExp(/ <-> /, 'g');
    for (let i = 0; i < input.length; i++) {
        let data = input[i].split(re);
        let town = data[0];
        let pop = Number(data[1]);
        if (!result.hasOwnProperty(town)) {
            result[town] = pop;
        }
        else {
            result[town] += pop
        }
    }

    let print = Object.keys(result);
    for (let obj of print) {
        console.log(obj + ' : ' + result[obj]);
    }

    // Object.keys(result).forEach(function(key) {
    //     console.log(key, result[key]);
    // });
}


populationsInTowns(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000'
]);