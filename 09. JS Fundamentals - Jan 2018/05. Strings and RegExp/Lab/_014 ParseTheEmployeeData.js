function parseTheEmployeeData(input) {
    let re = new RegExp(/^([A-Z][A-Za-z]*) - ([1-9][0-9*]*) - ([A-Za-z0-9-_ ]+)$/, 'g');
    let match;
    for (let value of input) {
        while (match = re.exec(value)) {
            console.log(`Name: ${match[1]}`);
            console.log(`Position: ${match[3]}`);
            console.log(`Salary: ${match[2]}`);
        }
    }
}

parseTheEmployeeData(['Isacc - 1000 - CEO',
    'Ivan - 500 - Employee',
    'Peter - 500 - Employee',
]);