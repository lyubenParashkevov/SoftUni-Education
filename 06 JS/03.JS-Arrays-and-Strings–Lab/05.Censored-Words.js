function hideWord(input, word) {
    function repeat(word) {
        let censored = '';
        for (let i = 0; i < word.length; i++) {
            censored += '*';
        }
            return censored;
    }

    let newText = input.replace(word, repeat(word));
    while (newText.includes(word)) {
        newText = newText.replace(word, repeat(word));
    }

    console.log(newText);
}

hideWord('Find the hidden word', 'hidden')