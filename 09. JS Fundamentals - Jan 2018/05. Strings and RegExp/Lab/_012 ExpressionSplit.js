function expressionSplit(input) {
    let re = new RegExp(/[\(\),;\.\s]+/, 'g');
    let result = input.split(re);

    console.log(result.join('\n'));
}

expressionSplit('let sum = 1 + 2;if(sum > 2){\tconsole.log(sum);}');