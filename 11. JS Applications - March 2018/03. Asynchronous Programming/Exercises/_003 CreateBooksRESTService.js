function loadData() {
    const URL = 'https://baas.kinvey.com/appdata/kid_Skss9lHqf/books';
    const USERNAME = 'test';
    const PASSWORD = 'test';
    const base64auth = btoa(USERNAME + ':' + PASSWORD);
    const authHeaders = {'Authorization': 'Basic ' + base64auth};

    $('#addBook').on('click', addBookAjax);
    $('#reload').on('click', loadPage);

    function loadPage() {
        $('#mainTable').empty();
        $.ajax({
            method: 'GET',
            url: URL,
            headers: authHeaders
        }).then(loadAllBooks)
            .catch(errorFunc);
    }

    function loadAllBooks(suc) {
        let table = $('#mainTable');
        for (let obj of suc) {
            let tr = $('<tr>').attr('id', obj._id);
            let title = obj.title;
            let author = obj.author;
            let isbn = obj.isbn;
            let tableTitle = $('<td>').text(title);
            let tableAuthor = $('<td>').text(author);
            let tableIsbn = $('<td>').text(isbn);
            let tableDeleteButton = $('<td>').append($('<button>').text('Delete').on('click', deleteBook));
            let tableUpdateButton = $('<td>').append($('<button>').text('Update').on('click', updateBook));
            tr.append(tableTitle).append(tableAuthor).append(tableIsbn).append(tableDeleteButton).append(tableUpdateButton);
            table.append(tr);
        }

        function deleteBook() {
            let id = $(this).parent().parent();
            $.ajax({
                method: 'DELETE',
                url: URL + '/' + id.attr('id'),
                headers: authHeaders
            }).then(loadPage)
                .catch(errorFunc);
        }

        function updateBook() {
            let id = $(this).parent().parent();
            let title = $('#title').val();
            let author = $('#author').val();
            let isbn = $('#isbn').val();
            let inputBody = {
                'title': title,
                'author': author,
                'isbn': isbn
            };

            $.ajax({
                method: 'PUT',
                url: URL + '/' + id.attr('id'),
                data: inputBody,
                headers: authHeaders
            }).then(loadPage)
                .catch(errorFunc);
        }
    }

    function addBookAjax() {
        let title = $('#title').val();
        let author = $('#author').val();
        let isbn = $('#isbn').val();
        let inputBody = {
            'title': title,
            'author': author,
            'isbn': isbn
        };

        $.ajax({
            method: 'POST',
            url: URL,
            data: inputBody,
            headers: authHeaders,
        }).then(loadPage)
            .catch(errorFunc);
    }

    function errorFunc(err) {
        console.log(err);
    }
}