
function sendForm(formId) {

    $.ajax({
        type: "POST",
        url: "https://localhost:44378/" + formId,
        dataType: "html",
        data: $("#" + formId).serialize(),
        success: function (result) {
            $(`form[name=${formId}]`).trigger('reset');
            alert(result);
        }
    })
};