function chessBoard(number) {
    console.log('<div class="chessboard">');
    for (let i = 0; i < number; i++) {
        console.log('<div>');

        for (let j = i; j < number + i; j++) {
            if (j % 2 === 0) {
                console.log('<span class="black"></span>');
            }
            else if (j % 2 === 1) {
                console.log('<span class="white"></span>');
            }
        }

        console.log('</div>');
    }

    console.log('</div>');
}

chessBoard(3);