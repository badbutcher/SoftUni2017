function result() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = Number(gasWeight);
        }
    }

    class PartyBalloon extends Balloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight);
            this.ribbonColor = ribbonColor;
            this.ribbonLength = Number(ribbonLength);
            this._ribbon = {
                color: this.ribbonColor,
                length: this.ribbonLength
            }
        }

        get ribbon() {
            return this._ribbon;
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
            super(color, gasWeight, ribbonColor, ribbonLength);
            this._text = text;
        }

        get text() {
            return this._text;
        }
    }

    return {Balloon, PartyBalloon, BirthdayBalloon}
}


let ballon = new Balloon('red', 100);
let partyBallon = new PartyBalloon('yellow', 50, 'green', 10);
let burthdayBallon = new BirthdayBalloon('yellow', 50, 'green', 10, 'BD');