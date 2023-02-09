// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//function validateEmail() {
//    var email = document.getElementById("EmailID").value;
//    var pattern =  /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-]+$/g;

//    if (!pattern.test(email)) {
//        // Show error message
//        document.getElementById("EmailID").setCustomValidity("Invalid email address");
//    } else {
//        // Remove error message
//        document.getElementById("EmailID").setCustomValidity("");
//    }
//}

//let form = document.querySelector("form");
//let passwordInput = document.querySelector("input[type='password']");

//form.addEventListener("submit", function (event) {
//    event.preventDefault(); // prevent form submission

//    // Check password length
//    let password = passwordInput.value;
//    if (password.length < 8) {
//        passwordInput.setAttribute("style", "border: 1px solid red;");
//        passwordInput.nextElementSibling.innerHTML = "Password must be at least 8 characters long";
//    } else {
//        passwordInput.removeAttribute("style");
//        passwordInput.nextElementSibling.innerHTML = "";
//    }

//    // Additional event handling logic...
//});

//----------------------------------------------------------------------error message duration---------------------------------------------------------------
$(document).ready(function () {
    if ($('#errorMessage').length) {
        setTimeout(function () {
            $('#errorMessage').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

//----------------------------------------------------------------------Sucess message duration---------------------------------------------------------------
$(document).ready(function () {
    if ($('#successMessage').length) {
        setTimeout(function () {
            $('#successMessage').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

//-------------------------------------------------------------------compare password to confirm password----------------------------------------------------------
var password = document.getElementById("password");
var confirmPassword = document.getElementById("Confirm_Password");


// Add an event listener to the form submit button
document.getElementById("submitButton").addEventListener("click", function (event) {
    // Check if the password and confirm password values match
    if (password.value !== confirmPassword.value) {
        // If they do not match, prevent form submission and display an error message
        event.preventDefault();
        alert("Password and Confirm Password do not match");
    }
});

//-----------------------------------------------------------------------Toggle Password Visibility-----------------------------------------------------------------
function togglePassword() {
    var password = document.getElementById("password");
   
    if (password.type === "password") {
        password.type = "text";
    } else {
        password.type = "password";
    }

}
function toggleConfirm_Password() {

    var Confirm_Password = document.getElementById("Confirm_Password");
    if (Confirm_Password.type === "password") {
        Confirm_Password.type = "text";
    } else {
        Confirm_Password.type = "password";
    }
}