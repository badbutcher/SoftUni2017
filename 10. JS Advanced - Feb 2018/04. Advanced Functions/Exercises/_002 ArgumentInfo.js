function argumentInfo(input) {
    let items = {};

    for (let i = 0; i < arguments.length; i++) {
        let data = arguments[i];
        let type = typeof data;
        if (!items[type]) {
            items[type] = 1;
        } else {
            items[type]++;
        }

        console.log(`${type}: ${data}`);
    }

    let sorted = Object.keys(items).sort((a, b) => items[b] - items[a]);

    for (let obj of sorted) {
        let count = items[obj];
        if (count > 0) {
            console.log(`${obj} = ${count}`);
        }
    }
}

argumentInfo({name: 'bob'}, 3.333, 9.999);