function toggle() {
   const buttonTextElement = document.querySelector('.head span.button');
   const textElement =document.getElementById('extra');

   if (buttonTextElement.textContent === 'More') {
    textElement.style. display = 'block';
    buttonTextElement.textContent = 'Less';
   }else {
       textElement.style. display = 'none';
       buttonTextElement.textContent = 'More';
   }
   
}