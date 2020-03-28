
//Javascript for using check box

$(function() {
    $("#CheckAll").click(function() {
        $("input[name='userToDelete']").attr("checked", this.checked);
    });
    $("input[name='userToDelete']").click(function() {
        if ($("input[name='userToDelete']").length == $("input[name='userToDelete']:checked").length) {
            $("#CheckAll").attr("checked", "checked");
        } else {
            $("#CheckAll").removeAttr("checked");
        }
    });
    $("#btnSubmit").click(function() {
        var count = $("input[name='userToDelete']:checked").length;
        if (count == 0) {
            alert("No rows selected selected to delete!");
            return false;
        } else {
            return confirm(count + " row(s) are seleced. Are you wanted to delete?");
        }

    });
});