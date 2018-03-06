let exportPersonFunc = require('./_002 InheritingAndReplacingToString');

function extendClass(classToExtend) {
    classToExtend.prototype.species = 'Human';
    classToExtend.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;
    }
}

//let obj = exportPersonFunc();
// let person = exportPersonFunc;
// let p = new person;
// extendClass(person);
// console.log(person);
// console.log(p.species);

let obj = exportPersonFunc();
let person = new obj['Person']('PESHO', 'asd');
extendClass(obj['Person']);
console.log(person);
console.log(person.species);
