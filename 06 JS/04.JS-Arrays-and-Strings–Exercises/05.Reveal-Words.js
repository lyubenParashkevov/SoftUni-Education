function revealWord(wordsInput, text) {
    let words = wordsInput.split(', ');
    let textArr = text.split(' ');
    
    for (let i = 0; i < textArr.length; i++) {
        if (textArr[i].includes('*')) {
            let wordStar = textArr[i];
            let word = words.find(w => w.length == textArr[i].length)
            textArr[i] = word;
        }
    }

    console.log(textArr.join(' '));
}

revealWord('great, learning',
'softuni is ***** place for ******** new programming languages'
);
