let result = (function () {
    let Suits = {
        CLUBS: "\u2663",    // ♣
        DIAMONDS: "\u2666", // ♦
        HEARTS: "\u2665",   // ♥
        SPADES: "\u2660"    // ♠
    };

    let Faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get face() {
            return this._face;
        }

        set face(someFace) {
            if (!Faces.includes(someFace)) {
                throw new Error('Error');
            }

            this._face = someFace
        }

        get suit() {
            return this._suit;
        }

        set suit(someSuit) {
            if (!Object.keys(Suits).map(k => Suits[k]).includes(someSuit)) {
                throw new Error('Error');
            }

            this._suit = someSuit
        }

        toString() {
            return this._face + this._suit;
        }
    }

    return {
        Suits: Suits,
        Card: Card
    }
}());

let Card = result.Card;
let Suits = result.Suits;

let card = new Card('Q', Suits.CLUBS);
card.face = 'A';
card.suit = Suits.DIAMONDS;
console.log(card.toString());
let card2 = new Card('1', 'asd');
console.log(card2);