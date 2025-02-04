function create(words) {

   const contentElement = document.getElementById('content');
  for (const word of words) {
   let divElement = document.createElement('div') 
   let pElement = document.createElement('p');
   pElement.textContent = word;
   pElement.style.display = 'none';
   divElement.appendChild(pElement);
   divElement.addEventListener('click', showText);
   //divElement.addEventListener('click', () =>
   //pElement.style.display = 'block');


  function showText(event) {
     const curElement = event.currentTarget.firstChild;     
     curElement.style.display = 'block';
   
  }
   

   contentElement.appendChild(divElement);
  }


}