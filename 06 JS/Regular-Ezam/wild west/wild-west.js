function solve(input) {
    let n = Number(input.shift());

    let cowboys = [];
    //let cowboy = {};
    let command;

    for (let i = 0; i < n; i++) {
        let cowboy = input.shift().split(' '); 
        cowboy = {
            name: cowboy[0],                                                   
            hitpoints: Number(cowboy[1]),
            bullets: Number(cowboy[2]),                                                          
        }
            
        cowboys.push(cowboy);
    }

    while (true) {
        let tokens = input.shift().split(' - ');
        command = tokens[0];
        let name = tokens[1];
        let cowboy = cowboys.find(cowboy => cowboy.name === name);
       
        if (command === 'Ride Off Into Sunset') {
            break;
        }

        if (command === 'FireShot') {
            let target = tokens[2];
            if (cowboy.bullets > 0) {
                cowboy.bullets--;
                console.log(`${cowboy.name} has successfully hit ${target} and now has ${cowboy.bullets} bullets!`);
            }else {
                console.log(`${cowboy.name} doesn't have enough bullets to shoot at ${target}!`);
            }
    
        } else if (command === 'TakeHit') {
            let damage = Number(tokens[2]);
            let attacker = tokens[3];
            cowboy.hitpoints -= damage;
            if (cowboy.hitpoints > 0) {
                console.log(`${cowboy.name} took a hit for ${damage} HP from ${attacker} and now has ${cowboy.hitpoints} HP!`);
            }else {
                console.log(`${cowboy.name} was gunned down by ${attacker}!`);
                let cowboyToRemove = cowboy;
                cowboys = cowboys.filter((cowboy) => cowboy.name !== cowboyToRemove.name);

            }

        } else if(command === 'Reload') {
            if (cowboy.bullets < 6) {
                console.log(`${cowboy.name} reloaded ${6 - cowboy.bullets} bullets!`);
                cowboy.bullets += (6 - cowboy.bullets);



            }else {
                console.log(`${cowboy.name}'s pistol is fully loaded!`);
            }

        }else {                                                    //PachUp
            let amount = Number(tokens[2]);
            if (cowboy.hitpoints < 100) {
                let curHitPoints = cowboy.hitpoints;
               
                cowboy.hitpoints += amount;
                if (cowboy.hitpoints > 100) {
                    cowboy.hitpoints = 100;
                    console.log(`${cowboy.name} patched up and recovered ${100 - curHitPoints} HP!`);
                }else {
                    console.log(`${cowboy.name} patched up and recovered ${amount} HP!`);
                }
            }else {
                console.log(`${cowboy.name} is in full health!`);
            }

        }                                   
                  
    }

    for (const cowboy of cowboys) {
        console.log(`${cowboy.name}`);
        console.log(` HP: ${cowboy.hitpoints}`);
        console.log(` Bullets: ${cowboy.bullets}`);
    }
    
}

//solve(['2',
//'Gus 100 0',
//'Walt 100 6',
//'TakeHit - Gus - 80 - Bandit',
//'PatchUp - Gus - 20',
//'Ride Off Into Sunset'])

solve(["2",
"Gus 100 1",
"Walt 100 5",
"FireShot - Gus - Bandit",
"TakeHit - Walt - 100 - Bandit",
"Reload - Gus",
"Ride Off Into Sunset"]);


