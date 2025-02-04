function repeatString(word, count) {
    let newString = '';

    for (let i = 0; i < count; i++) {
        newString += word;
    }

    return(newString);
}

repeatString("String", 2)