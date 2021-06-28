//navbar
$.ajax({
    url: 'https://localhost:44378/navbar',
    success: function AddNavbar(result) {
        let navbar = JSON.parse(result);

        //Информация о студенте
        var navbarName = document.getElementById('navbar-name');
        var navbarGroup = document.getElementById('navbar-group');
        navbarName.innerText = navbar.StudentName;
        navbarGroup.innerText = navbar.GroupName;

        //Пары сегодня
        var subjectsBox = document.getElementById('subjects-today');
        if (navbar.IsHasSubjectsToday == true) {
            navbar.SubjectsToday.forEach(element =>
                subjectsBox.innerHTML += '<div class="flex-box" style="margin: 20px 0px;"><p>' +
                element.Name + '</p >' + '<p>' + element.Time +
                '</p></div > '
            );
        }
        else {
            subjectsBox.innerHTML = '<div><p>' + 'Today have not subjects!' + '</p></div>';
        }

        //Расписание на сегодня
        var scheludeBox = document.getElementById('schelude-today');
        if (navbar.IsHasSchedule) {
            navbar.Schelude.forEach(subject =>
                scheludeBox.innerHTML +=
                '<div class="flex-box">' +
                '<p>' + subject.Name + '</p>' +
                '<p>' + subject.Time + '</p>' +
                '</div>'
            );
        }
        else {
            scheludeBox.innerText = "Schedule not set!";
        }

        //Уведомления
        var notificationsBox = document.getElementById('notifications');
        var countBlock = document.getElementById('count'); 
        if (!navbar.IsHasNotifications) {
            var infoMessage = "<h4>You has not notifications!</h4>";
            notificationsBox.innerHTML = infoMessage;
            countBlock.innerText = 0;
        }
        else {
            countBlock.innerText = navbar.Notifications.length;
            navbar.Notifications.forEach(notif => { 
                var head = notif.Head;
                var message = notif.Message;
                var notification = "";
                notification += "<div class='flex-box'>" +
                    "<p>" + head + "</p>" + "<p>" + message + "</p>" +
                "</div> ";
                notificationsBox.innerHTML += notification;
            });
        }
    }
});



function sendForm(formId, index) {
    var block = document.getElementsByClassName('answer');
    $.ajax({
        type: "POST",
        url: "https://localhost:44378/addAnswer",
        dataType: "html",
        data: $("#" + formId).serialize(),
        success: function (result) {
            if (result == "true") {
                block[index].innerHTML = '<h3 class="info-message"></h3>';
                var messages = document.getElementsByClassName('info-message');
                var message = messages[index];
                message.innerText = "Succes!";
            }
            else {
                message.innerText = "Failed!";
            }
        }
    })
};

function deleteNotifications() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44378/DeleteNotifications",
        success: function () {
            var notifBlock = document.getElementById('notifications');
            var count = document.getElementById('count');
            count.innerText = "0";
            var infoMessage = "<h4>You has not notifications!</h4>";
            notificationsBox.innerHTML = infoMessage;
        }
    })
}