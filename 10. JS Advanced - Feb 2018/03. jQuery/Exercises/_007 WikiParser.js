function wikiParser() {
    let quotesRegex = new RegExp(/[']{2,3}([^']+)[']{2,3}/, 'g');
    let h1 = new RegExp(/=(.*)=/, 'g');
    let h2 = new RegExp(/==(.*)==/, 'g');
    let h3 = new RegExp(/===(.*)===/, 'g');
}
