function playingCards(card, suit) {
    const VALID_CARDS = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const VALID_SUITS = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663'
    };

    if (VALID_CARDS.indexOf(card) < 0 || !VALID_SUITS.hasOwnProperty(suit)) {
        throw new Error('Error');
    }

    let result = {
        card: card,
        suit: suit,
        toString: function () {
            return card + VALID_SUITS[suit];
        }
    };

    return result;
}

console.log('' + playingCards('A', 'S'));
console.log('' + playingCards('10', 'H'));
console.log('' + playingCards('1', 'C'));
