//$(function () {
//    $("#textSearch").autocomplete({
//        source: '@Url.Action("GetBatches")'
//    });
  
//});


var subdirectory = "../../";


$(function() {
    $("#textSearch").autocomplete({
        source:function(request, response) {
            $.ajax({
                url: subdirectory + "Batch/GetBatches",
                data: "{'searchTerm':'" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function(data) {
                    response($.map(data, function(item) {
                        return item;
                    }));
                }

        });
        },
        minLenth:1
    });
});



//$(document).ready(function() {
//    $("#textSearch").autocomplete({
//        source: function (request, response) {
//            $.ajax({
//                url: "../Batch/GetBatches",
//                dataType: "json",
//                data: { searchTerm: $("#textSearch").val() },
//                success: function (data) {
//                    response($.map(data, function (item) {
//                        return { label: item.batch1, value: item.batch1 };
//                    }));
//                },
//                error: function (xhr, status, error) {
//                    alert("Error");
//                }
//            });
//        }
//    });
//});

