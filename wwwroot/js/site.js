// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// CODE WORKS, COMMENTED BECAUSE OF IPAPI REQUESTS
// Too many rapid requests. Please try again in some time or signup for a paid plan at https://ipapi.co/pricing


try {
    const input = document.querySelector("#phone");
    if (input) {
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
    }
} catch (error) {
    console.error(error);
}
