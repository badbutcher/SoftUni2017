function argumentInfo(input) {
    let items = [{
        string: 0,
        number: 0,
        function: 0,
    }];

    for (let i = 0; i < arguments.length; i++) {
        let data = arguments[i];
        let type = typeof data;
        if (type === 'string') {
            console.log(`${type}: ${data}`);
        } else if (type === 'number') {
            console.log(`${type}: ${data}`);
        } else if (type === 'function') {
            console.log(`${type}: ${data}`);
        }else if (type === 'object') {
            console.log(`${type}: ${data}`);
        }

        items[0][type]++;
    }

    let sorted = Object.keys(items[0]).sort((a, b) => items[0][b] - items[0][a]);

    for (let obj of sorted) {
        let count = items[0][obj];
        if (count > 0) {
            console.log(`${obj} = ${count}`);
        }
    }
}

argumentInfo({ name: 'bob'}, 3.333, 9.999);