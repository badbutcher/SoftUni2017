function deckOfCards(cards) {
    const VALID_CARDS = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const VALID_SUITS = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663'
    };

    for (let i = 0; i < cards.length; i++) {
        let card = '';
        let suit = '';
        if (cards[i].length === 3) {
            card = cards[i].substr(0, 2);
            suit = cards[i].substr(2, 3);
        } else {
            card = cards[i].substr(0, 1);
            suit = cards[i].substr(1, 2);
        }

        try {
            cards[i] = makeCard(card, suit);
        } catch (ex) {
            console.log(`Invalid card: ${cards[i]}`);
            return;
        }
    }

    console.log(cards.join(' '));

    function makeCard(card, suit) {
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
}

console.log(deckOfCards(['AS', '10D', 'KH', '2C']));
console.log(deckOfCards(['5S', '3D', 'QD', '1C']));