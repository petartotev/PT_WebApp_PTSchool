// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// When the user scrolls the page, execute myFunction - used in Playlists/All and Users/All.
window.onscroll = function () { myFunction() };
function myFunction() {
    var winScroll = document.body.scrollTop || document.documentElement.scrollTop;
    var height = document.documentElement.scrollHeight - document.documentElement.clientHeight;
    var scrolled = (winScroll / height) * 100;
    if (document.getElementById("myBar") != null) {
        document.getElementById("myBar").style.width = scrolled + "%";
    }
}