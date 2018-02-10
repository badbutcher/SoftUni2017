function formatHelper(input) {
    let firstRegex = new RegExp(/([.,!?:;])\s*/, 'g');
    let secondRegex = new RegExp(/\s+([.,!?:;])/, 'g');
    let thirdRegex = new RegExp(/\.\s*\.\s*\.\s*!/, 'g');
    let forthRegex = new RegExp(/(\.)\s+([0-9]+)\s*/, 'g');
    let fifthRegex = new RegExp(/"\s*([^"]*)\s*"/, 'g');


    input = input[0].replace(firstRegex, (match, g1) => `${g1} `);
    input = input.replace(secondRegex, (match, g1) => `${g1}`);
    input = input.replace(thirdRegex, '...!');
    input = input.replace(forthRegex, (match, g1, g2) => `${g1}${g2}`);
    input = input.replace(fifthRegex, (match, g1) => `"${g1.trim()}"`);

    console.log(input);
}

formatHelper(['Terribly formatted text      .  With chaotic spacings." Terrible quoting "! Also this date is pretty confusing : 20   .   12.  16 .']);
formatHelper(['Now let\'s test           , absolutely everything!Aposiopesis is this: ...Have! you read the constraints?, you squidward? It would be pretty sad if this also fails "         !It would be bad if you don\'t put space after the explanation at start,aposiopesis all the way...". Now; 8   . 1 3. 0x041       .   I hope this will be trimmed too     !']);