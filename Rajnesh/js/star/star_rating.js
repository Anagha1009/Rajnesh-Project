function RegisterStarRatingScript() { $(".auto-submit-star").rating({ callback: function (t) { $("#hdfldStarValue1").attr("value", t), $(document.getElementById("Button1"))[0].click() } }) } $(function () { $(".auto-submit-star").rating({ callback: function (t) { $("#ctl00_cp_main_institute1_hdfldStarValue").attr("value", t), $(document.getElementById("ctl00_cp_main_institute1_Button1"))[0].click() } }) });