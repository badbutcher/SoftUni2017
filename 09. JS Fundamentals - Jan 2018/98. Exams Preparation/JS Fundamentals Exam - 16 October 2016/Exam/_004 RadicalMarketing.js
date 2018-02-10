function radicalMarketing(input) {
    let marketing = new Map();
    for (let obj of input) {
        let data = obj.split('-');
        if (data.length === 1 && !marketing.has(data[0])) {
            marketing.set(data[0], []);
        }
        else if (data.length === 2) {
            let user = data[0];
            let subscriber = data[1];

            if (marketing.has(user) && marketing.has(subscriber) && !marketing.get(subscriber).includes(user) && user !== subscriber) {
                marketing.get(subscriber).push(user);
            }
        }
    }
    // NEED TO FIX !!!!!!
    marketing = Array.from(marketing).sort(function (a, b) {
        let sort = b[1].length - a[1].length;
        if (sort === 0) {
            return sort;
        }
        else {
            return sort;
        }
    });

    console.log(marketing[0][0]);
    for (let i = 0; i < marketing[0][1].length; i++) {
        let element = marketing[0][1][i];
        console.log(`${i + 1}. ${element}`)
    }
}

radicalMarketing(
    ['A',
        'B',
        'C',
        'D',
        'A-B',
        'B-A',
        'C-A',
        'D-A'
    ]
);
console.log('-------------');
radicalMarketing([
    'J',
    'G',
    'P',
    'R',
    'C',
    'J-G',
    'G-J',
    'P-R',
    'R-P',
    'C-J'
]);