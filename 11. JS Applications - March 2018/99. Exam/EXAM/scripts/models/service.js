let service = (() => {
    function getActiveReceipt(userId) {
        let endpoint = `receipts?query={"_acl.creator":"${userId}","active":"true"}`;

        return requester.get('appdata', endpoint, 'kinvey');
    }

    function getEntriesByReceiptId(receiptId) {
        let endpoint = `entries?query={"receiptId":"${receiptId}"}`;

        return requester.get('appdata', endpoint, 'kinvey');
    }

    function createReceipt() {
        let data = {active: true, productCount: 0, total: 0};
        return requester.post('appdata', 'receipts', 'kinvey', data);
    }

    function addEntry(type, qty, price, receiptId) {
        let data = {type, qty, price, receiptId};

        return requester.post('appdata', 'entries', 'kinvey', data);
    }

    function deleteEntry(id) {
        return requester.remove('appdata', `entries/${id}`, 'kinvey');
    }

    function commitReceipt(receiptId, active, productCount, total) {
        let endpoint = `receipts/${receiptId}`;

        let data = {active, productCount, total};

        return requester.update('appdata', endpoint, 'kinvey', data);
    }

    function getMyReceipts(userId) {
        let endpoint = `receipts?query={"_acl.creator":"${userId}","active":"false"}`;

        return requester.get('appdata', endpoint, 'kinvey');
    }

    return {getActiveReceipt, getEntriesByReceiptId, createReceipt, addEntry, deleteEntry, commitReceipt, getMyReceipts}
})();