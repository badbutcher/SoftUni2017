let chai = require('chai');
let expect = chai.expect;
let Sumator = require('../_002 SumatorClass');

describe('Sumator tests', function () {
    let arr;
    beforeEach(function () {
        arr = new Sumator();
    });

    describe('Initial tests', function () {
        it('has all properties', function () {
            expect(arr.hasOwnProperty('data')).to.equal(true);
        });

        it('has functions attached to prototype', function () {
            expect(Object.getPrototypeOf(arr).hasOwnProperty('add')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('sumNums')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('removeByFilter')).to.equal(true);
            expect(Object.getPrototypeOf(arr).hasOwnProperty('toString')).to.equal(true);
        });
    });

    describe('Add tests', function () {
        it('Add with string', function () {
            arr.add('String');
            expect(arr.toString()).to.be.equal('String');
        });
        it('Add with int', function () {
            arr.add(123);
            expect(arr.toString()).to.be.equal('123');
        });
        it('Add two items', function () {
            arr.add('String');
            arr.add(123);
            arr.add([1, 2, 3]);
            expect(arr.toString()).to.be.equal('String, 123, 1,2,3');
        });
    });

    describe('SumNums tests', function () {
        it('Empty arr', function () {
            expect(arr.sumNums()).to.be.equal(0);
        });
        it('With string', function () {
            arr.add('asd');
            expect(arr.sumNums()).to.be.equal(0);
        });
        it('One num', function () {
            arr.add(5);
            expect(arr.sumNums()).to.be.equal(5);
        });
        it('Two nums', function () {
            arr.add(5);
            arr.add(6.5);
            expect(arr.sumNums()).to.be.equal(11.5);
        });
        it('Three nums', function () {
            arr.add(5);
            arr.add(6);
            arr.add(-7);
            arr.add([1, 2, 3]);
            expect(arr.sumNums()).to.be.equal(4);
        });
        it('Three nums and one string', function () {
            arr.add(5);
            arr.add(6);
            arr.add('ggg');
            arr.add(-7);
            expect(arr.sumNums()).to.be.equal(4);
        });
    });

    describe('RemoveByFilter tests', function () {
        it('Even func', function () {
            arr.add(1);
            arr.add(2);
            arr.add(3);
            arr.add(4);
            arr.removeByFilter(x => x % 2 === 0);
            expect(arr.toString()).to.be.equal('1, 3');
        });
        it('Odd func', function () {
            arr.add(1);
            arr.add(2);
            arr.add(3);
            arr.add(4);
            arr.removeByFilter(x => x % 2 === 1);
            expect(arr.toString()).to.be.equal('2, 4');
        });
        it('Starts with func', function () {
            arr.add('pavel');
            arr.add('pesho');
            arr.add('pacha');
            arr.add('gosho');
            arr.removeByFilter(x => x.startsWith('pa'));
            expect(arr.toString()).to.be.equal('pesho, gosho');
        });
    });

    describe('ToString tests', function () {
        it('Empty', function () {
            expect(arr.toString()).to.be.equal('(empty)');
        });
        it('Empty', function () {
            arr.add('pavel');
            expect(arr.toString()).to.be.equal('pavel');
        });
    });
});
