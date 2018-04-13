$(() => {
    const app = Sammy('#main', function () {
        this.use('Handlebars', 'hbs');
        this.get('skeleton.html', loginUserForm);
        this.get('#/login', loginUserForm);
        this.get('#/register', registerUserForm);
        this.get('#/logout', logoutUser);
        this.get('#/feed', displayChirpsPost);
        this.get('#/myFeed', displayMyFeed);

        this.post('#/register', registerUser);
        this.post('#/login', loginUser);
        this.post('#/chirp', postChirp);

        function registerUserForm(ctx) {
            ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
            }).then(function () {
                this.partial('./templates/registerForm.hbs')
            });
        }

        function loginUserForm(ctx) {
            ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
            }).then(function () {
                this.partial('./templates/loginForm.hbs')
            });
        }

        function registerUser(ctx) {
            let username = ctx.params.username;
            let password = ctx.params.password;
            let repeatPassword = ctx.params.repeatPass;

            if (username.length < 5) {
                auth.showError('Username should be at least 5 characters long.')
            }
            else if (password.length === 0) {
                auth.showError('Password cant be empty.')
            }
            else if (password !== repeatPassword) {
                auth.showError('Password are not the same.')
            } else {
                auth.register(username, password)
                    .then(function (userInfo) {
                        auth.saveSession(userInfo);
                        auth.showInfo('User registration successful.');
                        ctx.redirect('#/feed');
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
                    ctx.redirect('#/feed');
                }).catch(auth.handleError);
        }

        function logoutUser(ctx) {
            auth.logout()
                .then(function () {
                    sessionStorage.clear();
                    auth.showInfo('Logout successful.');
                    ctx.redirect('#/login');
                }).catch(auth.handleError);
        }


        async function displayChirpsPost(ctx) {
            let subs = JSON.parse(sessionStorage.getItem('subscriptions')).map(e => `"${e}"`);
            ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            for (let obj of subs) {
                let user = obj.replace(/^"(.*)"$/, '$1');
                service.getUserChrips(user);
            }

            let myChirps = 0;
            let myFollowers = 0;
            await service.getUserFollowers(ctx.username)
                .then(function (res) {
                    myFollowers = res.length;
                });

            await service.getUserChrips(ctx.username)
                .then(function (res) {
                    myChirps = res.length;
                });

            await service.listChrips(subs)
                .then(function (chirps) {
                    for (let chirp of chirps) {
                        chirp.date = calcTime(chirp._kmd.ect);
                        chirp.isAuthor = chirp._acl.creator === sessionStorage.getItem('userId');
                    }

                    ctx.chirps = chirps;
                    ctx.myChirps = myChirps;
                    ctx.following = subs.length;
                    ctx.followers = myFollowers;

                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        navigation: './templates/common/navigation.hbs',
                        chirp: './templates/chirp.hbs',
                    }).then(function () {
                        this.partial('./templates/feed.hbs');
                    })
                })
        }

        function postChirp(ctx) {
            let author = sessionStorage.getItem('username');
            let text = ctx.params.text;

            if (text.length > 150 || text.length === 0) {
                auth.showError('text must be between 0 and 150 chars')
            } else {
                service.createChrip(author, text)
                    .then(function () {
                        auth.showInfo('Chirp published.');
                        ctx.redirect('#/feed')
                    })
            }
        }
        
        async function displayMyFeed(ctx) {
            ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');
            let subs = JSON.parse(sessionStorage.getItem('subscriptions')).map(e => `"${e}"`);
            let myChirps = 0;
            let myFollowers = 0;

            await service.getUserFollowers(ctx.username)
                .then(function (res) {
                    myFollowers = res.length;
                });

            await service.getUserChrips(ctx.username)
                .then(function (res) {
                    myChirps = res.length;
                });

            await service.myChirps(ctx.username)
                .then(function (chirps) {
                    for (let chirp of chirps) {
                        chirp.date = calcTime(chirp._kmd.ect);
                        chirp.isAuthor = chirp._acl.creator === sessionStorage.getItem('userId');
                    }

                    ctx.chirps = chirps;
                    ctx.myChirps = myChirps;
                    ctx.following = subs.length;
                    ctx.followers = myFollowers;

                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        navigation: './templates/common/navigation.hbs',
                        chirp: './templates/chirp.hbs',
                    }).then(function () {
                        this.partial('./templates/myChirps.hbs');
                    })
                })
            
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