function openLogin() {
    var position = $("#linkLogin").position();
    var sb = $("#divLogin").stop(true, true), w = sb.is(":visible") ? position.left : position.left - 280;
    sb.animate({ width: "toggle", height: "toggle", left: w }, 1000);
    //$("#divLogin").toggle("slow");	
}

function requstcall_back() {
    var position = $("#request").position();
    var sb = $("#divRequest").stop(true, true), w = sb.is(":visible") ? position.left : position.left - 120;
    sb.animate({ width: "toggle", height: "toggle", left: w }, 1000);
    //$("#divLogin").toggle("slow");	
}

$(document).ready(function () {
    var position = $("#linkLogin").position();
    $("#divLogin").css("left:" + position.left);
});