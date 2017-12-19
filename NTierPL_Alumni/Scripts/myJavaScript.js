$(document).ready(function () {
    $('#show_password').on('mouseover', function () {
        $(this).attr('type', 'text');
    });
    $('#show_password').on('mouseout', function () {
        $(this).attr('type', 'password');
    })
});


//a show password function that shows two kind of input.
//text type when you hover or mouseover.
//password type when you unhover or mouseout.