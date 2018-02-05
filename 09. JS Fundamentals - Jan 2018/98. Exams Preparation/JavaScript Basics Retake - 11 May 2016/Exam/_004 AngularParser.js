function angularParser(input) {
    let apps = {};
    let appsNotFound = {};
    for (let obj of input) {
        let data = obj.split('=').map(a => a.replace(/'/g, ''));
        if (data[0].startsWith('$')) {
            if (data.length > 2) {
                let type = data[0].replace('$', '');
                let typeValue = data[1].split('&')[0];
                let app = data[2];

                if (!apps.hasOwnProperty(app)) {
                    apps[app] = {controllers: [], models: [], views: []};
                }

                if (type === 'controller') {
                    apps[app].controllers.push(typeValue)
                }
                else if (type === 'model') {
                    apps[app].models.push(typeValue)
                }
                else if (type === 'view') {
                    apps[app].views.push(typeValue)
                }
            }
            else {
                let appName = data[1].replace('$', '');
                if (!apps.hasOwnProperty(appName)) {
                    apps[appName] = {controllers: [], models: [], views: []};
                }
            }
        }
    }

    for (let obj of Object.keys(apps)) {
        apps[obj].controllers.sort(sortByName);
        apps[obj].models.sort(sortByName);
        apps[obj].views.sort(sortByName);
        apps[obj].models.sort(function (a, b) {
            if (apps[a].models === apps[b].models) {
                return apps[a].models - apps[b].models
            }
            else {
                return apps[b].controllers - apps[a].controllers;
            }
        });
    }

    console.log(JSON.stringify(apps));

    function sortByName(a, b) {
        return a.localeCompare(b);
    }
}

angularParser(['$app=\'MyApp\'',
    '$controller=\'My Controller\'&app=\'MyApp\'',
    '$model=\'My Model\'&app=\'MyApp\'',
    '$view=\'My View\'&app=\'MyApp\'',
]);

console.log('\n---\n');

angularParser(['$controller=\'PHPController\'&app=\'Language Parser\'',
    '$controller=\'JavaController\'&app=\'Language Parser\'',
    '$controller=\'C#Controller\'&app=\'Language Parser\'',
    '$controller=\'C++Controller\'&app=\'Language Parser\'',
    '$app=\'Garbage Collector\'',
    '$controller=\'GarbageController\'&app=\'Garbage Collector\'',
    '$controller=\'SpamController\'&app=\'Garbage Collector\'',
    '$app=\'Language Parser\''
]);