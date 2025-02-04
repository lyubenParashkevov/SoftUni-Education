function solve(input) {
    let n = Number(input.shift());

    let astronauts = [];
    let astronaut = {};
    let command;

    for (let i = 0; i < n; i++) {
        astronaut = input.shift().split(' ');
        astronaut = {
            name: astronaut[0],
            oxigen: Number(astronaut[1]),
            energy: Number(astronaut[2]),
        }
        astronauts.push(astronaut);
    }

    while (true) {
        let tokens = input.shift().split(' - ');
        command = tokens[0];
        let name = tokens[1];
        astronaut = astronauts.find(astronaut => astronaut.name === name);

        if (command === 'End') {
            break;
        }

        if (command === 'Explore') {
            let needdeEnergy = Number(tokens[2]);

            if (astronaut.energy >= needdeEnergy) {
                console.log(`${astronaut.name} has successfully explored a new area and now has ${Number(astronaut.energy) - needdeEnergy} energy!`);
                astronaut.energy -= needdeEnergy;
            } else {
                console.log(`${astronaut.name} does not have enough energy to explore!`);
            }

        } else if (command === 'Refuel') {
            let amount = Number(tokens[2]);
            let curEnergy = astronaut.energy;
            astronaut.energy += amount;
            if (astronaut.energy > 200) {
                astronaut.energy = 200;
                console.log(`${astronaut.name} refueled their energy by ${200 - curEnergy}!`)
            } else {
                console.log(`${astronaut.name} refueled their energy by ${amount}!`)

            }

        } else {                                      // Breath
            let amount = Number(tokens[2]);
            let curOxigen = astronaut.oxigen;
            astronaut.oxigen += amount;
            if (astronaut.oxigen > 100) {
                astronaut.oxigen = 100;
                console.log(`${astronaut.name} took a breath and recovered ${100 - curOxigen} oxygen!`)
            } else {
                console.log(`${astronaut.name} took a breath and recovered ${amount} oxygen!`)

            }
        }
    }

    astronauts.forEach((astronaut) => console.log(`Astronaut: ${astronaut.name}, Oxygen: ${astronaut.oxigen}, Energy: ${astronaut.energy}`))

}

//solve(['3',
//    'John 50 120',
//    'Kate 80 180',
//    'Rob 70 150',
//    'Explore - John - 50',
//    'Refuel - Kate - 30',
//    'Breathe - Rob - 20',
//    'End']
//);

solve(['4',
    'Alice 60 100',
    'Bob 40 80',
    'Charlie 70 150',
    'Dave 80 180',
    'Explore - Bob - 60',
    'Refuel - Alice - 30',
    'Breathe - Charlie - 50',
    'Refuel - Dave - 40',
    'Explore - Bob - 40',
    'Breathe - Charlie - 30',
    'Explore - Alice - 40',
    'End']
);