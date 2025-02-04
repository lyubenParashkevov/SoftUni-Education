function solve(input) {

    let codedWord = input[0];
    let commands = input.slice(1);
    let command ='';
    let message = '';

    for (let line of commands) {
        line = line.split('?');
        command = line[0];
        
        if (command === 'TakeEven') {
            for (let i = 0; i < codedWord.length; i+= 2) {
                message += codedWord[i];
            }
                codedWord = message;
                message = '';
            console.log(codedWord);
            
        }else if (command === 'ChangeAll') {
            let substring = line[1];
            let replacer = line[2];
            while (codedWord.includes(substring)) {

                codedWord = codedWord.replace(substring, replacer)
            }
            
            console.log(codedWord);

        }else if (command === 'Reverse') {
            let substring = line[1];
            if (codedWord.includes(substring)) {

                codedWord = codedWord.replace(substring, '');
                let rversed = Array.from(substring).reverse().join('');
                codedWord+= rversed;
                console.log(codedWord);
            }else {
                console.log('error');
            }
            
        }else {
            
            console.log(`The cryptocurrency is: ${codedWord}`);
        }
        
    }

}

//solve(["z2tdsfndoctsB6z7tjc8ojzdngzhtjsyVjek!snfzsafhscs", 
//"TakeEven",
//"Reverse?!nzahc",
//"ChangeAll?m?g",
//"Reverse?adshk",
//"ChangeAll?z?i",
//"Buy"]
//);

solve(["PZDfA2PkAsakhnefZ7aZ", 
"TakeEven",
"TakeEven",
"TakeEven",
"ChangeAll?Z?X",
"ChangeAll?A?R",
"Reverse?PRX",
"Buy"]
);