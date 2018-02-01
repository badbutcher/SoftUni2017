function systemComponents(input) {
    let systems = new Map();

    for (let value of input) {
        let data = value.split(' | ');
        let systemName = data[0];
        let componentName = data[1];
        let subComponentName = data[2];

        if (!systems.has(systemName)) {
            systems.set(systemName, new Map())
        }

        if (!systems.get(systemName).has(componentName)) {
            systems.get(systemName).set(componentName, [])
        }

        systems.get(systemName).get(componentName).push(subComponentName);
    }

    let result = Array.from(systems.keys()).sort(function (a, b) {
        if (systems.get(a).size !== systems.get(b).size) {
            return systems.get(b).size - systems.get(a).size;
        }
        else {
            return b.toLowerCase() < a.toLowerCase()
        }
    });

    for (let system of result) {
        console.log(`${system}`);

        let values = Array.from(systems.get(system).keys()).sort(function (a, b) {
            return systems.get(system).get(b).length - systems.get(system).get(a).length;
        });

        for (let key of values) {
            console.log(`|||${key}`);
            for (let obj of systems.get(system).get(key)) {
                console.log(`||||||${obj}`);
            }
        }
    }
}

systemComponents([
    'SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security'
]);