$(document).ready(function () {
    $(".clickToSearch").click(function () {
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Account/SearchPage', //from account controller - calling SearchPage
            success: function (result) {
                $('#displaySearch').html(result);
            }//initial success - bracket
        });
    });
    //$(".wind-speed-req").submit(function (e) {
    //    e.preventDefault();
    //    console.log("in submit action" + this.Zip);
    //    var Zip = this.Zip;
    //    $.ajax({
    //        url: '/Account/WindSpeedReq', //from account controller - calling SearchPage
    //        type: 'POST',
    //        dataType: 'json',
    //        data: $(this).serialize(),
    //        success: function (result) {
    //            var resultString = "This is the wind forcast for the next 5 days in " + result + ".";

                //$('#speed-list-submit').html(result);

                $(".ZipSearchAcn.btn.btn-primary").click(function () {
                    $.ajax({
                        type: 'GET',
                        dataType: 'html',
                        url: '/Account/SpeedList', //from account controller - calling SearchPage
                        success: function (result) {
                            $('#speed-listing').html(result);
                        }
                    });
                });
            //} windspeed req success bracket//
    //    });
    //});
});// Document ready ending bracket