function ajaxRequestValidator(input) {
    let methodRegex = new RegExp(/^Method:\s+GET|POST|PUT|DELETE$/, 'g');
    let credentialsRegex = new RegExp(/^Credentials:\s+(Basic |Bearer )[A-Za-z0-9]+$/, 'g');
    let contentRegeex = new RegExp(/^Content: [A-Za-z0-9\.]+$/, 'g')
}

ajaxRequestValidator(['Method: GET',
    'Credentials: Bearer asd918721jsdbhjslkfqwkqiuwjoxXJIdahefJAB',
    'Content: users.asd.1782452.278asd',
    'Method: POST',
    'Credentials: Basic 028591u3jtndkgwndsdkfjwelfqkjwporjqebhas',
    'Content: Johnathan',
    '2q'
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