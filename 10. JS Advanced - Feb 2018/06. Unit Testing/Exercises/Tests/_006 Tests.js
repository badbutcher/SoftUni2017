let chai = require('chai');
let jsdom = require('jsdom-global')();
let $ = require('jquery');
let expect = chai.expect;
let nuke = function nuke(selector1, selector2) {
    if (selector1 === selector2) return;
    $(selector1).filter(selector2).remove();
};

describe('Armagedom Unit Tests', function () {
    let oldHtml;
    let htmlSelector;
    beforeEach('Init the html', function () {
        document.body.innerHTML = `<div id="target">
            <div class="nested target">
                <p>This is some text</p>
            </div>
            <div class="target">
                <p>Empty div</p>
            </div>
            <div class="inside">
                <span class="nested">Some more text</span>
                <span class="target">Some more text</span>
            </div>
        </div>`;
        htmlSelector = $('#target');
        oldHtml = htmlSelector.html();
    });

    it('Should not remove with an invalid selector', function () {
        let oldHtml = $(htmlSelector).html();
        nuke(htmlSelector, 2);
        expect(htmlSelector.html()).to.be.equal(oldHtml);
    });
    it('Should not remove with duplicate selectors', function () {
        let selector1 = $('.nested');
        nuke(selector1, selector1);
        expect(htmlSelector.html()).to.be.equal(oldHtml);
    });
    it('Should not remove with two valid selectors', function () {
        let selector1 = $('.nested');
        let selector2 = $('.inside');
        nuke(selector1, selector2);
        expect(htmlSelector.html()).to.be.equal(oldHtml);
    });
    it('Should remove with valid and different selectors', function () {
        let selector1 = $('.nested');
        let selector2 = $('.target');
        nuke(selector1, selector2);
        expect(htmlSelector.html()).to.not.be.equal(oldHtml);
    });
});
