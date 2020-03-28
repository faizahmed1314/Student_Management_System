$(function() {
    $("#btnEditBatch").mouseover(function() {
        $("#btnEditBatch").css("background-color", "red");
    });
    $("#btnEditBatch").mouseout(function() {
        $("#btnEditBatch").css("background-color", "yellowgreen");
    });
});