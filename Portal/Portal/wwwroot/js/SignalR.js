var connection = new signalR.HubConnectionBuilder()
    .withUrl("/notifications").build();
connection.start();

connection.on("WasConnected", function (result) {
    console.log(result);
});

connection.on("NewNotification", function (head, message) {
    var countValue = document.getElementById('count').innerText;
    var newValue = Number(countValue);
    newValue++;
    document.getElementById('count').innerText = newValue;


    var notificationBlock = document.getElementById('newNotif');
    notificationBlock.style.display = "block";
    var flexBox = "<div class='flex-box'>" +
        "<p>" + head + "</p>" + "<p>" + message + "</p>"
    "</div >";
    notificationBlock.innerHTML += flexBox;
    setTimeout(() => notificationBlock.style.display = "none", 10000);
    

    var notificationsBox = document.getElementById('notifications'); var notification = "";
    notification += "<div class='flex-box'>" +
        "<p>" + head + "</p>" + "<p>" + message + "</p>" +
    "</div> ";
    if (newValue > 1)
        notificationsBox.innerHTML += notification;
    else
        notificationsBox.innerHTML = notification;

});
