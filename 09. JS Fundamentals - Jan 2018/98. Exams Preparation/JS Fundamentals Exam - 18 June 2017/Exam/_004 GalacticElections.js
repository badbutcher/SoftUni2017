function galacticElections(input) {
    let election = new Map();
    for (let obj of input) {
        let data = Object.values(obj);
        let system = data[0];
        let candidate = data[1];
        let votes = Number(data[2]);

        if (!election.has(system)) {
            election.set(system, new Map())
        }

        if (!election.get(system).has(candidate)) {
            election.get(system).set(candidate, 0)
        }

        election.get(system).set(candidate, votes + election.get(system).get(candidate))
    }

    for (let obj of election) {
        console.log(Object.values(obj));
    }
}

galacticElections([ { system: 'Theta', candidate: 'Flying Shrimp', votes: 10 },
    { system: 'Sigma', candidate: 'Space Cow',     votes: 200 },
    { system: 'Sigma', candidate: 'Flying Shrimp', votes: 120 },
    { system: 'Tau',   candidate: 'Space Cow',     votes: 15 },
    { system: 'Sigma', candidate: 'Space Cow',     votes: 60 },
    { system: 'Tau',   candidate: 'Flying Shrimp', votes: 150 } ]
);