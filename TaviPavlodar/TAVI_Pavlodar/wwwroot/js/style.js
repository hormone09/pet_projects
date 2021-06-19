var rele = 0;


function openMenu() {
    var search = document.getElementById('search');
    var links = document.getElementById('links');
    var btn = document.getElementById('searchBtn');

    if (rele == 0) {
        search.style.display = "none";
        links.style.display = "flex";
        btn.innerText = "Поиск";
        rele++;
    }
    else {
        search.style.display = "block";
        links.style.display = "none";
        btn.innerText = "Меню";
        rele = 0;
    }
}

function downAmount(number) {
    var inputs = document.getElementsByClassName('currentInp');
    var count = inputs[number].value;
    if(count > 0)
        inputs[number].value--;
}

function upAmount(number, avalib) {
    var inputs = document.getElementsByClassName('currentInp');
    var count = inputs[number].value;
    if(count < avalib)
        inputs[number].value++;
}

function succes(number) {
    var add = document.getElementsByClassName('succes');
    add[number].style.display = "block";
}


