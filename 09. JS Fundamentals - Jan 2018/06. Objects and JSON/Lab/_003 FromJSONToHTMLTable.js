function fromJSONToHTMLTable(input) {
    console.log('<table>');
    let arr = JSON.parse(input);
    let keys = Object.keys(arr[0]);

    let th = '<tr>';
    for (let obj of keys) {
        th += `<th>${obj}</th>`
    }
    th += '</tr>';
    console.log(th);

    for (let obj of arr) {
        let innerTh = '<tr>';
        let values = Object.values(obj);
        for (let value of values) {
            innerTh += `<td>${replaceSymbols(value.toString())}</td>`;
        }

        innerTh += '</tr>';
        console.log(innerTh);
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

fromJSONToHTMLTable('[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia"}, {"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]'
);