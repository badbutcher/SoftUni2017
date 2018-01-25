function aggregateTable(input) {
    let towns = [];
    let money = 0;
    for (let item of input) {
        let startIndex = item.indexOf('|');
        let endIndex = item.lastIndexOf('|');
        let town = item.substring(startIndex + 2, endIndex).trim();
        let moneyToAdd = Number(item.substring(endIndex + 2));
        towns.push(town);
        money += moneyToAdd;
    }

    console.log(towns.join(', '));
    console.log(money);
}

aggregateTable(['| Sofia           | 300',
    '| Veliko Tarnovo  | 500',
    '| Yambol          | 275']
);