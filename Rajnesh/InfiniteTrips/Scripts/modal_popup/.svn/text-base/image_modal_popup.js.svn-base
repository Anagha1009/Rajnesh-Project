//Local variable Declaration
        var imageList = new Array();
        var imageIndex;

        function fnShowPopup(ImageIndex, ImageUrl) {
            alert('hi');
            alert(imageList.length);
            alert(document.images.length);


            var hdfId = document.getElementById("<%=Repeater1.ClientID%>");
            alert(hdfId);
            //Use this below code, if Thumbnail image path and Original image path are SAME 
            for (var i = 0; i < document.images.length; i++) {
                alert('for loop');
                alert(document.images.item(i).id);
                if (document.images.item(i).id.indexOf("Repeater1") != -1) {
                    alert('repeater')
                    imageList[i] = document.images.item(i).src;
                }


                imageIndex = ImageIndex;
                fnEnableNextPrevButtons();

                var modal = $find('ModalPopupExtender1');
                document.getElementById('img_ModalPopUP').src = imageList[imageIndex];
                modal.show();
            }
        }

        function fnEnableNextPrevButtons() {
            if (imageIndex == 0 && imageList.length > 1) {
                document.getElementById("btnPrevious").disabled = true;
                document.getElementById("btnNext").disabled = false;
            }
            else if (imageIndex == imageList.length - 1 && imageList.length > 1) {
                document.getElementById("btnPrevious").disabled = false;
                document.getElementById("btnNext").disabled = true;
            }
            else if (imageList.length == 1) {
                document.getElementById("btnPrevious").disabled = true;
                document.getElementById("btnNext").disabled = true;
            }
            else {
                document.getElementById("btnPrevious").disabled = false;
                document.getElementById("btnNext").disabled = false;
            }
        }

        function fnShowNextImage() {
            if (imageIndex < (imageList.length - 1)) {
                imageIndex++;
                document.getElementById('img_ModalPopUP').src = imageList[imageIndex];
            }
            fnEnableNextPrevButtons();
        }

        function fnShowPreviousImage() {

            if (imageIndex > 0) {
                imageIndex--;
                document.getElementById('img_ModalPopUP').src = imageList[imageIndex];
            }
            fnEnableNextPrevButtons();
        }

        function fnHidePopup() {
            var modal = $find('ModalPopupExtender1');
            modal.hide();
        }