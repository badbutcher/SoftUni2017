function extractUniqueWords(input) {
    let result = new Set();
    let re = new RegExp(/\W+/, 'g');
    for (let obj of input) {
        let data = obj.split(re).filter(function (e) {
            return e;
        });
        for (let value of data) {
            let word = value.toLowerCase();
            if (!result.has(word)) {
                result.add(word);
            }
        }
    }

    let allWords = Array.from(result.keys());
    console.log(allWords.join(', '));
}

extractUniqueWords(['Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque quis hendrerit dui.',
    'Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla.',
    'Vestibulum dolor diam, dignissim quis varius non, fermentum non felis.',
    'Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut.',
    'Morbi in ipsum varius, pharetra diam vel, mattis arcu.',
    'Integer ac turpis commodo, varius nulla sed, elementum lectus.',
    'Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.'
]);