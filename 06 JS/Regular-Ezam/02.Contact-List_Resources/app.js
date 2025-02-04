window.addEventListener("load", solve);

function solve() {
    
    let nameElement = document.getElementById('name');
    let phoneNumberElement = document.getElementById('phone');
    let categoryElement = document.getElementById('category');
    let checkListElement = document.getElementById('check-list');
    let contacktListElement = document.getElementById('contact-list');
    
    let addBtn = document.getElementById('add-btn');
    addBtn.addEventListener('click', onAdd);

    function onAdd() {

        if (nameElement.value == '' ||
            phoneNumberElement.value == '' ||
            categoryElement.value == '') {
            return;
        }

        let nameP = document.createElement('p');
        nameP.textContent = 'name:';
        let phoneP = document.createElement('p');
        phoneP.textContent = 'phone:';
        let categoryP = document.createElement('p');
        categoryP.textContent = 'category:';

        let article = document.createElement('article');

        article.appendChild(nameP);
        article.appendChild(phoneP);
        article.appendChild(categoryP);

        let editBtn = document.createElement('button'); 
        editBtn.classList.add('edit-btn')

        let saveBtn = document.createElement('button'); 
        saveBtn.classList.add('save-btn');

        let deleteBtn = document.createElement('button');
        deleteBtn.classList.add('del-btn');

        let divButtons = document.createElement('div');
        divButtons.classList.add('buttons')

        divButtons.appendChild(editBtn);
        divButtons.appendChild(saveBtn);

        let liElement = document.createElement('li');
        
        liElement.appendChild(article);
        liElement.appendChild(divButtons);
               
        nameP.textContent += nameElement.value;
        let curNameP = nameElement.value;
        phoneP.textContent += phoneNumberElement.value;
        let curPhoneP = phoneNumberElement.value;
        categoryP.textContent += categoryElement.value;
        let curCategoryP = categoryElement.value;

        checkListElement.appendChild(liElement);
        //addBtn.disabled = true;
       
        nameElement.value = '';
        phoneNumberElement.value = '';
        categoryElement.value = '';



        editBtn.addEventListener('click', onEdit);
        function onEdit() {
            nameElement.value = curNameP;
            phoneNumberElement.value = curPhoneP;
            categoryElement.value = curCategoryP;

            //addBtn.disabled = false;

            checkListElement.removeChild(liElement);
        }

        saveBtn.addEventListener('click', onSave);

        function onSave() {

            //liElement.removeChild(editBtn);
            //liElement.removeChild(okBtn);
            liElement.removeChild(divButtons);
            liElement.appendChild(deleteBtn);
            contacktListElement.appendChild(liElement);
            checkListElement.removeChild(liElement);
            //addBtn.disabled = false;

        }
        deleteBtn.addEventListener('click', clear);

        function clear() {
            //location.reload();
            contacktListElement.removeChild(liElement);
        }

    }
}
