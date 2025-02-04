function search() {
   const townColection = document.getElementById('towns');
   let searchElement = document.getElementById('searchText').value;
   const resultElement = document.getElementById('result');
   let counter = 0;
   const towns = Array.from(townColection.children);

   for (const town of towns) {
      if (town.textContent.toLowerCase().includes(searchElement.toLowerCase())) {
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
         counter++;
      }
   }
      if (searchElement.length === 0) {
         town.style.fontWeight = 'normal';
         town.style.textDecoration = 'none';
      }
   resultElement.textContent = `${counter} matches found`
}
