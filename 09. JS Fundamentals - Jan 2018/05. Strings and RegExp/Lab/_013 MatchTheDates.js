function matchTheDates(input) {
    let re = new RegExp(/\b([0-9]{1,2})-([A-Z][a-z]{2})-([0-9]{4})\b/, 'g');
    for (let value of input) {
        let match;
        while(match = re.exec(value)) {
            console.log(`${match[0]} (Day: ${match[1]}, Month: ${match[2]}, Year: ${match[3]})`);
        }
    }
}

matchTheDates(['I am born on 30-Dec-1994.',
    'This is not date: 512-Jan-1996.',
    'My father is born on the 29-Jul-1955.',
]);

console.log();

matchTheDates(['1-Jan-1999 is a valid date.',
    'So is 01-July-2000.',
    'I am an awful liar, by the way – Ivo, 28-Sep-2016.',
]);