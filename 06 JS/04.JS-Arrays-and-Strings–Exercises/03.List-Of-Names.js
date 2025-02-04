function printNames(names) {
    names.sort((a, b) => a.localeCompare(b))//.filter(x => x != false);
    
    for (let i = 0; i < names.length; i++) {       
            console.log(`${i + 1}.${names[i].trim()}`)     
    }
}

printNames(["John", "Bob", " Christina", "ema"]);

