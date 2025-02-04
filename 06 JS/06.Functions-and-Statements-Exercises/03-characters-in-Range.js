function printCharactersInRange(first, second) {

    let range = [];
    
    if (first > second) {
           
        for (let i = second.charCodeAt(0) + 1; i < first.charCodeAt(0); i++) {
                range.push(String.fromCharCode(i))
        }
    }
   

    for (let i = first.charCodeAt(0) + 1; i < second.charCodeAt(0); i++) {
        range.push(String.fromCharCode(i))
    }

    console.log(range.join(' '));
} 

printCharactersInRange('z', 'd');