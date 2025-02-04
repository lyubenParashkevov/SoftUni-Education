window.addEventListener("load", solve);

document.querySelector("form").addEventListener("submit", function(event) {
    event.preventDefault();
});

function solve() {
    let typeOfelement = document.getElementById('type');
    let ageInputElement = document.getElementById('age');
    let genderElement = document.getElementById('gender');

    let checkListElement = document.getElementById('adoption-info');
    let adopedListElement = document.getElementById('adopted-list');

    let adoptBtn = document.getElementById('adopt-btn');

    adoptBtn.addEventListener('click', onAdd);

    function onAdd() {

        if (typeOfelement.value == '' ||
            ageInputElement.value == '' ||
            genderElement.value == '') {
            return;
        }

        let typeP = document.createElement('p');
        typeP.textContent = 'Pet:';
        
        let ageP = document.createElement('p');
        ageP.textContent = 'Age:';

        let genderP = document.createElement('p');
        genderP.textContent = 'Gender:';


        let article = document.createElement('article');

        article.appendChild(typeP);
        article.appendChild(genderP);
        article.appendChild(ageP);

        let editBtn = document.createElement('button');
        editBtn.classList.add('edit-btn')
        editBtn.textContent = 'Edit';

        let doneBtn = document.createElement('button');
        doneBtn.classList.add('done-btn');
        doneBtn.textContent = 'Done';

        let clearBtn = document.createElement('button');
        clearBtn.classList.add('clear-btn');
        clearBtn.textContent = 'Clear';

        let divButtons = document.createElement('div');
        divButtons.classList.add('buttons')

        divButtons.appendChild(editBtn);
        divButtons.appendChild(doneBtn);

        let liElement = document.createElement('li');

        liElement.appendChild(article);
        liElement.appendChild(divButtons);

        typeP.textContent += typeOfelement.value;
        let curtypeP = typeOfelement.value;
        ageP.textContent += ageInputElement.value;
        let curAgeP = ageInputElement.value;
        genderP.textContent += genderElement.value;
        let curGenderP = genderElement.value;

        checkListElement.appendChild(liElement);
        //addBtn.disabled = true;

        typeOfelement.value = '';
        ageInputElement.value = '';
        genderElement.value = '';




        editBtn.addEventListener('click', onEdit);
        function onEdit() {
            typeOfelement.value = curtypeP;
            ageInputElement.value = curAgeP;
            genderElement.value = curGenderP;
        
            //addBtn.disabled = false;
        
            checkListElement.removeChild(liElement);
        }
        
        doneBtn.addEventListener('click', onSave);
        
        function onSave() {
        
            //liElement.removeChild(editBtn);
            //liElement.removeChild(okBtn);
            liElement.removeChild(divButtons);
            liElement.appendChild(clearBtn);
            adopedListElement.appendChild(liElement);
            checkListElement.removeChild(liElement);
            //addBtn.disabled = false;
        
        }
        clearBtn.addEventListener('click', clear);
        
        function clear() {
            //location.reload();
            adopedListElement.removeChild(liElement);
        }
    }

}
