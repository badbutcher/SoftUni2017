function students() {
    const URL = 'https://baas.kinvey.com/appdata/kid_BJXTsSi-e/students';
    const USERNAME = 'guest';
    const PASSWORD = 'guest';
    const base64auth = btoa(USERNAME + ':' + PASSWORD);
    const authHeaders = {'Authorization': 'Basic ' + base64auth};

    $.ajax({
        method: 'GET',
        url: URL,
        headers: authHeaders,
    }).then(getStudents)
        .catch(errorFunc);

    function getStudents(res) {
        let table = $('#results');
        for (let obj of res) {
            let tr = $('<tr>');
            let id = obj.ID;
            let firstName = obj.FirstName;
            let lastName = obj.LastName;
            let facultyNumber = obj.FacultyNumber;
            let grade = obj.Grade;
            let tableId = $('<td>').text(id);
            let tableFirstName = $('<td>').text(firstName);
            let tableLastName = $('<td>').text(lastName);
            let tableFacultyNumber = $('<td>').text(facultyNumber);
            let tableGrade = $('<td>').text(grade);
            tr.append(tableId).append(tableFirstName).append(tableLastName).append(tableFacultyNumber).append(tableGrade);
            table.append(tr);
        }
    }

    function errorFunc(err) {
        console.log(err);
    }
}