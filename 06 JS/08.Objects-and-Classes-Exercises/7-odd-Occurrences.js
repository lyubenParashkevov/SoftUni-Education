function solve(input) {
    input = input.toLowerCase().split(' ');
    
    let dictionary = [];
    for (let i = 0; i < input.length; i++) {
        if (!dictionary[input[i]]) {
            dictionary[input[i]] = 0;
        } 

        dictionary[input[i]] += 1;
    }

    let sorted = [];
    for (let word in dictionary) {
        if (dictionary[word] % 2 !== 0) {
            sorted.push(word)
        }
    }
    
    console.log(sorted.join(' '));
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
