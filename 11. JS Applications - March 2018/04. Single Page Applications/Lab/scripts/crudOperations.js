const BASE_URL = 'https://baas.kinvey.com/';
const APP_KEY = 'kid_BJyKLJd9G';
const APP_SECRET = 'a67198f9c00142f5b1b8b7d4ccb68f1a';
const AUTH_HEADERS = {'Authorization': "Basic " + btoa(APP_KEY + ":" + APP_SECRET)};
const BOOKS_PER_PAGE = 10;

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
        signInUser(res, 'Registered successfully')
    }).catch(handleAjaxError);
}

function listBooks() {
    $.ajax({
        method: 'GET',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books',
        headers: {'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')},
    }).then(function (res) {
        showView('viewBooks');
        displayPaginationAndBooks(res.reverse())
    }).catch(handleAjaxError);
}


function createBook() {
    let form = $('#viewCreateBook').find('input');
    let title = form[0].value;
    let author = form[1].value;
    let description = $('#viewCreateBook').find('textarea')[0].value;

    let data = {
        'title': title,
        'author': author,
        'description': description
    };

    $.ajax({
        method: 'POST',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books',
        headers: {'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')},
        data: data
    }).then(showInfo('Book created.')).catch(handleAjaxError);
}

function deleteBook(book) {
    $.ajax({
        method: 'DELETE',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books/' + book._id,
        headers: {'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')},
    }).then(function () {
        showInfo('Book deleted.');
        showView('viewBooks');
    }).catch(handleAjaxError);
}

function loadBookForEdit(book) {
    showView('viewEditBook');
    let form = $('#formEditBook').find('input');
    form[0].value = book._id;
    form[1].value = book.title;
    form[2].value = book.author;
    $('#formEditBook').find('textarea')[0].value = book.description;
}

function editBook() {
    let form = $('#formEditBook').find('input');
    console.log(form);
    let id = form[0].value;
    let title = form[1].value;
    let author = form[2].value;
    let description = $('#formEditBook').find('textarea')[0].value;

    let data = {
        'title': title,
        'author': author,
        'description': description
    };

    $.ajax({
        method: 'PUT',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books/' + id,
        headers: {'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')},
        data: data
    }).then(function () {
        listBooks();
        showInfo('Book edited.');
        showView('viewBooks');
    }).catch(handleAjaxError);
}

// function saveAuthInSession(userInfo) {
//     // TODO
// }

function logoutUser() {
    sessionStorage.clear();
    showHomeView();
    showHideMenuLinks();
    showInfo('Logged out')
}

function signInUser(res, message) {
    sessionStorage.setItem('username', res.username);
    sessionStorage.setItem('authToken', res._kmd.authtoken);
    sessionStorage.setItem('userId', res._id);
    showHomeView();
    showHideMenuLinks();
    showInfo(message)
}

function displayPaginationAndBooks(books) {
    let pagination = $('#pagination-demo');
    if (pagination.data("twbs-pagination")) {
        pagination.twbsPagination('destroy')
    }
    pagination.twbsPagination({
        totalPages: Math.ceil(books.length / BOOKS_PER_PAGE),
        visiblePages: 5,
        next: 'Next',
        prev: 'Prev',
        onPageClick: function (event, page) {
            let table = $('#books > table');
            table.find('tr').each((index, el) => {
                if(index > 0) {
                    $(el).remove()
                }
            });
            let startBook = (page - 1) * BOOKS_PER_PAGE;
            let endBook = Math.min(startBook + BOOKS_PER_PAGE, books.length);
            $(`a:contains(${page})`).addClass('active');
            for (let i = startBook; i < endBook; i++) {
                let tr = $('<tr>');
                table.append($(tr).append($(`<td>${books[i].title}</td>`))
                    .append($(`<td>${books[i].author}</td>`))
                    .append($(`<td>${books[i].description}</td>`)));

                if(books[i]._acl.creator === sessionStorage.getItem('userId')) {
                    $(tr).append(
                        $(`<td>`).append(
                            $(`<a href="#">[Edit]</a>`).on('click', function () {
                                loadBookForEdit(books[i])
                            })
                        ).append(
                            $(`<a href="#">[Delete]</a>`).on('click', function () {
                                deleteBook(books[i])
                            })
                        )
                    )
                }
            }
        }
    })
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