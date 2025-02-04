function solve() {

    const textAreaElement = document.getElementById('input');
    const outputElement = document.getElementById('output');
    let pElement = [];
    const text = textAreaElement.value;

    let textAssArray = text.split('.');
    let counter = 0;
    let result = '';

    textAssArray = textAssArray.filter(x => x.length > 0)
    .map(x => x += '.');

    while (textAssArray.length > 0) {
        let p = document.createElement('p');
        p.textContent = textAssArray.splice(0, 3).join('');

        outputElement.appendChild(p);
    }

}



