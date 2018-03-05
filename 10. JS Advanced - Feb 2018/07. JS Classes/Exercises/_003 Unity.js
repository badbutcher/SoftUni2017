class Rat {
    constructor(name) {
        this.name = name;
        this.allRats = [];
    }

    unite(otherRat) {
        if (otherRat instanceof Rat) {
            this.allRats.push(otherRat);
        }
    }

    getRats() {
        return this.allRats;
    }

    toString() {
        let result = [];
        result.push(this.name);
        for (let obj of this.allRats) {
            result.push(`##${obj}`);
        }

        return result.join('\n');
    }
}

let test = new Rat("Pesho");
console.log(test.toString()); //Pesho

console.log(test.getRats()); //[]

test.unite(new Rat("Gosho"));
test.unite(new Rat("Sasho"));
console.log(test.getRats());
//[ Rat { name: 'Gosho', unitedRats: [] },
//  Rat { name: 'Sasho', unitedRats: [] } ]

console.log(test.toString());
// Pesho
// ##Gosho
// ##Sasho
