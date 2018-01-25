function formFiller(username, email, phoneNumber, text) {
    let re = new RegExp(/(<![A-Za-z]+!>)|(<@[A-Za-z]+@>)|(<\+[A-Za-z]+\+>)/, 'g');
    let result = [];
    for (let value of text) {
        result.push(value.replace(re, function (u) {
            if (u.match(/(<!.*!>)/)) {
                return username;
            }
            else if (u.match(/(<@.*@>)/)) {
                return email;
            }
            else if (u.match(/(<\+.*\+>)/)) {
                return phoneNumber;
            }
        }))
    }

    console.log(result.join('\n'));
}

formFiller('Pesho',
    'pesho@softuni.bg',
    '90-60-90',
    ['Hello, <!username!>!',
        'Welcome to your Personal profile.',
        'Here you can modify your profile freely.',
        'Your current username is: <!fdsfs!>. Would you like to change that? (Y/N)',
        'Your current email is: <@DasEmail@>. Would you like to change that? (Y/N)',
        'Your current phone number is: <+number+>. Would you like to change that? (Y/N)']
);