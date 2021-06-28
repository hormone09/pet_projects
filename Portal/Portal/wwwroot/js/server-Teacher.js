$.ajax({
    url: 'https://localhost:44378/teacher-navbar',
    success: function AddNavbar(result) {
        let navbar = JSON.parse(result);

        //Информация о преподавателе
        var navbarName = document.getElementById('navbar-name');
        var navbarGroup = document.getElementById('navbar-group');
        navbarName.innerText = navbar.TeacherName;
        navbarGroup.innerText = navbar.GroupName;

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

function sendForm(formId) {
    var form = document.getElementById(formId);
    $.ajax({
        type: "POST",
        url: "https://localhost:44378/" + formId,
        dataType: "html",
        data: $("#" + formId).serialize(),
        success: function (result) {
            if (result == "true") {
                location.reload();
                alert("Succes!");
            }
            else {
                form.style.border = "2px solid red";
            }
        }
    })
};