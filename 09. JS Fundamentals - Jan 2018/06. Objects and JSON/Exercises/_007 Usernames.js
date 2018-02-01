function usernames(input) {
    let users = new Set();

    for (let obj of input) {
        users.add(obj)
    }

    Array.from(users.keys()).sort(function (a, b) {
        if (a.length !== b.length) {
            return a.length - b.length
        }
        else {
            return a.localeCompare(b);
        }
    }).forEach(a => console.log(a));
}

usernames(['Ashton',
    'Kutcher',
    'Ariel',
    'Lilly',
    'Keyden',
    'Aizen',
    'Billy',
    'Braston']
);