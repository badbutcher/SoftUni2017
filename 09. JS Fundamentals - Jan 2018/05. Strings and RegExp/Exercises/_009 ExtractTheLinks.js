function extractTheLinks(input) {
    let re = new RegExp(/(www)\.([A-Za-z0-9-]+)(\.[a-z]+)+/, 'g');
    let match;
    while (match = re.exec(input)) {
        console.log(match[0]);
    }
}

extractTheLinks(['Join WebStars now for free, at www.web-stars.com',
    'You can also support our partners:',
    'Internet - www.internet.com',
    'WebSpiders - www.webspiders101.com',
    'Sentinel - www.sentinel.-ko'
]);