function attachEvents() {
    const URL = 'https://baas.kinvey.com/appdata/kid_Sy6UZBL5z/biggestCatches';
    const USERNAME = 'test';
    const PASSWORD = 'test';
    const base64auth = btoa(USERNAME + ':' + PASSWORD);
    const authHeaders = {'Authorization': 'Basic ' + base64auth};

    $('.add').on('click', addCatchAjax);
    $('.load').on('click', loadAllCatchAjax);

    function addCatchAjax() {
        let select = $('#aside').find('fieldset input');

        let angler = select[0].value;
        let weight = parseFloat(select[1].value);
        let species = select[2].value;
        let location = select[3].value;
        let bait = select[4].value;
        let captureTime = Number(select[5].value);

        let inputBody = JSON.stringify({
            'angler': angler,
            'weight': weight,
            'species': species,
            'location': location,
            'bait': bait,
            'captureTime': captureTime,
        });

        $.ajax({
            method: 'POST',
            url: URL,
            data: inputBody,
            headers: authHeaders,
        }).then()
            .catch(errorFunc);
    }

    function loadAllCatchAjax() {
        $.ajax({
            method: 'GET',
            url: URL,
            headers: authHeaders,
        }).then(loadAll)
            .catch(errorFunc);

        function loadAll(res) {
            let catches = $('#catches');
            catches.empty();
            for (let obj of res) {
                catches.append($(`<div class="catch" data-id="${obj._id}">`)
                    .append($('<label>').text('Angler'))
                    .append($(`<input type="text" class="angler" value="${obj.angler}"/>`))
                    .append($('<label>').text('Weight'))
                    .append($(`<input type="number" class="weight" value="${obj.weight}"/>`))
                    .append($('<label>').text('Species'))
                    .append($(`<input type="text" class="species" value="${obj.species}"/>`))
                    .append($('<label>').text('Location'))
                    .append($(`<input type="text" class="location" value="${obj.location}"/>`))
                    .append($('<label>').text('Bait'))
                    .append($(`<input type="text" class="bait" value="${obj.bait}"/>`))
                    .append($('<label>').text('Capture Time'))
                    .append($(`<input type="number" class="captureTime" value="${obj.captureTime}"/>`))
                    .append($('<button class="update">Update</button>').on('click', updateCatch))
                    .append($('<button class="delete">Delete</button>').on('click', deleteCatch)))
            }
        }
    }

    function deleteCatch() {
        let id = $(this).parent();
        $.ajax({
            method: 'DELETE',
            url: URL + '/' + id.attr('data-id'),
            headers: authHeaders
        }).then(id.remove())
            .catch(errorFunc);
    }
    
    function updateCatch() {
        let id = $(this).parent();

        let select = $(id.find('input'));

        let angler = select[0].value;
        let weight = parseFloat(select[1].value);
        let species = select[2].value;
        let location = select[3].value;
        let bait = select[4].value;
        let captureTime = Number(select[5].value);

        let inputData = JSON.stringify({
            'angler': angler,
            'weight': weight,
            'species': species,
            'location': location,
            'bait': bait,
            'captureTime': captureTime,
        });

        $.ajax({
            method: 'PUT',
            url: URL + '/' + id.attr('data-id'),
            data: inputData,
            headers: authHeaders
        }).then()
            .catch(errorFunc);
    }

    function errorFunc(err) {
        console.log(err);
    }
}