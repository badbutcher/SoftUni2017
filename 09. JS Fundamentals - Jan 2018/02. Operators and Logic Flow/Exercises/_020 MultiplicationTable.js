function multiplicationTable(n) {
    let result = '';
    result = ''.concat(result, '<table border="1">');
    result = ''.concat(result, '\n');
    for (let i = 0; i <= n; i++) {
        result = ''.concat(result, '<tr>');
        for (let j = 0; j <= n; j++) {
            if (j === 0 && i === 0) {
                result = ''.concat(result, '<th>x</th>');
            }
            else if (i === 0) {
                result = ''.concat(result, `<th>${j}</th>`);
            }
            else if (j > 1 && i > 0) {
                result = ''.concat(result, `<td>${i * j}</td>`);
            }
            else if (j === 0) {
                result = ''.concat(result, `<th>${i}</th>`);
            }
            else {
                result = ''.concat(result, `<td>${i}</td>`);
            }
        }
        result = ''.concat(result, '</tr>');
        result = ''.concat(result, '\n');
    }

    result = ''.concat(result, '</table>');

    console.log(result);
}

multiplicationTable(3);