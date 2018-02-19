function validate() {
    let button = $('#submit');
    button.on('click', function () {
        let username = $('#username').val();
        let email = $('#email').val();
        let password = $('#password').val();
        let confirmPassword = $('#confirm-password').val();

        let usernameRegex = new RegExp(/[A-Za-z0-9]{3,20}/, 'g');
        let passwordRegex = new RegExp(/[\w]{5,15}/, 'g');
        let emailRegex = new RegExp(/.*@.*\..*/, 'g');

        if (!usernameRegex.test(username)) {
            $('#username').css('border-color', 'red')
        }

        if (!passwordRegex.test(password)) {
            $('#password').css('border-color', 'red')
        }

        if (!passwordRegex.test(confirmPassword)) {
            $('#confirm-password').css('border-color', 'red')
        }

        if (!password !== confirmPassword) {
            $('#password').css('border-color', 'red')
            $('#confirm-password').css('border-color', 'red')
        }

        if (!emailRegex.test(email)) {
            $('#email').css('border-color', 'red')
        }
    })
}
