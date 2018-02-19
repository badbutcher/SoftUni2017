function createBook(selector, bookTitle, author, isbn) {
    let bookGenerator = (function () {
        let currentId = 1;
        return function (selector, bookTitle, author, isbn) {
            let selectorData = $(selector);
            let div = $('<div>');
            let pTitle = $('<p>');
            let pAuthor = $('<p>');
            let pIsbn = $('<p>');
            let buttonSelect = $('<button>');
            let buttonDeselect = $('<button>');

            div.attr('id', `book${currentId++}`);
            div.css('border', 'medium none');

            pTitle.addClass('title');
            pTitle.text(bookTitle);

            pAuthor.addClass('author');
            pAuthor.text(author);

            pIsbn.addClass('isbn');
            pIsbn.text(isbn);

            buttonSelect.text('Select');
            buttonDeselect.text('Deselect');

            div.append(pTitle);
            div.append(pAuthor);
            div.append(pIsbn);
            div.append(buttonSelect);
            div.append(buttonDeselect);
            selectorData.append(div);

            buttonSelect.on('click', function () {
                div.css('border', '2px solid blue');
            });

            buttonDeselect.on('click', function () {
                div.css('border', 'none');
            });
        }
    }());

    bookGenerator(selector, bookTitle, author, isbn);
}