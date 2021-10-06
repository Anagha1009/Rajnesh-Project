function showMobilesContent() 
{
    document.getElementById('divMobilePhone').style.visibility = 'visible';
    document.getElementById('divDigitalCam').style.visibility = 'hidden';  
    document.getElementById('divLapTop').style.visibility = 'hidden';
    document.getElementById('divCar').style.visibility = 'hidden'; 
    document.getElementById('divBike').style.visibility = 'hidden';
     
}

function showDigitalCamerasContent() 
{
    document.getElementById('divMobilePhone').style.visibility = 'hidden';
    document.getElementById('divDigitalCam').style.visibility = 'visible';  
    document.getElementById('divLapTop').style.visibility = 'hidden';
    document.getElementById('divCar').style.visibility = 'hidden'; 
    document.getElementById('divBike').style.visibility = 'hidden'; 
}

function showLaptopsContent() 
{
    document.getElementById('divMobilePhone').style.visibility = 'hidden';
    document.getElementById('divDigitalCam').style.visibility = 'hidden';  
    document.getElementById('divLapTop').style.visibility = 'visible';
    document.getElementById('divCar').style.visibility = 'hidden'; 
    document.getElementById('divBike').style.visibility = 'hidden';
}

function showCarsContent() 
{
    document.getElementById('divMobilePhone').style.visibility = 'hidden';
    document.getElementById('divDigitalCam').style.visibility = 'hidden';
    document.getElementById('divLapTop').style.visibility = 'hidden';
    document.getElementById('divCar').style.visibility = 'visible'; 
    document.getElementById('divBike').style.visibility = 'hidden';
}

function showBikesContent() 
{
    document.getElementById('divMobilePhone').style.visibility = 'hidden';
    document.getElementById('divDigitalCam').style.visibility = 'hidden';  
    document.getElementById('divLapTop').style.visibility = 'hidden';
    document.getElementById('divCar').style.visibility = 'hidden'; 
    document.getElementById('divBike').style.visibility = 'visible';
}

function Item0()
{
   // alert("Hello");
    document.getElementById('Item0').style.visibility = 'visible';
    document.getElementById('Item1').style.visibility = 'hidden';
    document.getElementById('Item2').style.visibility = 'hidden';

}

function Item1() 
{
   // alert("Hello");
    document.getElementById('Item0').style.visibility = 'hidden';
    document.getElementById('Item1').style.visibility = 'visible';
    document.getElementById('Item2').style.visibility = 'hidden';

}

function Item2()
{
   // alert("Hello");
    document.getElementById('Item0').style.visibility = 'hidden';
    document.getElementById('Item1').style.visibility = 'hidden';
    document.getElementById('Item2').style.visibility = 'visible';

}