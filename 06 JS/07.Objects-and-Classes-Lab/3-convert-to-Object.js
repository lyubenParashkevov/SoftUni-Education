function solve(text) {
    const result = JSON.parse(text);

    Object.keys(result).forEach(prop => console.log(`${prop}: ${result[prop]}`));
}

solve('{"name": "George", "age": 40, "town": "Sofia"}');