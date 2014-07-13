$(document).ready(function () {
    NewsEvents.PageLoad.BindGrid();
    //NewsEvents.PageLoad.ShowPopup();
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
                                Description: { type: "string", validation: { required: true } },
                                Is_Active: { type: "boolean" },
                                Posted_Date: { editable: false, nullable: true },
                            }
                        }
                    },
                    type: "GET",
                    dataType: "json",
                    transport: {
                        read: "NewsList"
                        , update: {
                            url: "Update",
                            dataType: "json"
                        },
                        destroy: {
                            url: "DeleteNews",
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

                    , { command: ["edit","destroy"], title: "&nbsp;", width: "170px" }
                ]
                , editable: true
                , editable: "popup"
            });

        },
    },
}//end NewsEvents