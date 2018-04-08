const BASE_URL = 'https://baas.kinvey.com/';
const APP_KEY = 'kid_rJTkZ7KcG';
const APP_SECRET = '488eb0d481a34aa0a0a16ce4af3773aa';
const AUTH_HEADERS = {'Authorization': "Basic " + btoa(APP_KEY + ":" + APP_SECRET)};


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
        showAllAds(res);
    }).catch(handleAjaxError);
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

function deleteAd() {
    let id = $(this).parent().parent().attr('id');
    $.ajax({
        method: 'DELETE',
        url: BASE_URL + 'appdata/' + APP_KEY + '/ads/' + id,
        headers: {'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')},
    }).then(function () {
        listAds();
        showView('viewAds');
        showInfo('Ad deleted.');
    }).catch(handleAjaxError);
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