function countWordsWithMaps(input) {
    let result = new Map();
    let re = new RegExp(/\W+/, 'g');
    input = input[0].replace(re, ' ').toLowerCase().trim().split(' ');
    for (let obj of input) {
        if (!result.has(obj)) {
            result.set(obj, Number(1));
        }
        else {
            let v = Number(result.get(obj) + 1);
            result.set(obj, v);
        }
    }

    let allWords = Array.from(result.keys()).sort();
    //allWords.forEach(w => console.log(`'${w}' -> ${result.get(w)} times`));

    for (let value of allWords) {
        console.log(`'${value}' -> ${result.get(value)} times`);
    }
}

countWordsWithMaps(['Far too slow, you\'re far too slow.']);