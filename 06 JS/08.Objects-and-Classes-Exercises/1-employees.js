function solve(input) {
    
    let employees = {};
    for (let name of input) {
        employees[name] = name.length;
        
    }

    for (const name in employees){

         console.log(`Name: ${name} -- Personal Number: ${employees[name]}`);
    
    }
}

solve([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    );