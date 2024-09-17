// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const input = document.querySelector("#phone");
var iti = window.intlTelInput(input, {
    separateDialCode: true,
    initialCountry: "auto",
    geoIpLookup: callback => {
        fetch("https://ipapi.co/json")
            .then(res => res.json())
            .then(data => callback(data.country_code))
            .catch(() => callback("BH"))
    },
    utilsScript: "https://cdn.jsdelivr.net/npm/intl-tel-input@24.5.0/build/js/utils.js",
});
window.iti = iti;