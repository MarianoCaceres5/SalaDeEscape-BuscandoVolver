// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

setInterval(function () {    

    if(parseInt($("#segundos").html()) <= 3600){
        $("#segundos").html(parseInt($("#segundos").html())+1);  
    }  
    
},1000);

