function captureTheNumbers(input) {
    let re = new RegExp(/\d+/, 'g');
    let result = [];
    let match;

    while (match = re.exec(input)) {
        result.push(match[0]);
    }

    console.log(result.join(' '));
}

captureTheNumbers(['The300',
    'What is that? ',
    'I think it’s the 3rd movie.',
    'Lets watch it at 22:45',
])