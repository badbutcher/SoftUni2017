function requestValidator(input) {
    let method = input.method;
    let uri = input.uri;
    let version = input.version;
    let message = input.message;

    if (method === undefined || (method !== 'GET' && method !== 'POST' && method !== 'DELETE' && method !== 'CONNECT')) {
        throw new Error('Invalid request header: Invalid Method');
    }

    if (!(uri !== undefined && /^[A-Za-z0-9.]+$/.test(uri) && uri !== '*')) {
        throw new Error('Invalid request header: Invalid URI');
    }

    if (version === undefined || (version !== 'HTTP/0.9' && version !== 'HTTP/1.0' && version !== 'HTTP/1.1' && version !== 'HTTP/2.0')) {
        throw new Error('Invalid request header: Invalid Version');
    }

    if (message === undefined || !/^[^<>\\&'"]*$/.test(message)) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return input;
}

requestValidator({
        method: 'GET',
        uri: '...aaa666',
        version: 'HTTP/1.1',
        message: ''
    }
);

