let service = (() => {
    function listChrips(subs) {
        let endpoint = `chirps?query={"author":{"$in": [${subs}]}}&sort={"_kmd.ect": -1}`;

        return requester.get('appdata', endpoint, 'kinvey');
    }

    function getUserChrips(username) {
        let endpoint = `chirps?query={"author":"${username}"}&sort={"_kmd.ect": 1}`;

        return requester.get('appdata', endpoint, 'kinvey');
    }

    function getUserFollowers(username) {
        let endpoint = `?query={"subscriptions":"${username}"}`;

        return requester.get('user', endpoint, 'kinvey');
    }

    function createChrip(author, text) {
        let data = {
            author, text
        };

        return requester.post('appdata', 'chirps', 'kinvey', data);
    }

    function deleteChrip(chirpId) {
        let endpoint = `chirps/${chirpId}`;

        return requester.remove('appdata', endpoint, 'kinvey');
    }

    function myChirps(username) {
        let endpoint = `chirps?query={"author":"${username}"}&sort={"_kmd.ect": 1}`;

        return requester.get('appdata', endpoint, 'kinvey');
    }

    function chripDetails(chirpId) {
        let endpoint = `chirps/${chirpId}`;

        return requester.get('appdata', endpoint, 'kinvey');
    }

    return {listChrips, getUserChrips, getUserFollowers, createChrip, deleteChrip, myChirps, chripDetails}
})();