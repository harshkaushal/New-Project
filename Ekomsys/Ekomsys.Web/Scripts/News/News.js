$(document).ready(function () {
    NewsEvents.PageLoad.BindGrid();
    NewsEvents.PageLoad.ShowPopup();
});

var NewsEvents = {

    PageLoad: {
        BindGrid: function () {

            $("#grid").kendoGrid({
                dataSource: {
                    schema: {
                        parse: function (response) {
                            $.each(response, function (idx, elem) {
                                if (elem.Posted_Date && typeof elem.Posted_Date === "string") {
                                    elem.Posted_Date = kendo.parseDate(elem.Posted_Date, "yyyy-MM-ddTHH:mm:ss.fffZ");
                                }
                            });
                            return response;
                        },
                        model: {
                            id: "News_Id",
                            fields: {
                                News_Id: { editable: false, nullable: true },
                                Title: { validation: { required: true } },
                                Description: { type: "string", validation: { required: true, min: 1 } },
                                Posted_Date: { editable: false, nullable: true },
                            }
                        }
                    },
                    type: "GET",
                    dataType: "json",
                    transport: {
                        read: "NewsList"
                        , update: {
                            url: "News",
                            dataType: "json"
                        },
                        create: {
                            url: "News",
                            dataType: "json",
                            type: "Post"
                        },
                    },
                    pageSize: 20
                },
                toolbar: ["create"],
                height: 550,
                groupable: true,
                sortable: true,
                pageable: {
                    refresh: true,
                    pageSizes: true,
                    buttonCount: 5
                },
                columns: [{
                    field: "Title",
                    title: "Title",
                    width: 200
                }, {
                    field: "Description",
                    title: "News Description"
                }, {
                    field: "Posted_Date",
                    title: "Posted On",
                    format: "{0:dd MMM yyyy}"
                }

                    , { command: ["edit"], title: "&nbsp;", width: "80px" }
                ]
                , editable: true
                , editable: "popup"
            });

        },
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
            NewsEvents.SaveUpdateEvents.SaveNews();
        }
    },
    SaveUpdateEvents: {
        SaveNews: function () {
            //alert("call");
            $("#submit").on("click", function () {
                //  alert("click");
                var form = $("form#myForm");
                form.attr("action", "/Admin/News");
                form.submit();
            });

            //NewsModel= {
            //    Description: undefined,
            //    Is_Active: undefined,
            //    Title: undefined,
            //    News_Image: undefined
            //}

            //NewsModel.Description = $("#jQNewsDescription").val();
            //NewsModel.Is_Active = $("#jQNewsActive").is(":checked");
            //NewsModel.Title = $("#jQNewsTitle").val();

            //$.ajax({
            //    type: "POST", url: uri + "UpdateAboutMe", contentType: "application/json", dataType: "html",
            //    async: false,
            //    data: JSON.stringify(UserModel),
            //    beforeSend: function () { //$(".JQAboutMeEditSection").html(loadingimage);
            //        ajaxStart($(document).height());
            //    },
            //    success: function (result) {
            //        //$(".JQAboutMeEditSection").html(result);
            //        closeAjaxProgress();
            //        if (_updateType == "About") {
            //            // $(".jQAboutMeMain").fadeIn(15000, function () {
            //            $(".jQAboutMeMain").html(result);
            //            //});
            //        }
            //        if (_updateType == "Contact") {
            //            //$("#jQContactMe").fadeIn(15000, function () {
            //            $("#jQContactMe").html(result);
            //            //});
            //        }
            //    },
            //    error: function (err) {
            //        showAlertMessage("Error = " + err.statusText);
            //        closeAjaxProgress();
            //    }
            //});

        }//end SaveUpdateEvents.SaveNews
    }//end NewsEvents.SaveUpdateEvents
}//end NewsEvents