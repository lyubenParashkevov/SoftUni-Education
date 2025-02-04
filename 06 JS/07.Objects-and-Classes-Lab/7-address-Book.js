function solve(input) {
    let addressBook = {};
    for (let line of input) {

        let [name, address] = line.split(':');
        if (addressBook[name]) {
            addressBook[name] = address;
        }else {
            addressBook[name] = address;
        }
    }

    Object.entries(addressBook).sort((a, b) => a[0].localeCompare(b[0]))
    .forEach(([name, address]) => console.log(`${name} -> ${addressBook[name]}`));
    
}

solve(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
);