let chai = require('chai');
let jsdom = require('jsdom-global')();
let $ = require('jquery');
let expect = chai.expect;
const sharedObject = require('../_005 SharedObject.js');

document.body.innerHTML = `<div id="wrapper">
    <input type="text" id="name">
    <input type="text" id="income">
    </div>`;

describe('Shared object tests', function () {
    let match;
    global.$ = $;
    beforeEach(function () {
        match = sharedObject;

    });

    describe('Initial state', function () {
        it('Name should be null', function () {
            expect(match.name).to.be.equal(null);
        });
        it('Income should be null', function () {
            expect(match.income).to.be.equal(null);
        });
    });
    describe('Change Name', function () {
        it('Should not change name when empty', function () {
            match.changeName('');
            expect(match.name).to.be.equal(null);
        });
        it('Number should change name', function () {
            match.changeName(51);
            expect(match.name).to.be.equal(51);
        });
        it('String should change name', function () {
            match.changeName('Pavel');
            expect(match.name).to.be.equal('Pavel');
        });
        it('Should not change name []', function () {
            match.changeName([]);
            expect(match.name).to.be.equal(null);
        });
        it('Should not change name false', function () {
            match.changeName(false);
            expect(match.name).to.be.equal(false);
        });
        it('String should change name', function () {
            match.changeName('Losho');
            expect(match.name).to.be.equal('Losho');
        });

        describe('Change Name TextBox', function () {
            it('Should not change name when empty', function () {
                let textBox = $('#name');
                match.changeName('');
                expect(textBox.val()).to.be.equal('Losho');
            });
            it('Should not change name', function () {
                let textBox = $('#name');
                match.changeName([]);
                expect(textBox.val()).to.be.equal('Losho');
            });
            it('Should change name false', function () {
                let textBox = $('#name');
                match.changeName(false);
                expect(textBox.val()).to.be.equal('false');
            });
            it('Should change name', function () {
                let textBox = $('#name');
                match.changeName('Kamen');
                expect(textBox.val()).to.be.equal('Kamen');
            });
        });
    });

    describe('Change Income', function () {
        it('Should not change income when empty', function () {
            match.changeIncome('');
            expect(match.income).to.be.equal(null);
        });
        it('Should not change income when []', function () {
            match.changeIncome([]);
            expect(match.income).to.be.equal(null);
        });
        it('Number should change income', function () {
            match.changeIncome(100);
            expect(match.income).to.be.equal(100);
        });
        it('Number should not change income', function () {
            match.changeIncome(-51);
            expect(match.income).to.be.equal(null);
        });
        it('Income should not change', function () {
            match.changeIncome(0);
            expect(match.income).to.be.equal(null);
        });
        it('Income should not change', function () {
            match.changeIncome(1.123);
            expect(match.income).to.be.equal(null);
        });
        it('Income should not change', function () {
            match.changeIncome('asd');
            expect(match.income).to.be.equal(null);
        });
        it('Number should change income', function () {
            match.changeIncome(200);
            expect(match.income).to.be.equal(200);
        });
        it('Number should not change income {}', function () {
            match.changeIncome({});
            expect(match.income).to.be.equal(null);
        });
        it('Number should not change income []', function () {
            match.changeIncome([]);
            expect(match.income).to.be.equal(null);
        });
        it('Number should not change income false', function () {
            match.changeIncome(false);
            expect(match.income).to.be.equal(null);
        });

        describe('Change Income TextBox', function () {
            it('Income should change', function () {
                let textBox = $('#income');
                match.changeIncome(50);
                expect(textBox.val()).to.be.equal('50');
            });
            it('Income should not change', function () {
                let textBox = $('#income');
                match.changeIncome(-50);
                expect(textBox.val()).to.be.equal('50');
            });
            it('Income should not change', function () {
                let textBox = $('#income');
                match.changeIncome(0);
                expect(textBox.val()).to.be.equal('50');
            });
            it('Income should not change', function () {
                let textBox = $('#income');
                match.changeIncome(false);
                expect(textBox.val()).to.be.equal('50');
            });
            it('Income should not change', function () {
                let textBox = $('#income');
                match.changeIncome(1.123);
                expect(textBox.val()).to.be.equal('50');
            });
            it('Income should not change', function () {
                let textBox = $('#income');
                match.changeIncome('asd');
                expect(textBox.val()).to.be.equal('50');
            });
            it('Income should change to new one', function () {
                match.changeIncome(44);
                let textBox = $('#income');
                match.changeIncome(66);
                expect(textBox.val()).to.be.equal('66');
            });
        });
    });

    describe('Update Name', function () {
        it('Should not change name when empty', function () {
            match.changeName('Pesho');
            let name = $('#name');
            name.val('');
            match.updateName();
            expect(match.name).to.be.equal('Pesho');
        });
        it('Should not change name when false', function () {
            match.changeName('Pesho');
            let name = $('#name');
            name.val(false);
            match.updateName();
            expect(match.name).to.be.equal('false');
        });
        it('Should change name', function () {
            match.changeName('Kamen');
            let name = $('#name');
            name.val('Pavel');
            match.updateName();
            expect(match.name).to.be.equal('Pavel');
        });
    });

    describe('Update Income', function () {
        it('Income should not change when empty', function () {
            match.changeIncome(50);
            let name = $('#income');
            name.val('');
            match.updateIncome();
            expect(match.income).to.be.equal(50);
        });
        it('Income should not change when empty', function () {
            match.changeIncome(50);
            let name = $('#income');
            name.val(false);
            match.updateIncome();
            expect(match.income).to.be.equal(50);
        });
        it('Income change when', function () {
            match.changeIncome(123);
            let name = $('#income');
            name.val('Gosho');
            match.updateIncome();
            expect(match.income).to.be.equal(123);
        });
        it('Income should not change when negative', function () {
            match.changeIncome(-50);
            let name = $('#income');
            name.val(100);
            match.updateIncome();
            expect(match.income).to.be.equal(100);
        });
        it('Income should not change when 0', function () {
            match.changeIncome(0);
            let name = $('#income');
            name.val(33);
            match.updateIncome();
            expect(match.income).to.be.equal(33);
        });
        it('Income should not change when -10', function () {
            match.changeIncome(33);
            let name = $('#income');
            name.val(-10);
            match.updateIncome();
            expect(match.income).to.be.equal(33);
        });
        it('Income should not change for 1.123', function () {
            match.changeIncome(123);
            let name = $('#income');
            name.val(1.123);
            match.updateIncome();
            expect(match.income).to.be.equal(123);
        });
    });
});