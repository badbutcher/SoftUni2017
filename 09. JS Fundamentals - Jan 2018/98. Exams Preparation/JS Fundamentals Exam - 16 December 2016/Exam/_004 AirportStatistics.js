function airportStatistics(dataRows) {
    let airport = new Set();
    let townStatistics = new Map();
    let townPlanes = new Map();

    for (let dataRow of dataRows) {
        let [planeId, town, passengersCount, action] = dataRow.split(/\s+/g);
        passengersCount = Number(passengersCount);

        if (action === 'land') {
            if (airport.has(planeId)) {
                continue;
            }
            else {
                airport.add(planeId);
            }

            if (!townStatistics.has(town)) {
                townStatistics.set(town, [0, 0]);
            }

            if (!townPlanes.has(town)) {
                townPlanes.set(town, new Set());
            }

            townStatistics.get(town)[0] += passengersCount;
            townPlanes.get(town).add(planeId);
        }
        else {
            if (airport.has(planeId)) {
                airport.delete(planeId);
            }
            else {
                continue;
            }

            if (!townStatistics.has(town)) {
                townStatistics.set(town, [0, 0]);
            }

            if (!townPlanes.has(town)) {
                townPlanes.set(town, new Set());
            }

            townStatistics.get(town)[1] += passengersCount;
            townPlanes.get(town).add(planeId);
        }
    }

    let sortedAirport = Array.from(airport.values()).sort((a, b) => a.localeCompare(b));
    console.log('Planes left:');
    for (let planeId of sortedAirport) {
        console.log(`- ${planeId}`);
    }

    let sortedTowns = [...townStatistics.entries()].sort(sortTowns);
    for (let [town, statistics] of sortedTowns) {
        console.log(town);
        console.log(`Arrivals: ${statistics[0]}`);
        console.log(`Departures: ${statistics[1]}`);

        let sortedPlanes = [...townPlanes.get(town).values()].sort((a, b) => a.localeCompare(b));
        console.log('Planes:');
        for (let planeId of sortedPlanes) {
            console.log(`-- ${planeId}`);
        }
    }

    function sortTowns(a, b) {
        let aArrivals = a[1][0];
        let bArrivals = b[1][0];
        let firstCriteria = bArrivals - aArrivals;

        if (firstCriteria !== 0) {
            return firstCriteria;
        }
        else {
            return a[0].localeCompare(b[0]);
        }
    }
}