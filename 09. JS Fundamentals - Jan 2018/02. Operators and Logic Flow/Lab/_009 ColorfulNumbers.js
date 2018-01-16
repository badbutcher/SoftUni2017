function colorfulNumbers(lines) {
    console.log('<ul>');
    for (let i = 1; i <= lines; i++) {
        if (i % 2 == 1) {
            console.log(`<li><span style=\'color:green\'>${i}</span></li>`);
        }
        else if (i % 2 == 0) {
            console.log(`<li><span style=\'color:blue\'>${i}</span></li>`);
        }
    }
    console.log('</ul>');
}

colorfulNumbers(11);