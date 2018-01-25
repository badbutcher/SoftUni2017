function simpleEmailValidation(email) {
    let re = new RegExp(/^([A-Za-z0-9]+)@([a-z]+).([a-z]+)$/, 'g');
    if (re.test(email)) {
        console.log('Valid');
    }
    else {
        console.log('Invalid');
    }
}

simpleEmailValidation('valid@email.bg');
simpleEmailValidation('invalid@emai1.bg');
