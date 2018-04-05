(function () {
    class Header {
        constructor(id, text) {
            this.id = id;
            this.text = text;
        }
    }

    let authHeaders = [
        new Header('linkListAds', 'List Advertisements'),
        new Header('linkCreateAd', 'Create Advertisement'),
        new Header('linkLogout', 'Logout')
    ];

    let unAuthHeaders = [
        new Header('linkHome', 'Home'),
        new Header('linkLogin', 'Login'),
        new Header('linkRegister', 'Register')
    ];

    window.headers = {
        authHeaders,
        unAuthHeaders
    };
})();