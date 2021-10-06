
function onUpdating() {
    alert("ok");
    
    // get the divImage
    var panelProg = $get('divImage');
    // set it to visible
    panelProg.style.display = '';

    // hide label if visible     
   
}

function onUpdated() {
    alert("ok");
    // get the divImage
    var panelProg = $get('divImage');
    // set it to invisible
    panelProg.style.display = 'none';
}