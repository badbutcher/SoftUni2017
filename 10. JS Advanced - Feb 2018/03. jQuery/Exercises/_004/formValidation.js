function validate() {
    let button = $('#submit');
    button.on('click', check);

    let company = $('#company');
    company.on('change', extend);

    function extend(ev) {
        if ($('#company').is(':checked')) {
            $('#companyInfo').css('display', 'inline');
        }
        else {
            $('#companyInfo').css('display', 'none');
        }

        ev.preventDefault();
    }

    function check(ev) {
        let usernameCheck = true;
        let emailCheck = true;
        let passwordCheck = true;
        let confirmPasswordCheck = true;
        let companyNumberCheck = true;

        let username = $('#username').val();
        let email = $('#email').val();
        let password = $('#password').val();
        let confirmPassword = $('#confirm-password').val();
        let companyNumber = Number($('#companyNumber').val());

        let usernameRegex = new RegExp(/^[A-Za-z0-9]{3,20}$/);
        let passwordRegex = new RegExp(/^[\w]{5,15}$/);
        let emailRegex = new RegExp(/.*@.*\..*/);

        if (!usernameRegex.test(username)) {
            usernameCheck = false;
        }

        if (!passwordRegex.test(password)) {
            passwordCheck = false;
        }

        if (!passwordRegex.test(confirmPassword)) {
            confirmPasswordCheck = false;
        }

        if (password !== confirmPassword) {
            passwordCheck = false;
            confirmPasswordCheck = false;
        }

        if (!emailRegex.test(email)) {
            emailCheck = false;
        }

        if (!(companyNumber >= 1000 && companyNumber <= 9999)) {
            companyNumberCheck = false;
        }

        if (!usernameCheck) {
            $('#username').css('border-color', 'red')
        }
        else {
            $('#username').css('border', 'none')
        }

        if (!emailCheck) {
            $('#email').css('border-color', 'red')
        }
        else {
            $('#email').css('border', 'none');
        }

        if (!passwordCheck && !confirmPasswordCheck) {
            $('#password').css('border-color', 'red');
            $('#confirm-password').css('border-color', 'red');
        }
        else {
            $('#password').css('border', 'none');
            $('#confirm-password').css('border', 'none');
        }

        if (!companyNumberCheck) {
            $('#companyNumber').css('border-color', 'red');
        }
        else {
            $('#companyNumber').css('border', 'none');
        }

        if (usernameCheck && emailCheck && password && confirmPasswordCheck) {
            if ($('#company').is(':checked')) {
                if (companyNumberCheck) {
                    $('#valid').css('display', 'inherit');
                }
                else {
                    $('#valid').css('display', 'none');
                }
            }
            else {
                $('#valid').css('display', 'inherit');
            }
        }

        ev.preventDefault();
    }
}