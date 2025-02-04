function solve(input) {

    let n = input.shift();
    let baristas = [];
    let barista;
    let command;
    for (let i = 0; i < n; i++) {
        barista = input.shift().split(' ');
        barista = {
            name: barista[0],
            shift: barista[1],
            coffeeTypes: barista[2].split(','),
        }
        baristas.push(barista);
    }

    while (true) {
        let tokens = input.shift().split(' / ');
        command = tokens[0];
        if (command === 'Closed') {
            break;
        }
        let name = tokens[1];
        barista = baristas.find(b => b.name === name);

        if (command === 'Prepare') {

            let shift = tokens[2];
            let coffeeType = tokens[3];

            if (barista.shift === shift && barista.coffeeTypes.includes(coffeeType)) {

                console.log(`${barista.name} has prepared a ${coffeeType} for you!`);
            } else {
                console.log(`${barista.name} is not available to prepare a ${coffeeType}.`)
            }

        } else if (command === 'Change Shift') {
            let newShift = tokens[2];
            barista.shift = newShift;

            console.log(`${barista.name} has updated his shift to: ${newShift}`);

        } else {   //Learn
            let newCoffeeType = tokens[2];

            if (barista.coffeeTypes.includes(newCoffeeType)) {
                console.log(`${barista.name} knows how to make ${newCoffeeType}.`)
            } else {
                barista.coffeeTypes.push(newCoffeeType);
                console.log(`${barista.name} has learned a new coffee type: ${newCoffeeType}.`)
            }
        };

    }
    for (const barista of baristas) {
        console.log(`Barista: ${barista.name}, Shift: ${barista.shift}, Drinks: ${barista.coffeeTypes.join(', ')}`)
    }

}

solve([
    '3',
    'Alice day Espresso,Cappuccino',
    'Bob night Latte,Mocha',
    'Carol day Americano,Mocha',
    'Prepare / Alice / day / Espresso',
    'Change Shift / Bob / night',
    'Learn / Carol / Latte',
    'Learn / Bob / Latte',
    'Prepare / Bob / night / Latte',
    'Closed']
);