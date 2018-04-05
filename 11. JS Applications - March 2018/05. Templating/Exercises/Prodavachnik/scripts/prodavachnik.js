const BASE_URL = 'https://baas.kinvey.com/';
const APP_KEY = 'kid_rJTkZ7KcG';
const APP_SECRET = '488eb0d481a34aa0a0a16ce4af3773aa';
const AUTH_HEADERS = {'Authorization': "Basic " + btoa(APP_KEY + ":" + APP_SECRET)};

function startApp() {
    showHideMenuLinks();
    showView('viewHome');
    attachAllEvents();
}

function registerUser() {
    let form = $('#formRegister').find('input');
    let username = form[0].value;
    let password = form[1].value;
    let data = {
        'username': username,
        'password': password
    };

    $.ajax({
        method: 'POST',
        url: BASE_URL + 'user/' + APP_KEY + '/',
        headers: AUTH_HEADERS,
        data: data
    }).then(function (res) {
        signInUser(res, 'Logged in successfully')
    }).catch(handleAjaxError);
}

function loginUser() {
    let form = $('#formLogin').find('input');
    let username = form[0].value;
    let password = form[1].value;
    let data = {
        'username': username,
        'password': password
    };

    $.ajax({
        method: 'POST',
        url: BASE_URL + 'user/' + APP_KEY + '/login',
        headers: AUTH_HEADERS,
        data: data
    }).then(function (res) {
        signInUser(res, 'Logged in successfully')
    }).catch(handleAjaxError);
}

function logoutUser() {
    sessionStorage.clear();
    showHomeView();
    showHideMenuLinks();
    showInfo('Logged out')
}

function createAd() {
    let formId = $('#viewCreateAd');
    let form = formId.find('input');
    let title = form[0].value;
    let datePublished = form[1].value;
    let price = form[2].value;
    let image = form[3].value;
    let description = formId.find('textarea')[0].value;
    let publisher = sessionStorage.getItem('username');

    let data = {
        'title': title,
        'datePublished': datePublished,
        'price': price,
        'description': description,
        'publisher': publisher,
        'image': image
    };

    $.ajax({
        method: 'POST',
        url: BASE_URL + 'appdata/' + APP_KEY + '/ads',
        headers: {'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')},
        data: data
    }).then(
        function () {
            showView('viewAds');
            showInfo('Add created.');
        }
    ).catch(handleAjaxError);
}

function listAds() {
    $.ajax({
        method: 'GET',
        url: BASE_URL + 'appdata/' + APP_KEY + '/ads',
        headers: {'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')},
    }).then(function (res) {
        showView('viewAds');
        displayAds(res.reverse())
    }).catch(handleAjaxError);
}

function loadAdForEdit(ad) {
    showView('viewEditAd');
    let formId = $('#formEditAd');
    let form = formId.find('input');
    form[0].value = ad._id;
    form[2].value = ad.title;
    form[3].value = ad.datePublished;
    form[4].value = ad.price;
    form[5].value = ad.image;
    formId.find('textarea')[0].value = ad.description;
}

function editAd() {
    let formId = $('#formEditAd');
    let form = formId.find('input');

    let id = form[0].value;
    let title = form[2].value;
    let datePublished = form[3].value;
    let price = form[4].value;
    let image = form[5].value;
    let description = formId.find('textarea')[0].value;
    let publisher = sessionStorage.getItem('username');

    let data = {
        'title': title,
        'datePublished': datePublished,
        'price': price,
        'description': description,
        'publisher': publisher,
        'image': image
    };

    $.ajax({
        method: 'PUT',
        url: BASE_URL + 'appdata/' + APP_KEY + '/ads/' + id,
        headers: {'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')},
        data: data
    }).then(function () {
        listAds();
        showView('viewAds');
        showInfo('Ad edited.');
    }).catch(handleAjaxError);
}

function deleteAd(ad) {
    $.ajax({
        method: 'DELETE',
        url: BASE_URL + 'appdata/' + APP_KEY + '/ads/' + ad._id,
        headers: {'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')},
    }).then(function () {
        listAds();
        showView('viewAds');
        showInfo('Ad deleted.');
    }).catch(handleAjaxError);
}

function viewAd(ad) {
    let section = $('#viewSingleAd').empty();
    let title = $('<h3>').text('Title').append($('<div>').text(`${ad.title}`));
    let description = $('<h3>').text('Description').append($('<div>').text(`${ad.description}`));
    let publisher = $('<h3>').text('Publisher').append($('<div>').text(`${ad.publisher}`));
    let datePublished = $('<h3>').text('Date Published').append($('<div>').text(`${ad.datePublished}`));
    let price = $('<h3>').text('Price').append($('<div>').text(`${ad.price}`));
    let image = $('<img>').attr('src', `${ad.image}`);
    section.append(title)
        .append(description)
        .append(publisher)
        .append(datePublished)
        .append(price)
        .append(image);

    showView('viewSingleAd');
}

function displayAds(ads) {
    let table = $('#ads').find('> table');
    table.find('tr').each((index, el) => {
        if (index > 0) {
            $(el).remove()
        }
    });

    for (let i = 0; i < ads.length; i++) {
        let tr = $('<tr>');
        table.append($(tr).append($(`<td>${ads[i].title}</td>`))
            .append($(`<td>${ads[i].publisher}</td>`))
            .append($(`<td>${ads[i].description}</td>`))
            .append($(`<td>${ads[i].price}</td>`))
            .append($(`<td>${ads[i].datePublished}</td>`)));

        if (ads[i]._acl.creator === sessionStorage.getItem('userId')) {
            $(tr).append(
                $(`<td>`).append(
                    $(`<a href="#">[Edit]</a>`).on('click', function () {
                        loadAdForEdit(ads[i])
                    })
                ).append(
                    $(`<a href="#">[Delete]</a>`).on('click', function () {
                        deleteAd(ads[i])
                    })
                ).append(
                    $(`<a href="#">[Read More]</a>`).on('click', function () {
                        viewAd(ads[i])
                    })
                )
            )
        }
    }
}

function attachAllEvents() {
    // Bind the navigation menu links
    $("#linkHome").on('click', showHomeView);
    $("#linkLogin").on('click', showLoginView);
    $("#linkRegister").on('click', showRegisterView);
    $("#linkListAds").on('click', listAds);
    $("#linkCreateAd").on('click', showCreateAdView);
    $("#linkLogout").on('click', logoutUser);

    // Bind the form submit buttons
    $("#buttonLoginUser").on('click', loginUser);
    $("#buttonRegisterUser").on('click', registerUser);
    $("#buttonCreateAd").on('click', createAd);
    $("#buttonEditAd").on('click', editAd);
    $("form").on('submit', function (event) {
        event.preventDefault()
    });

    // Bind the info / error boxes
    $("#infoBox, #errorBox").on('click', function () {
        $(this).fadeOut();
    });

    // Attach AJAX "loading" event listener
    $(document).on({
        ajaxStart: function () {
            $("#loadingBox").show();
        },
        ajaxStop: function () {
            $("#loadingBox").hide();
        }
    })
}

function showView(viewName) {
    $('main > section').hide(); // Hide all views
    $('#' + viewName).show(); // Show the selected view only
}

function showHideMenuLinks() {
    $("#viewHome").show();
    if (sessionStorage.getItem('authToken') === null) { // No logged in user
        $("#linkHome").show();
        $("#linkLogin").show();
        $("#linkRegister").show();
        $("#linkListAds").hide();
        $("#linkCreateAd").hide();
        $("#linkLogout").hide();
        $('#loggedInUser').text("Welcome, " + sessionStorage.getItem('username') + "!");
    } else { // We have logged in user
        $("#linkHome").hide();
        $("#linkLogin").hide();
        $("#linkRegister").hide();
        $("#linkListAds").show();
        $("#linkCreateAd").show();
        $("#linkLogout").show();
        $('#loggedInUser').text("Welcome, " + sessionStorage.getItem('username') + "!");
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
    errorBox.text("Error: " + errorMsg);
    errorBox.show();
}

function showHomeView() {
    showView('viewHome');
}

function showLoginView() {
    showView('viewLogin');
    $('#formLogin').trigger('reset');
}

function showRegisterView() {
    $('#formRegister').trigger('reset');
    showView('viewRegister');
}

function showCreateAdView() {
    $('#formCreateAd').trigger('reset');
    showView('viewCreateAd');
}

function signInUser(res, message) {
    sessionStorage.setItem('username', res.username);
    sessionStorage.setItem('authToken', res._kmd.authtoken);
    sessionStorage.setItem('userId', res._id);
    showHomeView();
    showHideMenuLinks();
    showInfo(message)
}

function handleAjaxError(response) {
    let errorMsg = JSON.stringify(response);
    if (response.readyState === 0) {
        errorMsg = "Cannot connect due to network error.";
    }

    if (response.responseJSON && response.responseJSON.description) {
        errorMsg = response.responseJSON.description;
    }

    showError(errorMsg)
}