function getArticleGenerator(articles) {
    let content = $('#content');
    return function () {
        if (articles.length > 0) {
            let article = $('<article>');
            let text = `<p>${articles.shift()}</p>`;
            article.append(text);
            content.append(article);
        }
    }
}
