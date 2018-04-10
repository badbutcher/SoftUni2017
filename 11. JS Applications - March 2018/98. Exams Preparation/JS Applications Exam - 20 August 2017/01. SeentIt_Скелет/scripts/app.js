$(() => {
    const app = Sammy('.content', function () {
        this.use('Handlebars', 'hbs');
        this.get('#/index.html', displayHome);
        this.get('#/home', displayHome);
        this.get('#/logout', logoutUser);
        this.get('#/catalog', displayCatalog);

        this.post('#/register', registerUser);
        this.post('#/login', loginUser);


        function displayHome(ctx) {
            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: './templates/header.hbs',
                footer: './templates/footer.hbs',
                loginForm: './templates/loginForm.hbs',
                registerForm: './templates/registerForm.hbs',
            }).then(function () {
                this.partial('./templates/home.hbs')
            });
        }

        function registerUser(ctx) {
            let username = ctx.params.username;
            let password = ctx.params.password;
            let repeatPassword = ctx.params.repeatPass;

            if (username.length < 3 || !username.match(/[a-zA-Z]/)) {
                auth.showError('Username should be at least 3 characters long and should contain only english alphabet letters.')
            }
            else if (password.length < 6 || !password.match(/[a-zA-Z0-9]/)) {
                auth.showError('Password should be at least 6 characters long and should contain only english alphabet letters and digits.')
            }
            else if (password !== repeatPassword) {
                auth.showError('Password are not the same.')
            } else {
                auth.register(username, password)
                    .then(function (userInfo) {
                        auth.saveSession(userInfo);
                        auth.showInfo('User registration successful.');
                        ctx.redirect('#/catalog');
                        //displayCatalog(ctx);
                    }).catch(auth.handleError);
            }
        }

        function loginUser(ctx) {
            let username = ctx.params.username;
            let password = ctx.params.password;

            auth.login(username, password)
                .then(function (userInfo) {
                    auth.saveSession(userInfo);
                    auth.showInfo('Login successful.');
                    ctx.redirect('#/catalog');
                    //displayCatalog(ctx);
                }).catch(auth.handleError);
        }

        function logoutUser(ctx) {
            auth.logout()
                .then(function () {
                    sessionStorage.clear();
                    auth.showInfo('Logout successful.');
                    ctx.redirect('#/home');
                    //displayHome(ctx)
                })
        }

        function displayCatalog(ctx) {
            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');
            let index = 1;
            service.loadPosts()
                .then(function (posts) {
                    for (let post of posts) {
                        post.date = calcTime(post._kmd.ect);
                        post.index = index++;
                        post.isAuthor = post._acl.creator === sessionStorage.getItem('userId');
                    }

                    ctx.posts = posts;
                    ctx.loadPartials({
                        header: './templates/header.hbs',
                        footer: './templates/footer.hbs',
                        navigation: './templates/navigation.hbs',
                        post: './templates/post.hbs',
                    }).then(function () {
                        this.partial('./templates/catalog.hbs')
                    })
                }).catch(auth.handleError);

        }
    });

    function calcTime(dateIsoFormat) {
        let diff = new Date - (new Date(dateIsoFormat));
        diff = Math.floor(diff / 60000);
        if (diff < 1) return 'less than a minute';
        if (diff < 60) return diff + ' minute' + pluralize(diff);
        diff = Math.floor(diff / 60);
        if (diff < 24) return diff + ' hour' + pluralize(diff);
        diff = Math.floor(diff / 24);
        if (diff < 30) return diff + ' day' + pluralize(diff);
        diff = Math.floor(diff / 30);
        if (diff < 12) return diff + ' month' + pluralize(diff);
        diff = Math.floor(diff / 12);
        return diff + ' year' + pluralize(diff);

        function pluralize(value) {
            if (value !== 1) return 's';
            else return '';
        }
    }


    app.run();
});