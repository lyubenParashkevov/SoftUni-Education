function solve(input) {

    let n = input.shift();
    let piece;
    let pieces = [];
    for (let i = 0; i < n; i++) {

         piece = input.shift().split('|')
        piece = {
            name: piece[0],
            author: piece[1],
            key: piece[2],
        }
        pieces.push(piece)

    }

    while (true) {
        let tokens = input.shift().split('|');
        let command = tokens[0];
        if (command === 'Stop') {
            break;
        }

        let name = tokens[1];
        let curPiece = {
            name: tokens[1],
            author: tokens[2],
            key: tokens[3],
        }
        piece = pieces.find((piece) => piece.name === curPiece.name);
              
        if (command === 'Add') {
            let author = tokens[2];
            let key = tokens[3];5
            
            if (piece === undefined) {
                console.log(`${name} by ${author} in ${key} added to the collection!`);
                pieces.push(curPiece);
            }else {
                
                console.log(`${name} is already in the collection!`);
                
            }


        } else if (command === 'Remove') {
            if (piece === undefined) {
                console.log(`Invalid operation! ${name} does not exist in the collection.`);
               
            }else {
                let pieceToRemove = curPiece;
                pieces = pieces.filter((curPiece) => curPiece.name !== pieceToRemove.name);
                console.log(`Successfully removed ${name}!`);
            }
        } else {                                      //Change Key
            if (piece === undefined) {
                console.log(`Invalid operation! ${name} does not exist in the collection.`);
               
            }else {
                let newKey = tokens[2];
                console.log(`Changed the key of ${name} to ${newKey}!`);
                piece.key = newKey;
            }
        }
    }

    for (const piece of pieces) {
        console.log(`${piece.name} -> Composer: ${piece.author}, Key: ${piece.key}`);
        
    }
}

solve([
    '3',
    'Fur Elise|Beethoven|A Minor',
    'Moonlight Sonata|Beethoven|C# Minor',
    'Clair de Lune|Debussy|C# Minor',
    'Add|Sonata No.2|Chopin|B Minor',
    'Add|Hungarian Rhapsody No.2|Liszt|C# Minor',
    'Add|Fur Elise|Beethoven|C# Minor',
    'Remove|Clair de Lune',
    'ChangeKey|Moonlight Sonata|C# Major',
    'Stop'
]);

//solve([
//  '4',
//  'Eine kleine Nachtmusik|Mozart|G Major',
//  'La Campanella|Liszt|G# Minor',
//  'The Marriage of Figaro|Mozart|G Major',
//  'Hungarian Dance No.5|Brahms|G Minor',
//  'Add|Spring|Vivaldi|E Major',
//  'Remove|The Marriage of Figaro',
//  'Remove|Turkish March',
//  'ChangeKey|Spring|C Major',
//  'Add|Nocturne|Chopin|C# Minor',
//  'Stop'
//]);

