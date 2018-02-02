function softUniForum(input) {
    let closed = (input.toString().match(/<\/code>/g) || []).length;
    let re = new RegExp(/#\b[A-Za-z][\w\-]+[A-Za-z0-9]\b/, 'g');
    let wordsToFilter = input.splice(-1, 1)[0].split(' ');
    let specialBlockFound = false;
    for (let obj of input) {
        if (obj.indexOf('<code>') > -1) {
            specialBlockFound = true;
            if (closed < 1) {
                specialBlockFound = false;
            }
        }

        let matched;
        let matches = [];
        while (matched = re.exec(obj)) {
            matches.push(matched[0]);
        }

        if (!specialBlockFound && matches.length >= 1) {
            let rez = obj;
            for (let match of matches) {
                if (wordsToFilter.indexOf(match.replace('#', '')) > -1) {
                    rez = rez.replace(match, '*'.repeat(match.length - 1));
                }
                else {
                    rez = rez.replace(match, `<a href="/users/profile/show/${match.replace('#', '')}">${match.replace('#', '')}</a>`);
                }
            }

            console.log(rez);
        }
        else {
            console.log(obj);
        }

        if (obj.indexOf('</code>') > -1) {
            specialBlockFound = false;
            closed--;
        }
    }
}

// softUniForum(['#RoYaL: I\'m not sure what you mean,',
//     'but I am confident that I\'ve written',
//     'everything correctly. Ask #iordan_93',
//     'and #pesho if you don\'t believe me',
//     '<code>',
//     '#trying to print stuff',
//     'print("yoo")',
//     '</code>',
//     '<code>',
//     '#trying to print stuff',
//     'print("yoo")',
//     'pesho gosho'
// ]);
console.log();
softUniForum(['<code>',
    '#lele',
    '#pochna se </code>',
    '<code> #mani_begai #gosho <code>',
    'gosho']
);