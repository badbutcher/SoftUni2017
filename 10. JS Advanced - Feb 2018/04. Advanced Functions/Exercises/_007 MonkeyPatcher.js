function monkeyPatcher(command) {
    let commands = {
        upvote: () => {
            this.upvotes++;
        },
        downvote: () => {
            this.downvotes++;
        },
        score: () => {
            let currentUpVotes = this.upvotes;
            let currentDownVotes = this.downvotes;
            let totalVotes = currentUpVotes + currentDownVotes;
            let totalScore = currentUpVotes - currentDownVotes;

            let rating = 'new';
            let isNewPost = totalVotes < 10;
            if (!isNewPost) {
                updateRating();
            }

            if (totalVotes > 50) {
                obfuscatedPost();
            }

            return [currentUpVotes, currentDownVotes, totalScore, rating];

            function updateRating() {
                if (currentUpVotes > totalVotes * 0.66) {
                    rating = 'hot';
                } else if (totalScore >= 0 && currentUpVotes > 100 && currentDownVotes > 100) {
                    rating = 'controversial'
                } else if (totalScore < 0) {
                    rating = 'unpopular';
                }
            }

            function obfuscatedPost() {
                let biggerScore = Math.max(currentUpVotes, currentDownVotes);
                let inflation = Math.ceil(biggerScore * 0.25);
                currentDownVotes += inflation;
                currentUpVotes += inflation;
            }
        }
    };

    return commands[command]();
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};
monkeyPatcher.call(post, 'upvote');
monkeyPatcher.call(post, 'downvote');
let score = monkeyPatcher.call(post, 'score'); // [127, 127, 0, 'controversial']
console.log(score);
for (let i = 0; i < 50; i++) {
    monkeyPatcher.call(post, 'downvote');
}
score = monkeyPatcher.call(post, 'score');
console.log(score);
