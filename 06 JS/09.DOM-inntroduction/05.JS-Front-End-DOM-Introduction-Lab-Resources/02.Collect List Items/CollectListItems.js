function extractText() {
   const itemsElements = document.getElementById('items');
   const resultElement = document.getElementById('result');

   let text = itemsElements.textContent;
   resultElement.textContent = text;
}