$(document).ready(function () {
    $(".clickToSearch").click(function () {
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Account/SearchPage', //from account controller - calling SearchPage
            success: function (result) {
                $('#displaySearch').html(result);
            }
        });
    });
});