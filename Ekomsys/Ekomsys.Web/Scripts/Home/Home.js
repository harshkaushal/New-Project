$(document).ready(function () {

    HomeEvents.PageLoad.PageContent(1);
});

var HomeEvents = {

    PageLoad: {

        //divPageContent
        PageContent: function (pageId) {
            $.ajax({
                type: "POST", url: "LoadPageContent", contentType: "application/json", dataType: "html",
                data: "{pageId:'" + pageId + "'}",
                async: false,
                beforeSend: function () { //$(".JQAboutMeEditSection").html(loadingimage);
                    //ajaxStart($(document).height());
                },
                success: function (result) {
                    //closeAjaxProgress();
                    $("#divPageContent").html(result);
                    HomeEvents.PageLoad.SubMenuClick();
                },
                error: function (err) {
                    //showAlertMessage("Error = " + err.statusText);
                }
            });
        },//end PageLoad.PageContent

        SubMenuClick: function () {
            $(".jQPageMenu").on("click", function () {
                HomeEvents.PageLoad.PageContent($(this).attr("tagpageid"));
            });
        },//end PageLoad.SubMenuClick

    }//end HomeEvents.PageLoad
}//end HomeEvents