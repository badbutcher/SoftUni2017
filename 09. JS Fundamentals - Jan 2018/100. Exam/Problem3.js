function problem3(input) {
    let svgRegex = new RegExp(/<svg>.*<\/svg>/, 'g');
    let catRegex = new RegExp(/<cat>(.*?)<\/cat>/, 'g');
    let catTextRegex = new RegExp(/<cat><text>(.*?)<\/text><\/cat>/, 'g');
    let firstCatLabelRegex = new RegExp(/\[.*\]/, 'g');
    let ratingRegex = new RegExp(/<g><val>([0-9]{1,2})<\/val>([0-9]+)<\/g>/, 'g');
    let error = false;
    let survey = '';
    let votes = 0;
    let values = 0;
    let result = 0;

    let test = svgRegex.test(input);
    if (!test) {
        console.log('No survey found');
        error = true;
    }
    else {
        let svg = input.match(svgRegex)[0];
        let checkCats = svg.match(catRegex);
        if (checkCats.length === 2) {
            if (!catTextRegex.test(svg)) {
                console.log('Invalid format');
                error = true;
            }
            else {
                let catText = svg.match(catTextRegex)[0];
                if (!firstCatLabelRegex.test(catText)) {
                    console.log('Invalid format');
                    error = true;
                }
                else {
                    survey = catText.match(firstCatLabelRegex)[0].replace(/\[|\]/g, '');
                    let catData = svg.match(catRegex)[1];
                    let match;
                    while (match = ratingRegex.exec(catData)) {
                        let vote = Number(match[1]);
                        let value = Number(match[2]);
                        votes += vote;
                        values += value;

                        result += vote * value;
                    }
                }
            }
        }
        else {
            console.log('Invalid format');
            error = true;
        }
    }

    if (!error) {
        console.log(`${survey}: ${Math.round((result / values) * 100) / 100}`);
    }
}

problem3('<p>Some random text</p><svg><cat><text>How do you rate our food? [Food - General]</text></cat><cat><g><val>1</val>0</g><g><val>2</val>1</g><g><val>3</val>3</g><g><val>4</val>10</g><g><val>5</val>7</g></cat></svg><p>Some more random text</p>');
problem3('<svg><cat><text>How do you rate the special menu? [Food - Special]</text></cat> <cat><g><val>1</val>5</g><g><val>5</val>13</g><g><val>10</val>22</g></cat></svg>')