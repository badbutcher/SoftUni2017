function ajaxRequestValidator(input) {
    let methodRegex = new RegExp(/^Method: (GET|POST|PUT|DELETE)$/, 'g');
    let credentialsRegex = new RegExp(/^Credentials: (Basic|Bearer) [A-Za-z0-9]+$/, 'g');
    let contentRegex = new RegExp(/^Content: [A-Za-z0-9\.]+$/, 'g');
    let hashPattern = input.pop();

    for (let i = 0; i < input.length - 1; i += 3) {
        let method = input[i].match(methodRegex)[0].split(' ')[1];
        let credentials = input[i + 1].match(credentialsRegex)[0].split(' ');
        let content = input[i + 2].match(contentRegex);

        if (method === null || credentials === null || content === null) {
            console.log('Response-Code:400');
        }
        else if (credentials[1] === 'Basic' && (method === 'POST' || method === 'PUT' || method === 'DELETE')) {
            console.log(`Response-Method:${method}&Code:401`);
        }
        else {
            let check = true;
            let re = new RegExp(/([0-9]+)([A-Za-z]+)/, 'g');

            let match;
            while (match = re.exec(hashPattern)) {
                let repeating = Number(match[1]);
                let letter = match[2].toLowerCase();
                let reCount = new RegExp(letter, 'g');
                let count = 0;
                let innerMatch = credentials[2].match(reCount);
                if (innerMatch !== null) {
                    count = innerMatch.length;
                }
                else {
                    check = false;
                }

                if (count === repeating) {
                    check = true;
                    break;
                }
                else {
                    check = false;
                }
            }

            if (!check) {
                console.log(`Response-Method:${method}&Code:403`);
            }
            else {
                console.log(`Response-Method:${method}&Code:200&Header:${credentials[2]}`);
            }
        }
    }
}

ajaxRequestValidator([
'Method: GET',
'Credentials: Bearer asd918721jsdbhjslkfwkiuwjoxXJIdahefJAB',
'Content: users.asd.1782452.278asd',
'Method: POST',
'Credentials: Basic 028591u3jtndkgwndsdkfjwelfkjwporjebhas',
'Content: Johnathan',
'0q'
]);

console.log('\n---\n');

ajaxRequestValidator(['Method: PUT',
    'Credentials: Bearer as9133jsdbhjslkfqwkqiuwjoxXJIdahefJAB',
    'Content: users.asd/1782452$278///**asd123',
    'Method: POST',
    'Credentials: Bearer 028591u3jtndkgwndskfjwelfqkjwporjqebhas',
    'Content: Johnathan',
    'Method: DELETE',
    'Credentials: Bearer 05366u3jtndkgwndssfsfgeryerrrrrryjihvx',
    'Content: This.is.a.sample.content',
    '2e5g'
]);