window.addEventListener("load", solve);

function solve() {


    let form = document.querySelector('.applyContent')
    let studentElement = document.getElementById('student');
    let universityElement = document.getElementById('university');
    let scoreElement = document.getElementById('score');
    let previewListElement = document.getElementById('preview-list');
    let candidatesElement = document.getElementById('candidates-list');
    // let clearBtn = document.querySelector('.btn.clear');
    let nextBtn = document.getElementById('next-btn');
    nextBtn.addEventListener('click', onNext);

    function onNext() {

        if (studentElement.value == '' ||
            universityElement.value == '' ||
            scoreElement == '') {
            return;
        }

        let header = document.createElement('h4');
        //playerP.textContent = '';
        let universityP = document.createElement('p');
        universityP.textContent = 'University: ';
        let scoreP = document.createElement('p');
        scoreP.textContent = 'Score: ';
        let article = document.createElement('article');

        article.appendChild(header);
        article.appendChild(universityP);
        article.appendChild(scoreP);

        let editBtn = document.createElement('button');
        editBtn.textContent = 'edit';
        editBtn.classList.add('action-btn', 'edit')

        let applyBtn = document.createElement('button');
        applyBtn.textContent = 'apply';
        applyBtn.classList.add('action-btn', 'apply');

        let application = document.createElement('li')
        application.classList.add('application');
        application.appendChild(article);
        application.appendChild(editBtn);
        application.appendChild(applyBtn);

        previewListElement.appendChild(application);

        header.textContent += studentElement.value;
        //let curPlayerP = playerElement.value;
        universityP.textContent += universityElement.value;
        let curUniversityP = universityElement.value;
        scoreP.textContent += scoreElement.value;
        let curScoreP = scoreElement.value;

        nextBtn.disabled = true;
        form.reset();

        editBtn.addEventListener('click', onEdit);
        function onEdit() {
            studentElement.value = header.textContent;
            universityElement.value = curUniversityP;
            scoreElement.value = curScoreP;

            nextBtn.disabled = false;

            previewListElement.removeChild(application);
        }

        applyBtn.addEventListener('click', onApply);

        function onApply() {

                application.removeChild(editBtn);
                application.removeChild(applyBtn);
                candidatesElement.appendChild(application);
                previewListElement.removeChild(application);
                nextBtn.disabled = false;

            }
            //clearBtn.addEventListener('click', clear);

            //function clear() {
            //    location.reload();
            //}

        }

    }

