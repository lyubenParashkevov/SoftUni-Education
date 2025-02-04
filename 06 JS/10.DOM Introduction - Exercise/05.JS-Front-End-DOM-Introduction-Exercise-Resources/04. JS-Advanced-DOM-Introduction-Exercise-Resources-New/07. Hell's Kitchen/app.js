function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      const input = (document.querySelector('textarea').value).split('","');
      const bestRestorantElement = document.querySelector('#bestRestaurant p');
      const bestWorkersElement = document.querySelector('#workers p');

      console.log(typeof input);



   }
}