$(() => {
    const app = Sammy('#container', function () {
        this.use('Handlebars', 'hbs');
        this.get('#/index.html', displayHome);
        this.get('#/home', displayHome);
        this.get('#/logout', logoutUser);
        this.get('#/catalog', displayCatalog);
        this.get('#/newPost', displayCreatePost);
        this.get('#/editPost/post/:postId', displayEditPost);
        this.get('#/deletePost/post/:postId', deletePost);
        this.get('#/myPosts', displayMyPosts);

        this.post('#/register', registerUser);
        this.post('#/login', loginUser);
        this.post('#/createPost', createPost);
        this.post('#/editPost/post', editPost);


        function displayHome(ctx) {
            ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
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
                }).catch(auth.handleError);
        }

        function logoutUser(ctx) {
            auth.logout()
                .then(function () {
                    sessionStorage.clear();
                    auth.showInfo('Logout successful.');
                    ctx.redirect('#/home');
                }).catch(auth.handleError);
        }

        function displayCatalog(ctx) {
            ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
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

    function displayCreatePost(ctx) {
        ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
        ctx.username = sessionStorage.getItem('username');

        ctx.loadPartials({
            header: './templates/header.hbs',
            footer: './templates/footer.hbs',
            navigation: './templates/navigation.hbs'
        }).then(function () {
            this.partial('./templates/createPostForm.hbs')
        });
    }

    function createPost(ctx) {
        let author = sessionStorage.getItem('username');
        let url = ctx.params.url;
        let title = ctx.params.title;
        let image = ctx.params.image;
        let comment = ctx.params.comment;

        if (!url.startsWith('http') || url.length === 0) {
            auth.showError('URL must start with "http" and cant be empty')
        } else if (title.length === 0) {
            auth.showError('Title cant be empty')
        } else {
            service.createPost(author, title, comment, url, image)
                .then(function () {
                    auth.showInfo('Post created.');
                    ctx.redirect('#/catalog')
                })
        }
    }

    function displayEditPost(ctx) {
        let postId = ctx.params.postId;

        service.postsDetails(postId)
            .then(function (post) {
                ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
                ctx.username = sessionStorage.getItem('username');
                ctx.post = post;
                ctx.loadPartials({
                    header: './templates/header.hbs',
                    footer: './templates/footer.hbs',
                    navigation: './templates/navigation.hbs'
                }).then(function () {
                    this.partial('./templates/editPostForm.hbs')
                });
            })
    }

    function editPost(ctx) {
        let postId = ctx.params.postId;
        let author = sessionStorage.getItem('username');
        let url = ctx.params.url;
        let title = ctx.params.title;
        let image = ctx.params.image;
        let comment = ctx.params.description;

        if (!url.startsWith('http') || url.length === 0) {
            auth.showError('URL must start with "http" and cant be empty')
        } else if (title.length === 0) {
            auth.showError('Title cant be empty')
        } else {
            service.editPost(postId, author, title, comment, url, image)
                .then(function () {
                    auth.showInfo(`Post ${title} updated.`);
                    ctx.redirect('#/catalog')
                }).catch(auth.handleError);
        }
    }
    
    function deletePost(ctx) {
        let postId = ctx.params.postId;
        
        service.deletePost(postId)
            .then(function () {
                auth.showInfo('Post deleted.');
                ctx.redirect('#/catalog');
            }).catch(auth.handleError);
    }

    function displayMyPosts(ctx) {
        ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
        ctx.username = sessionStorage.getItem('username');
        let author = sessionStorage.getItem('username');

        let index = 1;
        service.myPosts(author)
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
                    this.partial('./templates/myPosts.hbs')
                });
            })
    }

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