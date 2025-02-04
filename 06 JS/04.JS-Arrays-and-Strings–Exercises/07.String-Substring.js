function solve(word, text) {
    let textAssArr = text.split(' ');
    for (w of textAssArr) {
        if (w.toLowerCase() === word.toLowerCase()) {
            console.log(word);
            return;
        }

    }
    console.log(`${word} not found!`)
}

solve('python','JavaScript is the best programming language');
