
$('#order-cake-submit').click(function (event) {
    var $form = $("#order-cake-form");

    var data = $form.serialize();
    var url = $form.attr('action');

    $.post(url, data).done(function () {
        $('#order-button-modal').modal();
    });
    
});