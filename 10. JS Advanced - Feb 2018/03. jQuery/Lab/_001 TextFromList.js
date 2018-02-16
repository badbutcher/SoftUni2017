function extractText() {
    let result = $('#result');
    let list = $('li').map(function () {
        return this.textContent;
    }).toArray().join(', ');

    result.text(list);
}
