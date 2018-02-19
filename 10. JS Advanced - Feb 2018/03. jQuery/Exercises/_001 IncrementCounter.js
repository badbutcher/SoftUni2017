function increment(input) {
    let div = $(input);
    let textArea = $('<textarea>');
    let buttonIncrement = $('<button>');
    let buttonAdd = $('<button>');
    let ul = $('<ul>');

    textArea.addClass('counter');
    textArea.val(0);
    textArea.attr('disabled', true);

    buttonIncrement.addClass('btn');
    buttonIncrement.attr('id', 'incrementBtn');
    buttonIncrement.text('Increment');

    buttonAdd.addClass('btn');
    buttonAdd.attr('id', 'addBtn');
    buttonAdd.text('Add');

    ul.addClass('results');

    buttonIncrement.on('click', function () {
        let oldVal = Number(textArea.val());
        let newVal = Number(oldVal + 1);
        textArea.val(newVal);
    });

    buttonAdd.on('click', function () {
        let li = $('<li>');
        li.append(textArea.val());
        ul.append(li);
    });

    div.append(textArea);
    div.append(buttonIncrement);
    div.append(buttonAdd);
    div.append(ul);
}
