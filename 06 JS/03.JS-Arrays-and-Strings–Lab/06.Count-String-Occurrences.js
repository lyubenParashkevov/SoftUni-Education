function count(text, wordToFind) {
    let textAsArray = text.split(' ');
    let counter = 0;
    for(word of textAsArray) {
        if (word === wordToFind) {
            counter++;
        }
    }

    console.log(counter);
}

count('This is a word and it also is a sentence', 'is')

