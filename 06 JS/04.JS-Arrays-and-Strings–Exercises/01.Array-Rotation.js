function rotation(numbers, count) {
    
    for (let i = 0; i < count; i++) {
         let curNum = numbers.shift();
         numbers.push(curNum);
     }
     console.log(numbers.join(' '));
}

rotation([32, 21, 61, 1], 4)