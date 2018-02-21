function wikiParser(selector) {
    let element = $(selector);

    let h1 = new RegExp(/=(.*?)=/, 'g');
    let h2 = new RegExp(/==(.*?)==/, 'g');
    let h3 = new RegExp(/===(.*?)===/, 'g');
    let doubleBrackets = new RegExp(/\[\[([^\[\]]+?)\|(.+?)\]\]/, 'gm');
    let singleBrackets = new RegExp(/\[\[([^\[\]]+?)\]\]/, 'gm');
    let bold = new RegExp(/'''(.*?)'''/, 'g');
    let italic = new RegExp(/''(.*?)''/, 'g');
    let text = element.text();
    text = text
        .replace(h3, (a, b) => `<h3>${b}</h3>`)
        .replace(h2, (a, b) => `<h2>${b}</h2>`)
        .replace(h1, (a, b) => `<h1>${b}</h1>`)
        .replace(doubleBrackets, (a, b, c) => `<a href='/wiki/${b}'>${c}</a>`)
        .replace(singleBrackets, (a, b) => `<a href='/wiki/${b}'>${b}</a>`)
        .replace(bold, (a, b) => `<b>${b}</b>`)
        .replace(italic, (a, b) => `<i>${b}</i>`);
    element.html(text);
}
