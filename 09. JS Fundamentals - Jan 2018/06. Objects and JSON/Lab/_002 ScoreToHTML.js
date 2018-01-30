function scoreToHTML(input) {
    console.log('<table>');
    console.log('<tr><th>name</th><th>score</th></tr>');
    let arr = JSON.parse(input);
    for (let obj of arr) {
        let values = Object.values(obj);
        console.log(`<tr><td>${replaceSymbols(values[0])}</td><td>${values[1]}</td></tr>`);
    }

    console.log('</table>');

    function replaceSymbols(str) {
        return str.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }
}

scoreToHTML('[{"name":"Pesho & Kiro","score":479},{"name":"Gosho, Maria & Viki","score":205}]');