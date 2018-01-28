function escaping(input) {
    let result = input.map(a => a.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;'));

    console.log('<ul>');
    for (let value of result) {
        console.log(`<li>${value}</li>`);
    }

    console.log('</ul>');
}

escaping(['<div style=\"color: red;\">Hello, Red!</div>', '<table><tr><td>Cell 1</td><td>Cell 2</td><tr>']);