window.addEventListener("load", solve);

function solve() {

    //let formElement = document.querySelector("form");
    let expenseTypeElement = document.getElementById('expense');
    let amountElement = document.getElementById('amount');
    let dateElement = document.getElementById('date');
    let addButton = document.getElementById('add-btn');
    let deleteBtn = document.querySelector('.delete');

    addButton.addEventListener('click', onAdd);

    function onAdd() {
        if (expenseTypeElement.value == '' ||
            amountElement.value == '' ||
            dateElement.value == '') 
            {
            return;
        }
        let previewListElement = document.getElementById('preview-list');
        let expenseListElement = document.getElementById('expenses-list');


        let expenseItems = document.createElement('li');
        expenseItems.classList.add('expense-item');

        let article = document.createElement('article');

        let typeP = document.createElement('p');
        typeP.textContent = `Type: ${expenseTypeElement.value}`;
        let typePonEdit = expenseTypeElement.value;

        let amountP = document.createElement('p');
        amountP.textContent = `Amount: ${amountElement.value}$`;
        let amountPonEdit = amountElement.value;

        let dateP = document.createElement('p');
        dateP.textContent = `Date: ${dateElement.value}`;
        let datePonEdit = dateElement.value;

        article.appendChild(typeP);
        article.appendChild(amountP);
        article.appendChild(dateP);

        let editBtn = document.createElement('button');
        editBtn.classList.add('btn');
        editBtn.classList.add("edit");  // !!! second class ????
        editBtn.textContent = 'edit';
        editBtn.addEventListener('click', onEdit);

        let okBtn = document.createElement('button');
        okBtn.textContent = 'ok';
        okBtn.classList.add('btn');
        okBtn.classList.add("ok"); // !!!! second class ????

        okBtn.addEventListener('click', onOk);

        let buttons = document.createElement('div');
        buttons.classList.add('buttons');

        buttons.appendChild(editBtn);
        buttons.appendChild(okBtn);

        expenseItems.appendChild(article);
        expenseItems.appendChild(buttons);

        previewListElement.appendChild(expenseItems);

        addButton.disabled = true;
        //formElement.reset();
        expenseTypeElement.value = '';
        amountElement.value = '';
        dateElement.value = '';


        function onEdit() {
            expenseTypeElement.value = typePonEdit;
            amountElement.value = amountPonEdit;
            dateElement.value = datePonEdit;

            previewListElement.removeChild(expenseItems);
            addButton.disabled = false;
        }

        function onOk() {
            previewListElement.removeChild(expenseItems)
            expenseListElement.appendChild(expenseItems);
            expenseItems.removeChild(buttons);

            addButton.disabled = false;
            deleteBtn.addEventListener('click', onDelete);

            function onDelete() {
                location.reload();
            }
        }
    }

}


