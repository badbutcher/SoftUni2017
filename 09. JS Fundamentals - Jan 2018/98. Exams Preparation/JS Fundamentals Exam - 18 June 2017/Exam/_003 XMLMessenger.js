function xmlMessenger(input) {
    let re = new RegExp(/.?(from="[A-Za-z\s\.]+")|.?(to="[A-Za-z\s\.]+").*>([\w,\.!@#$%^&*\(\) '?\\:]+)/, 'g');


}

xmlMessenger('<message to="Bob" from="Alice" timestamp="1497254092">Hey man, what\'s up?</message>');