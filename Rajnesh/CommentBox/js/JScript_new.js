jQuery(function () {
    dropdowncontent.init("hyp_Conty", "right-bottom", 400, "mouseover");
});

function fn_getPopup() {
    $('#InfoBox').reveal($(this).data());
}

$(function () {
    $(".RateIt").children().hide();
    $(".RateIt")
				.stars({
				    inputType: "select",
				    cancelValue: 0,
				    cancelShow: false
				})
});

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode != 40 && charCode != 41 && charCode != 43 && charCode != 45 && charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

$(document).ready(function () {
    $("#content div._tabbox").hide(); // Initially hide all content
    $("#tabs li:first").attr("id", "current"); // Activate first tab
    $("#content div:first").fadeIn(); // Show first tab content

    $('#tabs a').click(function (e) {
        e.preventDefault();
        if ($(this).closest("li").attr("id") == "current") { //detection for current tab
            return
        }
        else {
            $("#content div._tabbox").hide(); //Hide all content
            $("#tabs li").attr("id", ""); //Reset id's
            $(this).parent().attr("id", "current"); // Activate this
            $('#' + $(this).attr('name')).fadeIn(); // Show content for current tab
        }
    });

    $(".ui-stars-star").live("click", function () {
        $("#hf_Rate").val($("#hf_Rate").parent().find("input[type=hidden]").last().val());
    });

});

$(window).load(function () {
    $(document).ready(function () {
        $(".hyp_Reply").click(function () {
            var target = $(this).parent().children(".ReplyBox");
            $(target).slideToggle();
        });
    });
});