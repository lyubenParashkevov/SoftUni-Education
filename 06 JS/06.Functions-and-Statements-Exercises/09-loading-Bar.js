function solve(number) {
 
    const progress = (number) => `[${'%'.repeat(number / 10)}${'.'.repeat((100 - number) / 10)}]`;
      
    if (number !== 100) {
        console.log(`${number}% ${progress(number)}`);
        console.log('Still loading...');
    }else {
        console.log('100% Complete!');
        console.log('[%%%%%%%%%%]');
    }  
}

solve(30);
solve(100);
solve(60);