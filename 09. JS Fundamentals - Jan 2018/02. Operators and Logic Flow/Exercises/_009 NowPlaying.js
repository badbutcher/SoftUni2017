function nowPlaying(input) {
    let artist = input[0];
    let song = input[1];
    let duration = input[2];

    console.log(`Now Playing: ${song} - ${artist} [${duration}]`);
}

nowPlaying(['Number One', 'Nelly', '4:09']);