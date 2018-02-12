function problem4(armyInput, battleInput) {
    let kingdoms = new Map();
    let winners = new Map();

    for (let obj of armyInput) {
        let kingdom = obj['kingdom'];
        let general = obj['general'];
        let army = obj['army'];

        if (!kingdoms.has(kingdom)) {
            kingdoms.set(kingdom, new Map());
            winners.set(kingdom, new Map());
        }

        if (!kingdoms.get(kingdom).has(general)) {
            kingdoms.get(kingdom).set(general, 0);
            winners.get(kingdom).set(general, [0, 0]);
        }

        kingdoms.get(kingdom).set(general, army + kingdoms.get(kingdom).get(general))
    }

    for (let obj of battleInput) {
        let attKingdom = obj[0];
        let attGeneral = obj[1];
        let defKingdom = obj[2];
        let defGeneral = obj[3];

        if (attKingdom === defKingdom) {
            continue;
        }

        let attacker = kingdoms.get(attKingdom).get(attGeneral);
        let defender = kingdoms.get(defKingdom).get(defGeneral);

        if (attacker > defender) {
            attacker += Math.round((attacker * 10) / 100);
            defender -= Math.round((defender * 10) / 100);

            winners.get(attKingdom).get(attGeneral)[0]++;
            winners.get(defKingdom).get(defGeneral)[1]++;
        }
        else if (attacker < defender) {
            attacker -= Math.round((attacker * 10) / 100);
            defender += Math.round((defender * 10) / 100);
            winners.get(attKingdom).get(attGeneral)[1]++;
            winners.get(defKingdom).get(defGeneral)[0]++;
        }

        kingdoms.get(attKingdom).set(attGeneral, attacker);
        kingdoms.get(defKingdom).set(defGeneral, defender);
    }

    let sortBattles = Array.from(winners).sort(function (a, b) {
        let g1 = Array.from(a[1].values());
        let g2 = Array.from(b[1].values());

        if (g2[0][0] - g1[0][0] > 0) {
            return g2[0][0] - g1[0][0]
        }
        else if (g1[0][1] - g2[0][1] < 0) {
            return g1[0][1] - g2[0][1]
        }
        else {
            return a[0].localeCompare(b[0]);
        }
    })[0];
    let re = [];
    for (let obj of sortBattles[1]) {
        re.push(obj);
    }
    let ads = re.sort(function (a, b) {
        if (b[1][0] - a[1][0] > 0) {
            return b[1][0] - a[1][0]
        }
        else if (a[1][1] - b[1][1] < 0) {
            return a[1][1] - b[1][1]
        }
        else {
            return a[0].localeCompare(b[0]);
        }
    });
    //console.log(ads);
    let generals = [];
    let army = [];
    let result = kingdoms.get(sortBattles[0]);
    let mapAsc = Array.from(new Map([...result.entries()].sort()));
    for (let obj of mapAsc) {
        let data = obj;
        generals.push(data[0]);
        army.push(data[1]);
    }

    console.log(`Winner: ${sortBattles[0]}`);
    for (let obj of ads) {
        console.log(`/\\general: ${generals.shift()}`);
        console.log(`---army: ${army.shift()}`);
        console.log(`---wins: ${obj[1][0]}`);
        console.log(`---losses: ${obj[1][1]}`);
    }
}

problem4([{kingdom: "Maiden Way", general: "Merek", army: 5000},
        {kingdom: "Stonegate", general: "Ulric", army: 4900},
        {kingdom: "Stonegate", general: "Doran", army: 70000},
        {kingdom: "YorkenShire", general: "Quinn", army: 0},
        {kingdom: "YorkenShire", general: "Quinn", army: 2000},
        {kingdom: "Maiden Way", general: "Berinon", army: 100000}],
    [["YorkenShire", "Quinn", "Stonegate", "Ulric"],
        ["Stonegate", "Ulric", "Stonegate", "Doran"],
        ["Stonegate", "Doran", "Maiden Way", "Merek"],
        ["Stonegate", "Ulric", "Maiden Way", "Merek"],
        ["Maiden Way", "Berinon", "Stonegate", "Ulric"]]
);
