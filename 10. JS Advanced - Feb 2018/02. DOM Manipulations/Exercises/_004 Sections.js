function create(sentences) {
    let content = document.getElementById('content');

    for (let obj of sentences) {
        let div = document.createElement("div");
        let p = document.createElement("p");
        let text = document.createTextNode(obj);
        p.appendChild(text);
        p.style.display = 'none';
        div.appendChild(p);
        div.addEventListener('click', function () {
            p.style.display = 'block';
        });

        content.appendChild(div);
        console.log(div);
    }
}