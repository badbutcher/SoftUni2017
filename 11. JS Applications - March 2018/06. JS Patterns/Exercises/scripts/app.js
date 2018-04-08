$(() => {
    const app = Sammy('#main', function () {
        this.use('Handlebars', 'hbs');
        this.get('#/index.html', displayHome);
        this.get('#/home', displayHome);
        this.get('#/about', displayAbout);
        this.get('#/register', displayRegister);
        this.get('#/login', displayLogin);
        this.get('#/logout', logoutUser);
        this.get('#/catalog', displayCatalog);
        this.get('#/create', displayCreateTeam);
        this.get('#/catalog/:teamId', displayTeamDetails);
        this.get('#/join/:teamId', joinTeam);
        this.get('#/leave', leaveTeam);
        this.get('#/edit/:teamId', displayEditTeam);

        this.post('#/register', registerUser);
        this.post('#/login', loginUser);
        this.post('#/create', createTeam);
        this.post('#/edit/:teamId', editTeam);


        function displayHome(ctx) {
            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
            }).then(function () {
                this.partial('./templates/home/home.hbs')
            });
        }

        function displayAbout(ctx) {
            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
            }).then(function () {
                this.partial('./templates/about/about.hbs')
            });
        }

        function displayRegister(ctx) {
            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                registerForm: './templates/register/registerForm.hbs',
            }).then(function () {
                this.partial('./templates/register/registerPage.hbs')
            });
        }

        function registerUser(ctx) {
            let username = ctx.params.username;
            let password = ctx.params.password;
            let repeatPassword = ctx.params.repeatPassword;

            if (password !== repeatPassword) {
                auth.showError('Password are not the same.')
            } else {
                auth.register(username, password)
                    .then(function (userInfo) {
                        auth.saveSession(userInfo);
                        auth.showInfo('Logged in');
                        displayHome(ctx);
                    }).catch(auth.handleError);
            }
        }

        function displayLogin(ctx) {
            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                loginForm: './templates/login/loginForm.hbs',
            }).then(function () {
                this.partial('./templates/login/loginPage.hbs')
            });
        }

        function loginUser(ctx) {
            let username = ctx.params.username;
            let password = ctx.params.password;

            auth.login(username, password)
                .then(function (userInfo) {
                    auth.saveSession(userInfo);
                    auth.showInfo('Logged in');
                    displayHome(ctx);
                }).catch(auth.handleError);
        }

        function logoutUser(ctx) {
            auth.logout()
                .then(function () {
                    sessionStorage.clear();
                    auth.showInfo('Logged out');
                    displayHome(ctx)
                })
        }

        function displayCatalog(ctx) {
            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            teamsService.loadTeams()
                .then(function (teams) {
                    ctx.hasNoTeam = sessionStorage.getItem('teamId') === null || sessionStorage.getItem('teamId') === 'undefined';
                    ctx.teams = teams;
                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        team: './templates/catalog/team.hbs',
                    }).then(function () {
                        this.partial('./templates/catalog/teamCatalog.hbs')
                    });
                })
        }

        function displayCreateTeam(ctx) {
            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                createForm: './templates/create/createForm.hbs',
            }).then(function () {
                this.partial('./templates/create/createPage.hbs')
            });
        }

        function createTeam(ctx) {
            let name = ctx.params.name;
            let comment = ctx.params.comment;

            teamsService.createTeam(name, comment)
                .then(function (team) {
                    teamsService.joinTeam(team._id)
                        .then(function (userInfo) {
                            auth.saveSession(userInfo);
                            auth.showInfo('Team created');
                            displayCatalog(ctx);
                        }).catch(auth.handleError)
                }).catch(auth.handleError);
        }

        function displayTeamDetails(ctx) {
            let teamId = ctx.params.teamId.substr(1);

            teamsService.loadTeamDetails(teamId)
                .then(function (team) {
                    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
                    ctx.username = sessionStorage.getItem('username');
                    ctx.teamId = teamId;
                    ctx.name = team.name;
                    ctx.comment = team.comment;
                    ctx.isOnTeam = team._id === sessionStorage.getItem('teamId');
                    ctx.isAuthor = team._acl.creator === sessionStorage.getItem('userId');
                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        teamControls: './templates/catalog/teamControls.hbs',
                    }).then(function () {
                        this.partial('./templates/catalog/details.hbs')
                    })
                }).catch(auth.handleError);
        }

        function joinTeam(ctx) {
            let teamId = ctx.params.teamId.substr(1);

            teamsService.joinTeam(teamId)
                .then(function (user) {
                    auth.saveSession(user);
                    auth.showInfo('You join this team');
                    displayCatalog(ctx);
                }).catch(auth.handleError);
        }

        function leaveTeam(ctx) {
            teamsService.leaveTeam()
                .then(function (user) {
                    auth.saveSession(user);
                    auth.showInfo('You left this team');
                    displayCatalog(ctx);
                }).catch(auth.handleError);
        }

        function displayEditTeam(ctx) {
            let teamId = ctx.params.teamId.substr(1);
            teamsService.loadTeamDetails(teamId)
                .then(function (team) {
                    ctx.teamId = teamId;
                    ctx.name = team.name;
                    ctx.comment = team.comment;
                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        editForm: './templates/edit/editForm.hbs'
                    }).then(function () {
                        this.partial('./templates/edit/editPage.hbs')
                    })
                }).catch(auth.handleError);

        }

        function editTeam(ctx) {
            let teamId = ctx.params.teamId.substr(1);
            let teamName = ctx.params.name;
            let teamComment = ctx.params.comment;

            teamsService.edit(teamId, teamName, teamComment)
                .then(function () {
                    auth.showInfo('You edited this team');
                    displayCatalog(ctx);
                })
        }
    });

    app.run();
});