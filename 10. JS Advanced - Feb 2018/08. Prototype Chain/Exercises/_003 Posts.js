function result() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = Number(likes);
            this.dislikes = Number(dislikes);
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let result = super.toString() + '\n';
            let likesDislikes = this.likes - this.dislikes;
            result += `Rating: ${likesDislikes}`;
            if (this.comments.length > 0) {
                result += `\nComments:`;
                for (let obj of this.comments) {
                    result += `\n * ${obj}`
                }
            }

            return result;
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = Number(views);
        }

        view() {
            this.views++;
            return this;
        }

        toString() {
            let result = super.toString() + '\n';
            result += `Views: ${this.views}`;
            return result;
        }
    }

    return {Post, SocialMediaPost, BlogPost}
}

let classes = result();

let test = new classes.BlogPost("TestTitle", "TestContent", 5);
test.view().view().view();
