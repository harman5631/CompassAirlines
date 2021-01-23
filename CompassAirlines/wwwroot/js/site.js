// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var mouseXY = {};
$(document).on("mousemove", function (event) {
    mouseXY.X = event.pageX;
    mouseXY.Y = event.pageY;
});
var Compass = $("#TheCompass");
var prevXY = { X: null, Y: null };
var CompassInterval = setInterval(function () {


    if (prevXY.Y != mouseXY.Y || prevXY.X != mouseXY.X && (prevXY.Y != null || prevXY.X != null)) {

        var CompassXY = Compass.position();
        var diffX = CompassXY.left - mouseXY.X;
        var diffY = CompassXY.top - mouseXY.Y;
        var tan = diffY / diffX;
        
        var atan = Math.atan(tan) * 180 / Math.PI;;
        if (diffY > 0 && diffX > 0) {

            atan += 180;
        }
        else if (diffY < 0 && diffX > 0) {

            atan -= 180;
        }

        prevXY.X = mouseXY.X;
        prevXY.Y = mouseXY.Y;
        Compass.css({ transform: "rotate(" + atan + "deg)" });
    }
}, 10);