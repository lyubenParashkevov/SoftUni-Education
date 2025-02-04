function solve(input) {
    const dictionary = {};

    const words = input.map(JSON.parse);

    for (let row of words) {

        let word = Object.keys(row)[0];

        dictionary[word] = row[word];

    }
    Object.entries(dictionary).sort((a,b) => a[0].localeCompare(b[0]))
    .forEach(([word, text]) => console.log(`Term: ${word} => Definition: ${text}`));
        
}

solve([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
]
);