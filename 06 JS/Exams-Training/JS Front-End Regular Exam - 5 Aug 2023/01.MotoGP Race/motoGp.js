function solve(input) {

    let n = Number(input.shift());
    let riders = [];

    for (let i = 0; i < n; i++) {
        let rider = input.shift().split('|');
        rider = {
            name: rider[0],
            fuel: Number(rider[1]),
            position: Number(rider[2]),

        }
            riders.push(rider);
    }

    while (true) {

        let tokens = input.shift().split(' - ');
        let command = tokens[0];

        if (command === 'Finish') {
            break;
        }
        
        let name = tokens[1];
        let rider = riders.find(rider => rider.name === name);

        if (command === 'StopForFuel') {
            let minFuel = Number(tokens[2]);
            let newPosition = Number(tokens[3]);
            if (rider.fuel < minFuel) {
                console.log(`${rider.name} stopped to refuel but lost his position, now he is ${newPosition}.`);
                rider.position = newPosition;
            }else {
                console.log(`${rider.name} does not need to stop for fuel!`)
            }

        }else if (command === 'Overtaking') {
           //let firstRiderName = tokens[1];
            let secondRiderName = tokens[2];

            //let firstRider = riders.find(r => r.name === firstRiderName);
            let secondRider = riders.find(r => r.name === secondRiderName);
            if (rider.position < secondRider.position) {
                let curPosition = rider.position;
                rider.position = secondRider.position;
                secondRider.position = curPosition;
                console.log(`${rider.name} overtook ${secondRiderName}!`)

            }



        }else {                         //EngineFail
            let lapsLeft = Number(tokens[2]);

            console.log(`${rider.name} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);
            let riderToRemove = rider;
            riders = riders.filter((rider) => rider.name !== riderToRemove.name);


            
        }
    }

    for (const rider of riders) {
        console.log(`${rider.name}`);
        console.log(`  Final position: ${rider.position}`)

    }

}


//solve(["3",
//"Valentino Rossi|100|1",
//"Marc Marquez|90|2",
//"Jorge Lorenzo|80|3",
//"StopForFuel - Valentino Rossi - 50 - 1",
//"Overtaking - Marc Marquez - Jorge Lorenzo",
//"EngineFail - Marc Marquez - 10",
//"Finish"])


solve(["4",
"Valentino Rossi|100|1",
"Marc Marquez|90|3",
"Jorge Lorenzo|80|4",
"Johann Zarco|80|2",
"StopForFuel - Johann Zarco - 90 - 5",
"Overtaking - Marc Marquez - Jorge Lorenzo",
"EngineFail - Marc Marquez - 10",
"Finish"]);
