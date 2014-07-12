$(document).ready(function () {
    NewsEvents.PageLoad.ShowPopup();
});

var NewsEvents = {

    PageLoad:{
        ShowPopup: function () {
            var window = $("#window"),
            undo = $("#jQanchorShowDialog").bind("click", function () {
                window.data("kendoWindow").open();
                undo.hide();
            });

            var onClose = function () {
                undo.show()
            }
            if (!window.data("kendoWindow")) {

                window.kendoWindow({
                    width: "600px",
                    title: "Test Add News",
                    actions: ["Pin", "Maximize", "Minimize", "Close"],
                    close: onClose
                });
            }
        }
    },
    SaveUpdateEvents: {
        SaveNews: function () {
            NewsModel= {
                Description: undefined,
                Is_Active: undefined,
                Title: undefined,
                News_Image: undefined
            }

            NewsModel.Description = $("#jQNewsDescription").val();
            NewsModel.Is_Active = $("#jQNewsActive").is(":checked");
            NewsModel.Title = $("#jQNewsTitle").val();
            
            $.ajax({
                type: "POST", url: uri + "UpdateAboutMe", contentType: "application/json", dataType: "html",
                async: false,
                data: JSON.stringify(UserModel),
                beforeSend: function () { //$(".JQAboutMeEditSection").html(loadingimage);
                    ajaxStart($(document).height());
                },
                success: function (result) {
                    //$(".JQAboutMeEditSection").html(result);
                    closeAjaxProgress();
                    if (_updateType == "About") {
                        // $(".jQAboutMeMain").fadeIn(15000, function () {
                        $(".jQAboutMeMain").html(result);
                        //});
                    }
                    if (_updateType == "Contact") {
                        //$("#jQContactMe").fadeIn(15000, function () {
                        $("#jQContactMe").html(result);
                        //});
                    }
                },
                error: function (err) {
                    showAlertMessage("Error = " + err.statusText);
                    closeAjaxProgress();
                }
            });

        }//end SaveUpdateEvents.SaveNews
    }//end NewsEvents.SaveUpdateEvents
}//end NewsEvents