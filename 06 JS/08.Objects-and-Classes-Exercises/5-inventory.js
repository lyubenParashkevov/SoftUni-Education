function solve(heroData) {
    let heroes = [];
    for (let row of heroData) {

        const [name, level, items] = row.split(' / ')
        const hero = {
            name,
            level: Number(level),
            items,
        }
        heroes.push(hero);
    }

    heroes.sort((a, b) => a.level - b.level);

    for (let hero of heroes) {
        console.log(`Hero: ${hero.name}`);   
        console.log(`level => ${hero.level}`);   
        console.log(`items => ${hero.items}`);   
        }
    
}

solve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]
    );