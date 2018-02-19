function domSearch(selector, isCaseSensitive) {
    let eDiv = $('<div>');
    let eLabel = $('<label>');
    let eInput = $('<input>');
    let eA = $('<a>');
    let selectorData = $(selector);
    eA.text('Add');
    eA.addClass('button');
    eLabel.text('Enter text: ');
    eLabel.append(eInput);
    eDiv.append(eLabel);
    eDiv.append(eA);
    selectorData.append(eDiv);

    let sDiv = $('<div>');
    let sLabel = $('<label>');
    let sInput = $('<input>');
    sLabel.text('Search: ');
    sLabel.append(sInput);
    sDiv.append(sLabel);
    selectorData.append(sDiv);
}
