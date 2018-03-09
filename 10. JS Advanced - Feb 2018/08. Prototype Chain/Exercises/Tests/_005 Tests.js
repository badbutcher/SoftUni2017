let chai = require('chai');
let expect = chai.expect;


let Console = require('../_005 C#Console');

describe('C# ConsoleTests', function () {
    let c = [];
    beforeEach(function () {
        c = Console;
    });
    describe('Tests with writeLine(string)', function () {
        it('Pass normal string', function () {
            expect(c.writeLine('pavel')).to.be.equal('pavel');
        });
        it('Pass empty throws', function () {
            expect(() => c.writeLine()).to.throw(TypeError);
        });
    });

    describe('Tests with writeLine(object)', function () {
        it('Pass array of strings', function () {
            let arr = ['abc', 'cba'];
            expect(c.writeLine(arr)).to.be.equal(JSON.stringify(arr));
        });
        it('Pass object', function () {
            let arr = {name: 'pavel', age: 21};
            expect(c.writeLine(arr)).to.be.equal(JSON.stringify(arr));
        });
    });

    describe('Tests with writeLine(templateString, parameters)', function () {
        it('Throw error if first argument is not a string', function () {
            expect(() => c.writeLine(123, 'asd', 'ggg')).to.throw(TypeError);
        });
        it('Throw error if first argument is not a string arr', function () {
            expect(() => c.writeLine([], 'asd', 'ggg')).to.throw(TypeError);
        });
        it('Pass normal input 1 arg', function () {
            expect(c.writeLine('pavel is {0}', 'great')).to.be.equal('pavel is great');
        });
        it('Pass normal input 3 args', function () {
            expect(c.writeLine('give {0} all {1} the {2}', 'me', 'of', 'money')).to.be.equal('give me all of the money');
        });
        it('Pass normal input 2 args', function () {
            expect(c.writeLine('give {0} all {1}$', 'me', 123)).to.be.equal('give me all 123$');
        });
        it('Pass too many args', function () {
            expect(() => c.writeLine('give {0}', 'me', 'of', 'money')).to.throw(RangeError);
        });
        it('Pass too few args', function () {
            expect(() => c.writeLine('give {0} {1} {2}', 'me')).to.throw(RangeError);
        });
        it('Pass bigger index', function () {
            expect(() => c.writeLine('give {10} {1} {2}', 'me')).to.throw(RangeError);
        });
        it('Pass negative index', function () {
            expect(() => c.writeLine('give {-10} {1} {2}', 'me')).to.throw(RangeError);
        });
        it('Pass nor args', function () {
            expect(() => c.writeLine('give', 'me')).to.throw(TypeError);
        });
    });
});