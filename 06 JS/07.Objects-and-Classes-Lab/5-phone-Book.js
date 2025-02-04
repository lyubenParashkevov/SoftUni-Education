function solve(input) {
    let phoneBook = {};
    for (let line of input) {
        let tokens = line.split(' ');
        let name = tokens[0];
        let number = tokens[1];
        phoneBook[name] = number;
    }

    for (let person in phoneBook) {
        console.log(`${person} -> ${phoneBook[person]}`);
    }
}

solve(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']
);