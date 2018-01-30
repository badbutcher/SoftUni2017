function solve(input) {
    Array.prototype.contains = function (arg) {
        for (var array = 0; array < this.length; array++)
            if (this[array] === arg)
                return true;
        return false;
    };

    var pattern = /#([a-zA-Z][\w-]+[a-zA-Z0-9])\b|<code>[\w\W]*?<\/code>/g,
        i,
        banned = input[input.length - 1].split(/\s+/).filter(function (e) {
            return e;
        }),
        aHref = '<a href="/users/profile/show/',
        closingA = '\</a\>',
        wholeText = '',
        matches;

    for (i = 0; i < input.length - 1; i++) {
        wholeText += input[i] + "\n";
    }

    while ((matches = pattern.exec(wholeText)) != null) {
        if (matches[0].match(/<code>[\w\W]*?<\/code>/)) {
            continue;
        }
        if (banned.contains(matches[1])) {
            wholeText = wholeText.replace(matches[0], newString('*', matches[1].length));
        } else {
            var strToReplace = aHref + matches[1] + '">' + matches[1] + closingA;
            wholeText = wholeText.replace(matches[0], strToReplace);
        }
    }

    console.log(wholeText);

    function newString(symbol, count) {
        var str = '';
        for (i = 0; i < count; i++) {
            str += symbol;
        }
        return str;
    }
}