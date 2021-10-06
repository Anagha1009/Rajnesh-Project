window.load(deletecook());
var CountItem = eval(CountItem);
var hyrText;
function setParameter() {
    var c = 0;
}

function ChkCounter(val) {
    if (typeof ChkCounter.counter == 'undefined') {
        ChkCounter.counter = 0;
    }
    if (val == 1) {
        if (typeof ChkCounter.counter == 'undefined') {
            ChkCounter.counter = 0;
        }
        ChkCounter.counter++;
    }
    else if (val == 0) {
        if (typeof ChkCounter.counter == 'undefined') {
            ChkCounter.counter = 0;
        }
        ChkCounter.counter--;
    }
    //alert(ChkCounter.counter);
}

function CurrPageIndex(PageIndex) {
    //if (typeof CurrPageIndex.PIndex == 'undefined') 
    if (PageIndex == 0) {
        CurrPageIndex.PIndex = 0;
    }
    else {
        CurrPageIndex.PIndex = PageIndex;
    }
}


function deletecook() {
    var d = new Date();
    document.cookie = "PID=; expires=Thu, 01-Jan-10 00:00:01 GMT";   //  + d.toGMTString() + ";" + ";";
    //if want to Delete cookie in PageLoad the Execute above stmt.

}


function insertthisproduct(CheckBox, hltext, ProductID, sectionid, pg, Count) {
  
   // alert("Hello");
    var CompareText;
    var CntNum = 0;
    
    var gvCheckBoxId;
    var num = 1;
    var arrCnt = 0;

    //var gvTblCnt = document.getElementById('ContentPlaceHolder1_lstProductList_ctrl0_tdtemplate').coloumns.length;
    var gvTblCnt = Count;

    var hdfId = document.getElementById('ContentPlaceHolder1_hdfChkBoxCnt').value;
   // alert(hdfId);

    var ChkBxId = document.getElementById('<%= this.lstProductList.ClientID %>');
    
    var cntchkbox = gvTblCnt;  //ChkBxId.rows.length;  //modified 2
  
    var mycheck = document.getElementById(CheckBox);
    //alert(mycheck);
    var ChkBxId1 = document.getElementById(CheckBox).id;
    var divTag = document.createElement("span");
    var imgImage = document.createElement("img");
    hyrText = hltext;
    CurrPageIndex(pg)
    ChkCounter(5);
    if (mycheck.checked == true)      //CntNum
    {
        if (ChkCounter.counter < 3) {
            
            ChkCounter(1);
            imgImage.src = "/admin/images/close_button.gif";
            imgImage.setAttribute("Onclick", "1");
            
            divTag.id = "div" + hltext;
            divTag.setAttribute("align", "left");
            
            var parahltext = "'" + hltext + "'";
            var paraChkBox = "'" + CheckBox + "'";
            var PID = "'" + ProductID + "'";
            var PgInx = "'" + pg + "'";
            // divTag.innerHTML = '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' + '<img id="' + hltext + '" src="http://admin.comparepricesindia.com/admin/images/close_button1.gif" onclick="RemoveItem(' + parahltext + ',' + paraChkBox + ',' + PID + ',' + PgInx + ')" style="cursor:pointer;" alt="compare" />' + " " + hltext;
            divTag.innerHTML = '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' + '<img id="' + hltext + '"  onclick="RemoveItem(' + parahltext + ',' + paraChkBox + ',' + PID + ',' + PgInx + ')" style="cursor:pointer;" alt="" />' + " " + hltext;
            document.body.appendChild(divTag);

            setCookie(ProductID, hltext, CheckBox, pg);
            
            document.getElementById('ContentPlaceHolder1_divCompare').appendChild(divTag);

        }
        else {
            mycheck.checked = false;
            alert("You can Select Only 3 Items!");
        }
    }
    else {
        //CompareText = document.getElementById('ContentPlaceHolder1_txtCompareItems');
        //var CompareString = CompareText.value;
        //var FRtext = hltext + "    ";
        //CompareText.value = CompareString.replace(FRtext, "");
        var d = document.getElementById('ContentPlaceHolder1_divCompare');
        var divid = "div" + hltext;
        var olddiv = document.getElementById(divid);
        var SpanDivId = olddiv.id;
        var ReStr2 = "PID=" + ProductID + "&" + CheckBox + "&" + pg + ",";
        //alert(ReStr2);
        var CookieStr2 = document.cookie;
        var MCookieStr2 = CookieStr2.replace(ReStr2, "");
        document.cookie = MCookieStr2;
        d.removeChild(olddiv);
        ChkCounter(0);

        if (ChkCounter.counter == 0) {
            //alert("insertthisproduct ==> Product in Cookies are..... " + ChkCounter.counter);
            document.cookie = "PID=; expires=Thu, 01-Jan-10 00:00:01 GMT";
        }
    }
}

function RemoveItem(did, chkBox, ProdID, PageIndx) {
    //alert(CurrPageIndex.PIndex);
    var CurrPIndex = CurrPageIndex.PIndex;
    var AllIds = new Array();
    var d = document.getElementById('ContentPlaceHolder1_divCompare');
    var mychk = document.getElementById(chkBox);
    var imgId = document.getElementById(did).id;
    var divid = "div" + did;
    var olddiv = document.getElementById(divid);
    var SString = did + ProdID;
    var ProdIDExist = document.cookie.indexOf(ProdID);
    var len = ProdIDExist + ProdID.length + 1;
    var StartPID = document.cookie.substring(0, ProdID.length);
    //alert(ProdIDExist + " - " + StartPID + " - " + len);
    var DupProdId = ProdID;
    var PPID = document.cookie.split(',');
    var temp = 0;
    ChkCounter(0);
    for (var j = 0; j < PPID.length - 1; j++) {
        var chkedId = PPID[j].split('&');
        //alert(chkedId + "  -");
        for (var k = 0; k < chkedId.length; k++) {
            var SpEle = chkedId[k].split(',');
            //alert(SpEle + " - " + k + " - " + chkedId[k]);
            AllIds[k] = SpEle;
        }

        //var UniId = chkedId[k].replace("PID=", "");
        var UniId = AllIds[0];
        var gvCheckBoxId = AllIds[1];
        var gvPageIndex = AllIds[2];
        var ProductId = "PID=" + ProdID;
        //alert(UniId + " -- " + gvCheckBoxId + " -- " + gvPageIndex + " -- " + ProductId);
        if (CurrPIndex == gvPageIndex) {
            if (UniId == ProductId) {
                var iddiv = "PID=" + UniId;
                var ReStr = "PID=" + ProdID + "&" + chkBox + "&" + PageIndx + ",";
                //alert(UniId + " = " + ProductId + " ----- " + ReStr + " == " + PageIndx + " , " + gvPageIndex);
                var CookieStr = document.cookie;
                var MCookieStr = CookieStr.replace(ReStr, "");
                document.cookie = MCookieStr;
                d.removeChild(olddiv);
                mychk.checked = false;
            }
        }
        else {
            if (UniId == ProductId) {
                var iddiv1 = "PID=" + UniId;
                var ReStr1 = "PID=" + ProdID + "&" + chkBox + "&" + PageIndx + ",";
                //alert(iddiv1 + " - else - " + ReStr1);
                //alert(UniId + " = " + ProductId + " ----- " + ReStr1 + " == " + PageIndx + " , " + gvPageIndex + " - else - ");
                var CookieStr1 = document.cookie;
                var MCookieStr1 = CookieStr1.replace(ReStr1, "");
                document.cookie = MCookieStr1;
                d.removeChild(olddiv);
                //alert(mychk.checked);  
            }
        }
    }
    if (ChkCounter.counter == 0) {
        //alert("RemoveItem ==> Product in Cookies are....." + ChkCounter.counter);
        document.cookie = "PID=; expires=Thu, 01-Jan-10 00:00:01 GMT";
    }
}

function SetChkBoxPageCng(pIndex, gvTblCnt) {
    debugger;
//alert("Set");
   // alert(pIndex + "-" + gvTblCnt);
    CurrPageIndex(pIndex);
    var CompareText;
    var CntNum = 0;
    var gvCheckBoxId;
    var num = 1;
    var arrCnt = 0;
    //var gvTblCnt = document.getElementById('ContentPlaceHolder1_lstProductList').rows.length;
    //var hdfProdId = document.getElementById('ContentPlaceHolder1_gv_ProductList_hdfProductId_0').value;
    var ChkBxId = document.getElementById('<%= this.gv_ProductList.ClientID %>');
    var cntchkbox = gvTblCnt;  //ChkBxId.rows.length;  //modified 2
    //alert(gvTblCnt);
    for (var i = 0; i < cntchkbox; i++) {

        var checkboxidgv = "ContentPlaceHolder1_lstProductList_ctrl0_chkCompare_" + i;
       // alert(checkboxidgv);
        

       // var hdfId = "lstProductList_hdfProductId_" + i;
        var hdfId = "ContentPlaceHolder1_lstProductList_ctrl0_hdfProductId_" + i;
      //  alert(hdfId);
        var hdfProdId = document.getElementById(hdfId).value;
      //  alert(hdfProdId + "--" + checkboxidgv);
        ChkUnChkPID(hdfProdId, checkboxidgv)

        //gvCheckBoxId = document.getElementById(checkboxidgv);
        //if (gvCheckBoxId.checked == true) 
        //{
        //    CntNum = CntNum + 1;
        //}
    }
}

function ChkUnChkPID(hdfPID, ChkBoxId) {
   // alert(hdfPID + "--" + ChkBoxId);
    var gvChk = document.getElementById(ChkBoxId);
    var PPID = document.cookie.split(',');
    var temp = 0;
    for (var j = 0; j < PPID.length - 1; j++) {
        var chkedId = PPID[j].split('&');
        //alert(chkedId + "  -");
        for (var k = 0; k < chkedId.length - 1; k++) {
            var SpEle = chkedId[k].split(',');
            var UniqId = chkedId[k].replace("PID=", "");
            //alert(UniId + " = " + hdfPID);
            //var UniId = PPID[j].replace("PID=", "");
            if (UniqId == hdfPID) {
                //var iddiv = "PID=" + UniId;
                //var ReStr = "PID=" + ProdID + ",";
                //var CookieStr = document.cookie;
                //var MCookieStr = CookieStr.replace(ReStr, "");
                //document.cookie = MCookieStr;
                //d.removeChild(olddiv);
                gvChk.checked = true;
            }
        }
    }
}

function setCookie(hlID, hText, value, pgIndex)  //exdays
{
    //var exdate = new Date();
    //exdate.setDate(exdate.getDate() + exdays);
    //var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
    //document.cookie = hlID + "=" + value + ";";
    document.cookie += "PID" + "=" + hlID + "&" + value + "&" + pgIndex + ",;";

}  