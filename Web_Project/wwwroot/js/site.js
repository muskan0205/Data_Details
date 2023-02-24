// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.

//////function validateEmail() {
//////    var email = document.getElementById("EmailID").value;
//////    var pattern =  /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-]+$/g;

//////    if (!pattern.test(email)) {
//////        // Show error message
//////        document.getElementById("EmailID").setCustomValidity("Invalid email address");
//////    } else {
//////        // Remove error message
//////        document.getElementById("EmailID").setCustomValidity("");
//////    }
//////}

//////let form = document.querySelector("form");
//////let passwordInput = document.querySelector("input[type='password']");

//////form.addEventListener("submit", function (event) {
//////    event.preventDefault(); // prevent form submission

//////    // Check password length
//////    let password = passwordInput.value;
//////    if (password.length < 8) {
//////        passwordInput.setAttribute("style", "border: 1px solid red;");
//////        passwordInput.nextElementSibling.innerHTML = "Password must be at least 8 characters long";
//////    } else {
//////        passwordInput.removeAttribute("style");
//////        passwordInput.nextElementSibling.innerHTML = "";
//////    }

//////    // Additional event handling logic...
//////});

//////----------------------------------------------------------------------error message duration---------------------------------------------------------------
//////$(document).ready(function () {
//////    if ($('#errorMessage').length).each(function (){
//////        setTimeout(function () {
//////            $('#errorMessage').fadeOut('fast');
//////        }, 2000); // 2 seconds
//////    }
//////});
////$(document).ready(function () {
////    $('.alert-danger#error-message').each(function () {
////        setTimeout(function () {
////            $(this).fadeOut('fast');
////        }, 2000); // 2 seconds
////    });
////});

//////----------------------------------------------------------------------Sucess message duration---------------------------------------------------------------
////$(document).ready(function () {
////    if ($('#successMessage').length) {
////        setTimeout(function () {
////            $('#successMessage').fadeOut('fast');
////        }, 2000); // 2 seconds
////    }
////});

////document.getElementById("submitButton").addEventListener("click", function (event) {
////    let passwordInput = document.querySelector("input[type='password']");
////    let password = passwordInput.value;


////    if (password.length < 8 && password.length != "") {
////        event.preventDefault();
////        //passwordInput.nextElementSibling.innerHTML = "Password must be at least 8 characters long";
////        //passwordInput.nextElementSibling.setAttribute("class", "error-message");
////        alert("Password must be at least 8 characters long");
////    }


////    let confirmPasswordInput = document.querySelector("input[name='Confirm_Password']");
////    let confirmPassword = confirmPasswordInput.value;


////    var password = document.getElementById("password");
////    var confirmPassword = document.getElementById("Confirm_Password");
  
////    if (password.value !== confirmPassword.value) {
////        // If they do not match, prevent form submission and display an error message
////        event.preventDefault();
////        alert("Password and Confirm Password do not match");
////    }
    
////    // Check if the password and confirm password values match
    
////    // Check if the password and confirm password values match

////});

//////document.getElementById("submitButton").addEventListener("click", function (event) {
//////    let passwordInput = document.querySelector("input[type='password']");
//////    let password = passwordInput.value;

//////    let confirmPasswordInput = document.querySelector("input[name='Confirm_Password']");
//////    let confirmPassword = confirmPasswordInput.value;

//////    if (confirmPassword.value !== "") {
//////        if (password.length < 8 && password.length != "") {
//////            event.preventDefault();
//////            alert("Password must be at least 8 characters long");
//////        }
//////    } else {
//////        event.preventDefault();
//////        alert("Null value is not alowed.");
//////    }
//////});





//////-------------------------------------------------------------------compare password to confirm password----------------------------------------------------------
//////var password = document.getElementById("password");
//////var confirmPassword = document.getElementById("Confirm_Password");


//////// Add an event listener to the form submit button
//////document.getElementById("submitButton").addEventListener("click", function (event) {


//////    if (confirmPassword.value == null) {
//////        event.preventDefault();
//////        alert("Null value is not alowed.");
//////    }
//////    // Check if the password and confirm password values match
//////    else if (password.value !== confirmPassword.value) {
//////        // If they do not match, prevent form submission and display an error message
//////        event.preventDefault();
//////        alert("Password and Confirm Password do not match");
//////    }
//////});

////-----------------------------------------------------------------------Toggle Password Visibility-----------------------------------------------------------------
function togglePassword() {
    var password1 = document.getElementById("password");
   
    if (password1.type === "password") {
        password1.type = "text";
    } else {
        password1.type = "password";
    }

}
function toggleConfirm_Password() {

    var Confirm_Password1 = document.getElementById("Confirm_Password");
    if (Confirm_Password1.type === "password") {
        Confirm_Password1.type = "text";
    } else {
        Confirm_Password1.type = "password";
    }
}

//function togglePassword() {
//    var passwordField = $('#password');
//    var passwordFieldType = passwordField.attr('type');
//    if (passwordFieldType == 'password') {
//        passwordField.attr('type', 'text');
//    } else {
//        passwordField.attr('type', 'password');
//    }
//}

//function toggleConfirm_Password() {
//    var confirmPasswordField = $('#Confirm_Password');
//    var confirmPasswordFieldType = confirmPasswordField.attr('type');
//    if (confirmPasswordFieldType == 'password') {
//        confirmPasswordField.attr('type', 'text');
//    } else {
//        confirmPasswordField.attr('type', 'password');
//    }
//}
//$(document).ready(function () {
//    $(".toggle-password").click(function () {
//        var passwordField = $(this).closest('.input-group').find('input[type="password"]');
//        var passwordFieldType = passwordField.attr('type');
//        if (passwordFieldType == 'password') {
//            passwordField.attr('type', 'text');
//        } else {
//            passwordField.attr('type', 'password');
//        }
//    });

//    $(".toggle-confirm-password").click(function () {
//        var confirmPasswordField = $(this).closest('.input-group').find('input[type="password"]');
//        var confirmPasswordFieldType = confirmPasswordField.attr('type');
//        if (confirmPasswordFieldType == 'password') {
//            confirmPasswordField.attr('type', 'text');
//        } else {
//            confirmPasswordField.attr('type', 'password');
//        }
//    });
//});
//-------------------


//$(document).ready(function () {
//    // Get the form and add a submit event listener
//    $('#employee-form').on('submit', function () {
//        // Add a delay before validating the form fields
//        setTimeout(function () {
//            // Loop over each field that has validation errors
//            $('.input-validation-error').each(function () {
//                // Get the error message span element
//                var errorMessage = $(this).next('span.text-danger');
//                // Add the validation time attribute to the span element
//                errorMessage.attr('data-validation-time', '2000');
//            });
//        }, 500);
//    });
//});
//$('form').submit(function () {
//    setTimeout(function () {
//        $('span.field-validation-error').each(function () {
//            if ($(this).html() !== '') {
//                $(this).fadeIn(1000);
//            }
//        });
//    }, 3000); // Set the delay to 3 seconds (3000 milliseconds)
//});



////////error message
//$(document).ready(function () {
//    var errorMessage = '@TempData["#error-message-1"]';
//    if (errorMessage) {
//        $('#error-message-1').html(errorMessage);
//        $('#error-message-1').show();
//    }
//});
$(document).ready(function () {
    if ($('#error-message-1').length) {
        setTimeout(function () {
            $('#error-message-1').fadeOut('fast');
        }, 3000); // 2 seconds
    }
});


//$(document).ready(function () {
//    var errorMessage = '@TempData["#error-message-2"]';
//    if (errorMessage) {
//        $('#error-message-2').html(errorMessage);
//        $('#error-message-2').show();
//    }
//});
$(document).ready(function () {
    if ($('#error-message-2').length) {
        setTimeout(function () {
            $('#error-message-2').fadeOut('fast');
        }, 3000); // 2 seconds
    }
});



//$(document).ready(function () {
//    var errorMessage = '@TempData["#error-message-3"]';
//    if (errorMessage) {
//        $('#error-message-3').html(errorMessage);
//        $('#error-message-3').show();
//    }
//});
$(document).ready(function () {
    if ($('#error-message-3').length) {
        setTimeout(function () {
            $('#error-message-3').fadeOut('fast');
        }, 3000); // 2 seconds
    }
});



//$(document).ready(function () {
//    var errorMessage = '@TempData["#error-message-4"]';
//    if (errorMessage) {
//        $('#error-message-4').html(errorMessage);
//        $('#error-message-4').show();
//    }
//});
$(document).ready(function () {
    if ($('#error-message-4').length) {
        setTimeout(function () {
            $('#error-message-4').fadeOut('fast');
        }, 3000); // 2 seconds
    }
});



//$(document).ready(function () {
//    var errorMessage = '@TempData["#error-message-5"]';
//    if (errorMessage) {
//        $('#error-message-5').html(errorMessage);
//        $('#error-message-5').show();
//    }
//});
$(document).ready(function () {
    if ($('#error-message-5').length) {
        setTimeout(function () {
            $('#error-message-5').fadeOut('fast');
        }, 3000); // 2 seconds
    }
});



//$(document).ready(function () {
//    var errorMessage = '@TempData["#error-message-6"]';
//    if (errorMessage) {
//        $('#error-message-6').html(errorMessage);
//        $('#error-message-6').show();
//    }
//});
$(document).ready(function () {
    if ($('#error-message-6').length) {
        setTimeout(function () {
            $('#error-message-6').fadeOut('fast');
        }, 3000); // 2 seconds
    }
});



//$(document).ready(function () {
//    var errorMessage = '@TempData["#error-message-7"]';
//    if (errorMessage) {
//        $('#error-message-7').html(errorMessage);
//        $('#error-message-7').show();
//    }
//});
$(document).ready(function () {
    if ($('#error-message-7').length) {
        setTimeout(function () {
            $('#error-message-7').fadeOut('fast');
        }, 3000); // 2 seconds
    }
});



//$(document).ready(function () {
//    var errorMessage = '@TempData["#error-message-8"]';
//    if (errorMessage) {
//        $('#error-message-8').html(errorMessage);
//        $('#error-message-8').show();
//    }
//});
$(document).ready(function () {
    if ($('#error-message-8').length) {
        setTimeout(function () {
            $('#error-message-8').fadeOut('fast');
        }, 3000); // 2 seconds
    }
});



//$(document).ready(function () {
//    var errorMessage = '@TempData["#error-message-9"]';
//    if (errorMessage) {
//        $('#error-message-9').html(errorMessage);
//        $('#error-message-9').show();
//    }
//});
$(document).ready(function () {
    if ($('#error-message-9').length) {
        setTimeout(function () {
            $('#error-message-9').fadeOut('fast');
        }, 3000); // 2 seconds
    }
});



//$(document).ready(function () {
//    var errorMessage = '@TempData["#error-message-10"]';
//    if (errorMessage) {
//        $('#error-message-10').html(errorMessage);
//        $('#error-message-10').show();
//    }
//});
$(document).ready(function () {
    if ($('#error-message-10').length) {
        setTimeout(function () {
            $('#error-message-10').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});



//$(document).ready(function () {
//    var errorMessage = '@TempData["#error-message-11"]';
//    if (errorMessage) {
//        $('#error-message-11').html(errorMessage);
//        $('#error-message-11').show();
//    }
//});
$(document).ready(function () {
    if ($('#error-message-11').length) {
        setTimeout(function () {
            $('#error-message-11').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});



//$(document).ready(function () {
//    var errorMessage = '@TempData["#error-message-12"]';
//    if (errorMessage) {
//        $('#error-message-12').html(errorMessage);
//        $('#error-message-12').show();
//    }
//});
$(document).ready(function () {
    if ($('#error-message-12').length) {
        setTimeout(function () {
            $('#error-message-12').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});



//$(document).ready(function () {
//    var errorMessage = '@TempData["#error-message-13"]';
//    if (errorMessage) {
//        $('#error-message-13').html(errorMessage);
//        $('#error-message-13').show();
//    }
//});
$(document).ready(function () {
    if ($('#error-message-13').length) {
        setTimeout(function () {
            $('#error-message-13').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});



//$(document).ready(function () {
//    var errorMessage = '@TempData["#error-message-14"]';
//    if (errorMessage) {
//        $('#error-message-14').html(errorMessage);
//        $('#error-message-14').show();
//    }
//});
$(document).ready(function () {
    if ($('#error-message-14').length) {
        setTimeout(function () {
            $('#error-message-14').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

$(document).ready(function () {
    if ($('#error-message-15').length)
    {
        setTimeout(function ()
        {
            $('#error-message-15').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

$(document).ready(function () {
    if ($('#error-message-16').length) {
    setTimeout(function () {
        $('#error-message-16').fadeOut('fast');
    }, 2000); // 2 seconds
}
});

//////////////////
//$(document).ready(function () {
//    if ($('#error-message-15').length) {
//        setTimeout(function () {
//            $('#error-message-15').fadeOut('fast');
//        }, 2000); // 2 seconds
//    }
//});
$(document).ready(function () {
    if ($('#error-message-17').length) {
        setTimeout(function () {
            $('#error-message-17').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});


$(document).ready(function () {
    if ($('#error-message-20').length) {
        setTimeout(function () {
            $('#error-message-20').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});
$(document).ready(function () {
    if ($('#error-message-21').length) {
        setTimeout(function () {
            $('#error-message-21').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});
$(document).ready(function () {
    if ($('#error-message-22').length) {
        setTimeout(function () {
            $('#error-message-22').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});
$(document).ready(function () {
    if ($('#error-message-23').length) {
        setTimeout(function () {
            $('#error-message-23').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});
$(document).ready(function () {
    if ($('#error-message-24').length) {
        setTimeout(function () {
            $('#error-message-24').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});


$(document).ready(function () {
    if ($('#error-message-31').length) {
        setTimeout(function () {
            $('#error-message-31').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});
$(document).ready(function () {
    if ($('#error-message-32').length) {
        setTimeout(function () {
            $('#error-message-32').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});
$(document).ready(function () {
    if ($('#error-message-33').length) {
        setTimeout(function () {
            $('#error-message-33').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});
$(document).ready(function () {
    if ($('#error-message-34').length) {
        setTimeout(function () {
            $('#error-message-34').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

$(document).ready(function () {
    if ($('#error-message-51').length) {
        setTimeout(function () {
            $('#error-message-51').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});




//////////Custormer ----------------------------------------------------


$(document).ready(function () {
    if ($('#error-message-71').length) {
        setTimeout(function () {
            $('#error-message-71').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});
$(document).ready(function () {
    if ($('#error-message-72').length) {
        setTimeout(function () {
            $('#error-message-72').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});
$(document).ready(function () {
    if ($('#error-message-73').length) {
        setTimeout(function () {
            $('#error-message-73').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

$(document).ready(function () {
    if ($('#error-message-74').length) {
        setTimeout(function () {
            $('#error-message-74').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

$(document).ready(function () {
    if ($('#error-message-81').length) {
        setTimeout(function () {
            $('#error-message-81').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

$(document).ready(function () {
    if ($('#error-message-82').length) {
        setTimeout(function () {
            $('#error-message-82').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});
$(document).ready(function () {
    if ($('#error-message-83').length) {
        setTimeout(function () {
            $('#error-message-83').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});
$(document).ready(function () {
    if ($('#error-message-84').length) {
        setTimeout(function () {
            $('#error-message-84').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

$(document).ready(function () {
    if ($('#error-message-91').length) {
        setTimeout(function () {
            $('#error-message-91').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

//$(document).ready(function () {
//    ['error-message-1', 'error-message-2', 'error-message-3', 'error-message-4', 'error-message-5', 'error-message-6', 'error-message-7'].forEach(function (id) {
//        if ($('#' + id).length) {
//            setTimeout(function () {
//                $('#' + id).fadeOut('fast');
//            }, 2000); // 2 seconds
//        }
//    });
//});


$(document).ready(function () {
    if ($('#Success-Message-1').length) {
        setTimeout(function () {
            $('#Success-Message-1').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});
$(document).ready(function () {
    if ($('#Success-Message-3').length) {
        setTimeout(function () {
            $('#Success-Message-3').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

$(document).ready(function () {
    if ($('#Success-Message-4').length) {
        setTimeout(function () {
            $('#Success-Message-4').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

$(document).ready(function () {
    if ($('#Success-Message-5').length) {
        setTimeout(function () {
            $('#Success-Message-5').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

$(document).ready(function () {
    if ($('#Success-Message-11').length) {
        setTimeout(function () {
            $('#Success-Message-11').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});


$(document).ready(function () {
    if ($('#Success-Message-21').length) {
        setTimeout(function () {
            $('#Success-Message-21').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});


$(document).ready(function () {
    if ($('#Success-Message-41').length) {
        setTimeout(function () {
            $('#Success-Message-41').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});


//////////custormer-------------------------

$(document).ready(function () {
    if ($('#Success-Message-71').length) {
        setTimeout(function () {
            $('#Success-Message-71').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

$(document).ready(function () {
    if ($('#Success-Message-81').length) {
        setTimeout(function () {
            $('#Success-Message-81').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});

$(document).ready(function () {
    if ($('#Success-Message-91').length) {
        setTimeout(function () {
            $('#Success-Message-91').fadeOut('fast');
        }, 2000); // 2 seconds
    }
});