function solve() {
   const resultElement = document.querySelector('textarea');
   const addButtons = Array.from(document.querySelectorAll('.add-product'));
   const checkOutButton = document.querySelector('button.checkout');
   let products = [];
   let sum = 0;
   for (const button of addButtons) {
      button.addEventListener('click', printProduct);
      
   }

   function printProduct(e) {
      const curProduct = e.currentTarget.parentNode.parentNode;
      const curTitle = curProduct.querySelector('.product-title').textContent;
      let curPrice = curProduct.querySelector('.product-line-price').textContent;
      resultElement.value += `Added ${curTitle} for ${curPrice} to the cart.\n`;
     
      if (!products.includes(curTitle)) {
         products.push(curTitle);
         sum += Number(curPrice).toFixed(2);
      }
   }

   checkOutButton.addEventListener('click', printCheckOut);

   function printCheckOut(e) {
      resultElement.value += `You bought ${products.join(', ')} for ${sum.toFixed(2)}.`;
     
      for (const button of addButtons) {
         button.removeEventListener('click', printProduct);
         
      }
      checkOutButton.removeEventListener('click', printCheckOut);
   }

}