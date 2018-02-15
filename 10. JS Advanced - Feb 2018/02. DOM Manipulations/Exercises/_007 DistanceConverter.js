function attachEventsListeners() {
    let button = document.getElementById('convert');
    let distances = {
        'km': 1000,
        'm': 1,
        'cm': 0.01,
        'mm': 0.001,
        'mi': 1609.34,
        'yrd': 0.9144,
        'ft': 0.3048,
        'in': 0.0254
    };

    button.addEventListener('click', function () {
        let input = Number(document.getElementById('inputDistance').value);
        let from = document.getElementById('inputUnits').value;
        let to = document.getElementById('outputUnits').value;
        let result = input * distances[from] / distances[to];
        document.getElementById('outputDistance').value = result;
    })
}
