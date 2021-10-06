
        function LoadDiv(url, lnk) {

            var img = new Image();

            var bcgDiv = document.getElementById("divBackground");

            var imgDiv = document.getElementById("divImage");

            var imgFull = document.getElementById("imgFull");

            var imgLoader = document.getElementById("imgLoader");

            var dl = document.getElementById("<%=DataList1.ClientID%>");

            var imgs = dl.getElementsByTagName("img");





            CurrentPage = GetImageIndex(lnk.parentNode) + 1;

            imgLoader.style.display = "block";

            img.onload = function () {

                imgFull.src = img.src;

                imgFull.style.display = "block";

                imgLoader.style.display = "none";

            };

            img.src = url;

            Prepare_Pager(imgs.length);

            var width = document.body.clientWidth;

            if (document.body.clientHeight > document.body.scrollHeight) {

                bcgDiv.style.height = document.body.clientHeight + "px";

            }

            else {

                bcgDiv.style.height = document.body.scrollHeight + "px";

            }



            imgDiv.style.left = (width - 650) / 2 + "px";

            imgDiv.style.top = "20px";

            bcgDiv.style.width = "100%";



            bcgDiv.style.display = "block";

            imgDiv.style.display = "block";

            return false;

        }

        /*------------------*/
        function HideDiv() {

            var bcgDiv = document.getElementById("divBackground");

            var imgDiv = document.getElementById("divImage");

            var imgFull = document.getElementById("imgFull");

            bcgDiv.style.display = "none";

            imgDiv.style.display = "none";

            imgFull.style.display = "none";

        }
        /*-------------------------------*/
        /*-------------------------------*/
        var CurrentPage = 1;

        function GetImageIndex(obj) {

            while (obj.parentNode.tagName != "TD")

                obj = obj.parentNode;

            var td = obj.parentNode;

            var tr = td.parentNode;

            if (td.rowIndex % 2 == 0) {

                return td.cellIndex + tr.rowIndex;

            }

            else {

                return td.cellIndex + (tr.rowIndex * 2);

            }

        }
        /*-------------------------------*/
        /*-------------------------------*/
        function Prepare_Pager(imgCount) {

            var Previous = document.getElementById("Previous");

            var Next = document.getElementById("Next");

            var lblPrevious = document.getElementById("lblPrevious");

            var lblNext = document.getElementById("lblNext");

            if (CurrentPage < imgCount) {

                lblNext.style.display = "none";

                Next.style.display = "block";

            }

            else {

                lblNext.style.display = "block";

                Next.style.display = "none";

            }

            if (CurrentPage > 1) {

                Previous.style.display = "block";

                lblPrevious.style.display = "none";

            }

            else {

                Previous.style.display = "none";

                lblPrevious.style.display = "block";

            }

        }
        /*-------------------------------------------*/
        /*----------------------------------------*/
        function doPaging(lnk) {

            var dl = document.getElementById("<%=DataList1.ClientID%>");

            var imgs = dl.getElementsByTagName("img");

            var imgLoader = document.getElementById("imgLoader");

            var imgFull = document.getElementById("imgFull");



            var img = new Image();

            if (lnk.id == "Next") {

                if (CurrentPage < imgs.length) {

                    CurrentPage++;

                    imgLoader.style.display = "block";

                    imgFull.style.display = "none";

                    img.onload = function () {

                        imgFull.src = imgs[CurrentPage - 1].src;

                        imgFull.style.display = "block";

                        imgLoader.style.display = "none";

                    };

                }

            }

            else {

                if (CurrentPage > 1) {

                    CurrentPage--;

                    imgLoader.style.display = "block";

                    imgLoader.style.display = "none";

                    img.onload = function () {

                        imgFull.src = imgs[CurrentPage - 1].src;

                        imgFull.style.display = "block";

                        imgLoader.style.display = "none";

                    };

                }

            }

            Prepare_Pager(imgs.length);

            img.src = imgs[CurrentPage - 1].src;

        }
        /*---------------------------------------------*/


