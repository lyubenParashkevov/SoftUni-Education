function solve(input) {
    let text = input.shift();
    let message = '';
    while (true) {
        let tokens = input.shift().split('!');
        let command = tokens[0];
        if (command === 'End') {
            break;
        } 

        if (command === 'RemoveEven') {
            for (let i = 0; i < text.length; i+= 2) {
                message += text[i];
            }
            text = message;
            
            message = '';
                
            console.log(text);

        }else if (command === 'TakePart') {
            let start = Number(tokens[1]);
            let end = Number(tokens[2]);
            text = text.slice(start, end);
            console.log(text);

        }else {                                   //Reverse
            let substring = tokens[1];
            if (text.includes(substring)) {

                text = text.replace(substring, '');
                let rversed = Array.from(substring).reverse().join('');
                text+= rversed;
                console.log(text);
            }else {
                console.log('Error');
            }
        }
    }

    console.log(`The concealed spell is: ${text}`)

}

solve(["asAsl2adkda2mdaczsa",
    "RemoveEven",
    "TakePart!1!9",
    "Reverse!maz",
    "End"]);


//solve(["asAsl2adkda2mdaczsa",
//"RemoveEven",
//"TakePart!1!9",
//"Reverse!maz",
//"End"]);
