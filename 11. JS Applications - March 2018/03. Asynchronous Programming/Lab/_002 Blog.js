function attachEvents() {
    const serviceUrl = 'https://baas.kinvey.com/appdata/kid_rkdsJiQqG/';
    const kinveyUsername = 'peter';
    const kinveyPassword = 'p';
    const base64auth = btoa(kinveyUsername + ':' + kinveyPassword);
    const authHeaders = {'Authorization': 'Basic ' + base64auth};
    $('#btnLoadPosts').click(loadPostsClick);
    $('#btnViewPost').click(viewPostClick);
    let body = {};

    function loadPostsClick() {
        let posts = $('#posts').empty();
        $.ajax({
            method: 'GET',
            url: serviceUrl + 'posts',
            headers: authHeaders,
            success: getPosts,
            error: handleError
        });

        function getPosts(res) {
            for (let obj of res) {
                let option = $(`<option value="${obj._id}">${obj.title}</option>`);
                posts.append(option);
                body[obj._id] = obj.body;
            }

        }
    }

    function viewPostClick() {
        let postId = $('#posts').val();
        let postTitle = $('#posts').find(':selected').text();
        let comments = $('#post-comments').empty();
        $('#post-title').text(postTitle);
        $('#post-body').text(body[postId]);
        $.ajax({
            method: 'GET',
            url: serviceUrl + `comments/?query={"post_id":"${postId}"}`,
            headers: authHeaders,
            success: getComments,
            error: handleError
        });

        function getComments(res) {
            for (let obj of res) {
                let li = $(`<li>${obj.text}</li>`);
                comments.append(li);
            }
        }
    }

    function handleError(err) {
        console.log(err);
    }
}