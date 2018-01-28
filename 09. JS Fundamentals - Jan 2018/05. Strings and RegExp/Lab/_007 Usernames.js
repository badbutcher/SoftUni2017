function usernames(input) {
    let result = [];
    for (let value of input) {
        let em = value.indexOf('@');
        let domain = value.substring(em);
        let firstName = value.substring(0, em);
        let letters = value.substring(em + 1, em + 2);
        let index = domain.indexOf('.');
        while (index > -1) {
            letters += domain.substring(index + 1, index + 2);
            index = domain.indexOf('.', index + 1);
        }

        result.push(`${firstName}.${letters}`)
    }

    console.log(result.join(', '));
}

usernames(['pes.hoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com']);