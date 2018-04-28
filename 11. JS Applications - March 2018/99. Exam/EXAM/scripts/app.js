$(() => {
    const app = Sammy('#container', function () {
        this.use('Handlebars', 'hbs');
        this.get('index.html', displayHome);
        this.get('#/home', displayHome);
        this.get('#/logout', logoutUser);
        this.get('#/catalog', displayCatalog);
        this.get('#/delete/:id', deleteEntry);
        this.get('#/myReceipts', displayMyReceipts);

        this.post('#/register', registerUser);
        this.post('#/login', loginUser);
        this.post('#/catalog', addEntry);
        this.post('#/checkOut', checkOut);

        function displayHome(ctx) {
            ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs'
            }).then(function () {
                this.partial('./templates/home.hbs')
            });
        }

        function registerUser(ctx) {
            let username = ctx.params.username;
            let password = ctx.params.password;
            let repeatPassword = ctx.params.repeatPass;

            if (username.length < 5) {
                auth.showError('Username should be at least 5 characters long.')
            }
            else if (password.length <= 0) {
                auth.showError('Password cant be empty.')
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

        async function displayCatalog(ctx) {
            ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');
            let userId = sessionStorage.getItem('userId');
            let found = false;
            await service.getActiveReceipt(userId)
                .then(function (data) {
                    for (let obj of data) {
                        if (obj.active && obj._acl.creator === userId) {
                            found = true;
                            sessionStorage.setItem('userReceipt', obj._id);
                            break;
                        }
                    }

                    if (!found) {
                        service.createReceipt().then(
                            function (data) {
                                sessionStorage.setItem('userReceipt', data._id);
                            }
                        );
                    }
                });

            let receiptId = sessionStorage.getItem('userReceipt');
            await service.getEntriesByReceiptId(receiptId)
                .then(function (entries) {
                    let allTotal = 0;
                    for (let obj of entries) {
                        ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
                        ctx.username = sessionStorage.getItem('username');
                        obj.total = (obj.price * obj.qty).toFixed(2);
                        allTotal += obj.price * obj.qty;
                    }

                    ctx.allTotal = allTotal.toFixed(2);
                    ctx.entries = entries;
                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        navigation: './templates/common/navigation.hbs',
                        entrie: './templates/entrie.hbs',
                    }).then(function () {
                        this.partial('./templates/catalog.hbs');
                    })
                })
        }

        function addEntry(ctx) {
            ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');

            let receiptId = sessionStorage.getItem('userReceipt');
            let type = ctx.params.type;
            let qty = Number(ctx.params.qty);
            let price = Number(ctx.params.price);
            if (type.length <= 0) {
                auth.showError('Type cant be empty.')
            }
            else if (qty <= 0) {
                auth.showError('Quantity must be a positive number.')
            }
            else if (price <= 0) {
                auth.showError('Price must be a positive number.')
            } else {
                service.addEntry(type, qty, price, receiptId)
                    .then(function () {
                        auth.showInfo('Entry added');
                        ctx.redirect('#/catalog');
                    })
            }
        }

        function deleteEntry(ctx) {
            let entrieId = ctx.params.id.substr(1);

            service.deleteEntry(entrieId)
                .then(function () {
                    auth.showInfo('Entrie deleted.');
                    ctx.redirect('#/catalog');
                });
        }

        async function checkOut(ctx) {
            ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');
            let receiptId = sessionStorage.getItem('userReceipt');

            let productCount = 0;
            let total = 0;

            await service.getEntriesByReceiptId(receiptId)
                .then(function (entries) {
                    for (let obj of entries) {
                        total += obj.price * obj.qty;
                    }

                    productCount = entries.length;
                });

            await service.commitReceipt(receiptId, "false", productCount, total)
                .then(function () {
                    auth.showInfo('Receipt checked out');
                    sessionStorage.removeItem('userReceipt');
                    ctx.redirect('#/catalog')
                });
        }

        // function checkOut(ctx) {
        //     ctx.isAuth = sessionStorage.getItem('authtoken') !== null;
        //     ctx.username = sessionStorage.getItem('username');
        //     let receiptId = sessionStorage.getItem('userReceipt');
        //
        //     let productCount = 0;
        //     let total = 0;
        //
        //     let p1 = new Promise(function () {
        //         service.getEntriesByReceiptId(receiptId)
        //             .then(function (entries) {
        //                 for (let obj of entries) {
        //                     total += obj.price * obj.qty;
        //                 }
        //
        //                 productCount = entries.length;
        //             })
        //     });
        //
        //     let p2 = new Promise(function () {
        //         service.commitReceipt(receiptId, "false", productCount, total)
        //             .then(function () {
        //                 auth.showInfo('Receipt checked out');
        //                 sessionStorage.removeItem('userReceipt');
        //
        //                 ctx.redirect('#/catalog')
        //
        //             })
        //     });
        //
        //     Promise.all([p1, p2]).then(function (asd) {
        //         console.log(asd);
        //     });
        //
        // }

        async function displayMyReceipts(ctx) {

        }
    });

    app.run();
});