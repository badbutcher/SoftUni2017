function spyMaster(input) {
    let key = input.shift();
    let specialKeyChars = "";
    for (let char of key) {
        specialKeyChars += `[${char.toUpperCase()}${char.toLowerCase()}]`;
    }

    let re = new RegExp('((?:^| )' + specialKeyChars + ' +)([A-Z!%$#]{8,})([ .,]|$)', 'g');

    let match;
    let result = [];
    for (let obj of input) {
        let replaceLine = obj;
        while (match = re.exec(obj)) {
            replaceLine = replaceLine.replace(match[0], match[1] + replaceChars(match[2]) + match[3]);
        }

        result.push(replaceLine);
    }

    function replaceChars(str) {
        return str
            .replace(/!/g, '1')
            .replace(/%/g, '2')
            .replace(/#/g, '3')
            .replace(/\$/g, '4')
            .toLowerCase();
    }

    console.log(result.join('\n'));
}

spyMaster(['specialKey',
        'In this text the specialKey HELLOWORLD! is correct, but',
        'the following specialKey $HelloWorl#d and spEcIaLKEy HOLLOWORLD1 are not, while',
        'SpeCIaLkeY   SOM%%ETH$IN and SPECIALKEY ##$$##$$ are!'
    ]
);