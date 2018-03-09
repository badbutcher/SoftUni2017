function result() {
    class Melon {
        constructor(weight, melonSort) {
            if (new.target === Melon) {
                throw new TypeError("Abstract class cannot be instantiated directly");
            }
            this.element = '';
            this.weight = weight;
            this.melonSort = melonSort;
        }

        get elementIndex() {
            return this.weight * this.melonSort.length;
        }

        toString() {
            let result = `Element: ${this.element}\n`;
            result += `Sort: ${this.melonSort}\n`;
            result += `Element Index: ${this.elementIndex}`;
            return result;
        }
    }

    class Watermelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = 'Water';
        }

        get elementIndex() {
            return this.weight * this.melonSort.length;
        }
    }

    class Firemelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = 'Fire';
        }
    }

    class Earthmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = 'Earth';
        }
    }

    class Airmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = 'Air';
        }
    }

    class Melolemonmelon extends Earthmelon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = 'Water';
            this.elements = ['Water', 'Fire', 'Earth', 'Air'];
            this.lastElement = 1;
        }

        morph() {
            this.element = this.elements[this.lastElement++ % 4];
        }
    }

    return {Melon, Watermelon, Firemelon, Earthmelon, Airmelon, Melolemonmelon}
}

let classes = result();

let test = new classes.Melolemonmelon(150, "Melo");

test.morph();
test.morph();

console.log(test.toString());