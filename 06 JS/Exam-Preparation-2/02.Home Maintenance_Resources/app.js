window.addEventListener("load", solve);

function solve() {

    const place = document.getElementById('place');
    const action = document.getElementById('action');
    const person = document.getElementById('person');

    const tasks = document.getElementById('task-list');
    const addButton = document.getElementById('add-btn');
    const doneTasks = document.getElementById('done-list');


    addButton.addEventListener('click', onAdd);

    function onAdd() {
        if (place.value === '' ||
            action.value === '' ||
            person.value === '') {
            return;
        }

        const placeP = document.createElement('p');
        const actionP = document.createElement('p')
        const personP = document.createElement('p');
        const articleTag = document.createElement('article');
        const editbtn = document.createElement('button');
        const donebtn = document.createElement('button');
        const divButtons = document.createElement('div');
        const cleanTaskLi = document.createElement('li');
        const deletebtn = document.createElement('button');


        articleTag.appendChild(placeP);
        articleTag.appendChild(actionP);
        articleTag.appendChild(personP);

        editbtn.classList.add('edit');
        editbtn.textContent = 'Edit';
        donebtn.classList.add('done');
        donebtn.textContent = 'Done';

        divButtons.classList.add("buttons");
        divButtons.appendChild(editbtn);
        divButtons.appendChild(donebtn);

        cleanTaskLi.classList.add('clean-task');
        cleanTaskLi.appendChild(articleTag);
        cleanTaskLi.appendChild(divButtons);

        placeP.textContent = place.value;
        actionP.textContent = action.value;
        personP.textContent = person.value;

        tasks.appendChild(cleanTaskLi);

        clearInput();

        editbtn.addEventListener('click', sendToInput);
        donebtn.addEventListener('click', sendToDoneList);
        deletebtn.addEventListener('click', clearDoneList)

        function sendToInput() {
            place.value = placeP.textContent;
            action.value = actionP.textContent;
            person.value = personP.textContent;
            
            tasks.removeChild(cleanTaskLi);
        }

        function sendToDoneList() {

            deletebtn.classList.add('delete');
            deletebtn.textContent = 'Delete';
            cleanTaskLi.removeChild(divButtons);
            cleanTaskLi.appendChild(deletebtn);
            tasks.removeChild(cleanTaskLi);
            doneTasks.appendChild(cleanTaskLi);

        }

        function clearDoneList() {
            doneTasks.removeChild(cleanTaskLi);
        }

        function clearParagraps() {
            placeP.textContent = '';
            actionP.textContent = '';
            personP.textContent = '';

        }

        function clearInput() {
            place.value = '';
            action.value = '';
            person.value = '';

        }
    }
}


