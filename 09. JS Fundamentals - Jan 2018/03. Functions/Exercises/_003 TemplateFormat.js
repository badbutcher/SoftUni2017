function templateFormat(input) {
    console.log('<?xml version="1.0" encoding="UTF-8"?>');
    console.log('<quiz>');

    for (let i = 0; i < input.length; i += 2) {
        console.log('  <question>');
        console.log(input[i]);
        console.log('  </question>');
        console.log('  <answer>');
        console.log(input[i + 1]);
        console.log('  </answer>');
    }

    console.log('</quiz>');
}

templateFormat(["Who was the forty-second president of the U.S.A.?", "William Jefferson Clinton"]);