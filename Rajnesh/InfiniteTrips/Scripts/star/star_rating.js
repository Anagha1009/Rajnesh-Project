function RegisterStarRatingScript(){$(".auto-submit-star").rating({callback:function(a,b){$("#hdfldStarValue1").attr("value",a);$(document.getElementById("Button1"))[0].click()}})}$(function(){$(".auto-submit-star").rating({callback:function(a,b){$("#hdfldStarValue1").attr("value",a);$(document.getElementById("Button1"))[0].click()}})})