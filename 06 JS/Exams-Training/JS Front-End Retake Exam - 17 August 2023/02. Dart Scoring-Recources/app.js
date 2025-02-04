window.addEventListener("load", solve);

function solve() {
    let form = document.querySelector('.scoring-content')
    let playerElement = document.getElementById('player');
    let scoreElement = document.getElementById('score');
    let roundElement = document.getElementById('round');
    let sureListElement = document.getElementById('sure-list');
    let scoreBoardElement = document.getElementById('scoreboard-list');
    let clearBtn = document.querySelector('.btn.clear');
    let addBtn = document.getElementById('add-btn');
    addBtn.addEventListener('click', onAdd);

    function onAdd() {

        if (playerElement.value == '' ||
            scoreElement.value == '' ||
            roundElement == '') {
                return;
            }
    
        let playerP = document.createElement('p');
        //playerP.textContent = '';
        let scoreP = document.createElement('p');
        scoreP.textContent = 'Score: ';
        let roundP = document.createElement('p');
        roundP.textContent = 'Round: ';
        let article = document.createElement('article');

        article.appendChild(playerP);
        article.appendChild(scoreP);
        article.appendChild(roundP);

        let editBtn = document.createElement('button');
        editBtn.textContent = 'edit';
        editBtn.classList.add('btn', 'edit')

        let okBtn = document.createElement('button');
        okBtn.textContent = 'ok';
        okBtn.classList.add('btn', 'ok');

        let dartLi = document.createElement('li')
        dartLi.classList.add('dart-item');
        dartLi.appendChild(article);
        dartLi.appendChild(editBtn);
        dartLi.appendChild(okBtn);

        sureListElement.appendChild(dartLi);
        
        playerP.textContent += playerElement.value;
        let curPlayerP = playerElement.value;
        scoreP.textContent += scoreElement.value;
        let curScoreP = scoreElement.value;
        roundP.textContent += roundElement.value;
        let curRoundP = roundElement.value;
        
        addBtn.disabled = true;
        form.reset();

        editBtn.addEventListener('click', onEdit);
        function onEdit() {
            playerElement.value = curPlayerP;
            scoreElement.value = curScoreP;
            roundElement.value = curRoundP;

            addBtn.disabled = false;

            sureListElement.removeChild(dartLi);
        }

        okBtn.addEventListener('click', onOk);

        function onOk() {

            dartLi.removeChild(editBtn);
            dartLi.removeChild(okBtn);
            scoreBoardElement.appendChild(dartLi);
            sureListElement.removeChild(dartLi);
            addBtn.disabled = false;
           
        }
        clearBtn.addEventListener('click', clear);

        function clear() {
            location.reload();
        }

    }

}
