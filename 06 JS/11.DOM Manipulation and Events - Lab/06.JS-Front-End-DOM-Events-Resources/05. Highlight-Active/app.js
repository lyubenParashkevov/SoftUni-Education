function focused() {
   const inputElements = document.getElementsByTagName('input');
    let elements = Array.from(inputElements);




   for (const element of elements) { 
        element.addEventListener('focus', focusOn);
        element.addEventListener('blur', focusOff);
   }

   function focusOn(element) {
        element.target.parentNode.classList.add('focused');
   }

   function focusOff(element) {
    element.target.parentNode.classList.remove('focused');
   }
}