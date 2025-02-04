function solve(input) {
    let searchedWords = input.shift().split(' ');
    let storage = {};
    for (let searchedWord of searchedWords) {
        storage[searchedWord] = 0;
    }
    

    for (let word of input) {
        if (storage.hasOwnProperty(word)) {
            storage[word] +=1;
        }
    }

    const sorted = Object.entries(storage).sort((a, b) => b[1] - a[1]);

    for (const[word, count] of sorted) {
        console.log(`${word} - ${count}`);
    }
}


solve([
    'this sentence', 
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]
    );