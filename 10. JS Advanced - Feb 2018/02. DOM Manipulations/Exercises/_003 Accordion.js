function toggle() {
    let div = document.getElementById('accordion');
    let text = document.getElementById('extra');
    if (div.children[0].children[0].textContent === 'More') {
        div.children[0].children[0].textContent = 'Less';
        text.style.display = 'block';
    }
    else if (div.children[0].children[0].textContent === 'Less') {
        div.children[0].children[0].textContent = 'More';
        text.style.display = 'none';
    }
}