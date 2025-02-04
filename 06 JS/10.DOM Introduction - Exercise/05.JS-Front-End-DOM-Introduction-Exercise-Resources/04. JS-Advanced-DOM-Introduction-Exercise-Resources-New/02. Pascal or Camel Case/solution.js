function solve() {
  let input = document.getElementById('text').value;
  let curentType = document.getElementById('naming-convention').value;
  const result = document.getElementById('result');

  input = input.toLowerCase().split(' ');
 
  function pascalCase(input) {
    input = (input) => input.split(' ')
    .map(word => word[0].toUperCase() + word.slice(1))
    .join('');
  }
}

