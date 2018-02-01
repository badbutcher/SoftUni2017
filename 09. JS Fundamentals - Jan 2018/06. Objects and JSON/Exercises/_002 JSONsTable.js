function jsonsTable(input) {
    for (let i = 0; i < input.length; i++) {
        input[i] = JSON.parse(input[i]);
    }

    console.log('<table>');

    for (let value of input) {
        let values = Object.values(value);
        console.log(`\t<tr>\n\t\t<td>${values[0]}</td>\n\t\t<td>${values[1]}</td>\n\t\t<td>${values[2]}</td>\n\t<tr>`);
    }

    console.log('</table>');
}

jsonsTable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}'
]);