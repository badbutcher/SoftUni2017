function townsToJSON(input) {
    let re = new RegExp(/\s*\|\s*/, 'g');
    let objs = [];
    for (let value of input.splice(1)) {
        let info = value.split(re);
        let town = {Town: info[1], Latitude: Number(info[2]), Longitude: Number(info[3])};
        objs.push(town)
    }

    console.log(JSON.stringify(objs));
}

townsToJSON(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
);