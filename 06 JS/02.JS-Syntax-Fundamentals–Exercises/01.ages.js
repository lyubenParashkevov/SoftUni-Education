function ages(num) {
  let result;
  if(num < 0) {
    result = 'out of bounds'
  }else if(num < 3) {
  result = 'baby'
  }else if(num < 14) {
    result = 'child'
  }else if(num < 20) {
    result = 'teenager'
  }else if(num < 66) {
    result = 'adult'
  }else{
    result = 'elder'
  }
  console.log(result);
  
}

ages(-1)