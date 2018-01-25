function usernames(input) {
    let result = [];
    for (let value of input) {
        let em = value.indexOf('@');
        let firstName = value.substring(0, em);
        let letters = value.substring(em + 1, em + 2);
        let index = value.indexOf('.');
        while (index > -1) {
            letters += value.substring(index + 1, index + 2);
            index = value.indexOf('.', index + 1);
        }

        result.push(`${firstName}.${letters}`)
    }

    console.log(result.join(', '));
}

usernames(['peshoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com']);