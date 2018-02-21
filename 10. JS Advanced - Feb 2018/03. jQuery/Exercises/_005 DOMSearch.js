function domSearch(selector, isCaseSensitive) {
    let eDiv = $('<div>');
    let eLabel = $('<label>');
    let eInput = $('<input>');
    let eA = $('<a>');
    let selectorData = $(selector);
    eA.text('Add');
    eA.addClass('button');
    eA.on('click', add);
    eInput.attr('id', 'addItem');
    eLabel.text('Enter text: ');
    eLabel.append(eInput);
    eDiv.addClass('add-controls');
    eDiv.append(eLabel);
    eDiv.append(eA);
    selectorData.append(eDiv);

    let sDiv = $('<div>');
    let sLabel = $('<label>');
    let sInput = $('<input>');
    sInput.attr('id', 'searchItem');
    sInput.on('input', search);
    sLabel.text('Search: ');
    sLabel.append(sInput);
    sDiv.addClass('search-controls');
    sDiv.append(sLabel);
    selectorData.append(sDiv);

    let rDiv = $('<div>');
    let ul = $('<ul>');
    rDiv.addClass('result-controls');
    ul.addClass('items-list');
    rDiv.append(ul);
    selectorData.append(rDiv);

    function add() {
        let button = $('<a>').addClass('button').text('X').on('click', remove);
        let item = `<b>${$('#addItem').val()}</b>`;
        let li = $(`<li>`).addClass('list-item').append(button).append(item);
        $('.items-list').append(li);
    }

    function remove() {
        $(this).parent().remove()
    }

    function search() {
        let text = $(this).val();
        for (let li of $('.list-item')) {
            matches(li, text)
        }
    }

    function matches(li, text) {
        $(li).css('display', 'block');
        console.log($(li));
        if(isCaseSensitive) {
            if ($(li).text().indexOf(text) === -1) {
                $(li).css('display', 'none');
            }
        } else {
            if ($(li).text().toLowerCase().indexOf(text.toLowerCase()) === -1) {
                $(li).css('display', 'none');
            }
        }
    }
}
