function timer() {
    let timer;
    let totalTime = 0;
    let running = false;

    $('#start-timer').on('click', start);
    $('#stop-timer').on('click', stop);

    function start() {
        if (!running) {
            running = true;
            timer = setInterval(function () {
                totalTime++;
                $('#seconds')[0].textContent = ('0' + Math.floor((totalTime % 60))).substr(-2);
                $('#minutes')[0].textContent = ('0' + Math.floor((totalTime / 60) % 60)).substr(-2);
                $('#hours')[0].textContent = ('0' + Math.floor((totalTime / 60 / 60))).substr(-2);
            }, 1000);
        }
    }

    function stop() {
        clearInterval(timer);
        running = false;
    }
}
