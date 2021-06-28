
function releAnimation(text)
{
    var courses = document.getElementById("courses");
    var marks = document.getElementById("marks");
    var schedule = document.getElementById("schedule");
    var answers = document.getElementById("answers");
    switch(text)
    {
        case 'courses':
            courses.style.display = "flex";
            marks.style.display = "none";
            schedule.style.display = "none";
            answers.style.display = "none";
            break;
        case 'marks':
            marks.style.display = "block";
            courses.style.display = "none";
            schedule.style.display = "none";
            answers.style.display = "none";
            break;
        case 'schedule':
            schedule.style.display = "block";
            courses.style.display = "none";
            marks.style.display = "none";
            answers.style.display = "none";
            break;
        case 'answers':
            schedule.style.display = "none";
            courses.style.display = "none";
            marks.style.display = "none";
            answers.style.display = "block";
            break;
    }
}

var _switch = 0;
function show(className, index) {
    var block = document.getElementsByClassName(className);
    if (_switch == 0) {
        block[index].style.display = "block";
        _switch = 1;
    }
    else {
        block[index].style.display = "none";
        _switch = 0;
    }
}


var _switches = [0, 0, 0, 0, 0];
function navbarShow(blockId, index) {
    var block = document.getElementById(blockId);
    if (_switches[index] == 0) {
        block.style.display = "block";
        _switches[index] = 1;
    }
    else if (_switches[index] != 0) {
        block.style.display = "none";
        _switches[index] = 0;
    }
}

var values = [0, 0, 0, 0, 0, 0, 0, 0, 0];
var header = document.getElementsByClassName('course-header');
function edit(formId, index) {
    var form = document.getElementById(formId);
    if (values[index] == 0) {
        form.style.display = "block";
        values[index] = 1;
        header[0].style.height = "auto";
    }
    else if (values[index] != 0) {
        form.style.display = "none";
        values[index] = 0;
        if (values[1] == 0 && values[2] == 0 && values[3] == 0)
            header[0].style.height = "240px";
    }
}