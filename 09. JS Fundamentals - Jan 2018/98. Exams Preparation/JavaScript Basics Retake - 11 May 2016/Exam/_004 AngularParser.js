function angularParser(input) {
    let apps = {};
    let appsNotFound = {};

    for (let obj of input) {
        let data = obj.split('=').map(a => a.replace(/'/g, ''));
        if (data[0].startsWith('$')) {
            if (data.length > 2) {
                let type = data[0].replace('$', '');
                let typeValue = data[1].split('&')[0];
                let appName = data[2];

                if (apps.hasOwnProperty(appName)) {
                    addData(type, appName, typeValue, apps);
                }
                else if (!appsNotFound.hasOwnProperty(appName)) {
                    appsNotFound[appName] = {controllers: [], models: [], views: []};
                    addData(type, appName, typeValue, appsNotFound);
                }
                else {
                    addData(type, appName, typeValue, appsNotFound);
                }

            }
            else {
                let appName = data[1].replace('$', '');
                if (appsNotFound.hasOwnProperty(appName)) {
                    apps[appName] = {controllers: [], models: [], views: []};
                    apps[appName] = appsNotFound[appName]
                }
                else if (!apps.hasOwnProperty(appName)) {
                    apps[appName] = {controllers: [], models: [], views: []};
                }
            }
        }
    }

    for (let obj of Object.keys(apps)) {
        apps[obj].controllers.sort(sortByName);
        apps[obj].models.sort(sortByName);
        apps[obj].views.sort(sortByName);
    }

    let sort = Object.keys(apps).sort(function (a, b) {
        if (apps[a].controllers.length === apps[b].controllers.length) {
            return apps[a].models.length - apps[b].models.length
        }
        else {
            return apps[b].controllers.length - apps[a].controllers.length;
        }
    });


    let result = {};
    for (let obj of sort) {
        result[obj] = apps[obj];
    }

    console.log(JSON.stringify(result));

    function sortByName(a, b) {
        return a.localeCompare(b);
    }

    function addData(type, app, typeValue, appFoundType) {
        if (type === 'controller') {
            appFoundType[app].controllers.push(typeValue)
        }
        else if (type === 'model') {
            appFoundType[app].models.push(typeValue)
        }
        else if (type === 'view') {
            appFoundType[app].views.push(typeValue)
        }
    }
}

// angularParser(['$app=\'MyApp\'',
//     '$controller=\'My Controller\'&app=\'MyApp\'',
//     '$model=\'My Model\'&app=\'MyApp\'',
//     '$view=\'My View\'&app=\'MyApp\'',
// ]);

console.log('\n---\n');

angularParser([
    '$controller=\'PHPController\'&app=\'Language Parser\'',
    '$controller=\'JavaController\'&app=\'Language Parser\'',
    '$controller=\'C#Controller\'&app=\'Language Parser\'',
    '$controller=\'C++Controller\'&app=\'Language Parser\'',
    '$app=\'Garbage Collector\'',
    '$controller=\'GarbageController\'&app=\'Garbage Collector\'',
    '$controller=\'SpamController\'&app=\'Garbage Collector\'',
    '$app=\'Language Parser\''
]);