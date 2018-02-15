function attachEventsListeners() {
    let secondsInput = document.getElementById('seconds');
    let minutesInput = document.getElementById('minutes');
    let hoursInput = document.getElementById('hours');
    let daysInput = document.getElementById('days');

    let secondsButton = document.getElementById('secondsBtn');
    let minutesButton = document.getElementById('minutesBtn');
    let hoursButton = document.getElementById('hoursBtn');
    let daysButton = document.getElementById('daysBtn');

    daysButton.addEventListener('click', function () {
        secondsInput.value = daysInput.value * 24 * 60 * 60;
        minutesInput.value = daysInput.value * 24 * 60;
        hoursInput.value = daysInput.value * 24;
    });

    hoursButton.addEventListener('click', function () {
        secondsInput.value = hoursInput.value * 60 * 60;
        minutesInput.value = hoursInput.value * 60;
        daysInput.value = hoursInput.value / 24;
    });

    minutesButton.addEventListener('click', function () {
        secondsInput.value = minutesInput.value * 60;
        hoursInput.value = minutesInput.value / 60;
        daysInput.value = minutesInput.value / 24 / 60;
    });

    secondsButton.addEventListener('click', function () {
        minutesInput.value = secondsInput.value / 60;
        hoursInput.value = secondsInput.value / 60 / 60;
        daysInput.value = secondsInput.value / 24 / 60 / 60;
    });
}
