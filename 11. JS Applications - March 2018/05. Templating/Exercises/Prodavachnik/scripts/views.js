function attachAllEvents() {
    $('#linkHome').on('click', showHomeView);
    $('#linkLogin').on('click', showLoginView);
    $('#linkRegister').on('click', showRegisterView);
    $('#linkListAds').on('click', listAds);
    $('#linkCreateAd').on('click', showCreateAdView);
    $('#linkLogout').on('click', logoutUser);

    $('#buttonLoginUser').on('click', loginUser);
    $('#buttonRegisterUser').on('click', registerUser);
    $('#buttonCreateAd').on('click', createAd);
    $('#buttonEditAd').on('click', editAd);
    $('form').on('submit', function (event) {
        event.preventDefault()
    });

    $('#infoBox, #errorBox').on('click', function () {
        $(this).fadeOut();
    });

    $(document).on({
        ajaxStart: function () {
            $('#loadingBox').show();
        },
        ajaxStop: function () {
            $('#loadingBox').hide();
        }
    })
}

function showView(viewName) {
    $('main > section').hide();
    $('#' + viewName).show();
}

function showHideMenuLinks() {
    showHomeView();
    $('#viewHome').show();
    if (sessionStorage.getItem('authToken') === null) {
        $('#linkHome').show();
        $('#linkLogin').show();
        $('#linkRegister').show();
        $('#linkListAds').hide();
        $('#linkCreateAd').hide();
        $('#linkLogout').hide();
        $('#loggedInUser').text('Welcome, ' + sessionStorage.getItem('username') + '!');
    } else {
        $('#linkHome').hide();
        $('#linkLogin').hide();
        $('#linkRegister').hide();
        $('#linkListAds').show();
        $('#linkCreateAd').show();
        $('#linkLogout').show();
        $('#loggedInUser').text('Welcome, ' + sessionStorage.getItem('username') + '!');
    }
}

function showInfo(message) {
    let infoBox = $('#infoBox');
    infoBox.text(message);
    infoBox.show();
    setTimeout(function () {
        $('#infoBox').fadeOut();
    }, 3000)
}

function showError(errorMsg) {
    let errorBox = $('#errorBox');
    errorBox.text('Error: ' + errorMsg);
    errorBox.show();
}

async function showHomeView() {
    let home = await $.get('./templates/viewHome.hbs');
    let template = Handlebars.compile(home);

    let html = template();
    $('#viewHome').html(html);
    showView('viewHome');
    attachAllEvents();
}

async function showLoginView() {
    let login = await $.get('./templates/viewLogin.hbs');
    let template = Handlebars.compile(login);

    let html = template();
    $('#viewLogin').html(html);
    $('#formLogin').trigger('reset');
    showView('viewLogin');
    attachAllEvents();
}

async function showRegisterView() {
    let login = await $.get('./templates/viewRegister.hbs');
    let template = Handlebars.compile(login);

    let html = template();
    $('#viewRegister').html(html);
    $('#formRegister').trigger('reset');
    showView('viewRegister');
    attachAllEvents();
}

async function showAllAds(ads) {
    let allAds = await $.get('./templates/viewAds.hbs');
    let template = Handlebars.compile(allAds);
    for (let i = 0; i < ads.length; i++) {
        if (ads[i]._acl.creator === sessionStorage.getItem('userId')) {
            ads[i].isAuthor = true;
        }
    }

    let context = {
        ads
    };

    let html = template(context);
    $('#viewAds').html(html);

    $('.deleteAd').on('click', deleteAd);
    $('.editAd').on('click', showAdForEdit);
    $('.viewAd').on('click', showAdInfoView);
    showView('viewAds');
    attachAllEvents();
}


async function showAdForEdit() {
    let id = $(this).parent().parent().attr('id');
    let ad = await $.get('./templates/viewEditAd.hbs');
    let template = Handlebars.compile(ad);
    let context = {
        id: id
    };

    let html = template(context);
    $('#viewEditAd').html(html);
    showView('viewEditAd');
    attachAllEvents();
}

async function showAdInfoView() {
    let ad = await $.get('./templates/viewAdInfo.hbs');
    let template = Handlebars.compile(ad);

    let html = template();
    $('#viewSingleAd').html(html);
    showView('viewSingleAd');
    attachAllEvents();
}

async function showCreateAdView() {
    let ad = await $.get('./templates/viewCreateAd.hbs');
    let template = Handlebars.compile(ad);

    let html = template();
    $('#viewCreateAd').html(html);
    $('#formCreateAd').trigger('reset');
    showView('viewCreateAd');
    attachAllEvents();
}