// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).on('submit', '#Login',function (e){
    e.preventDefault();
    $.ajax({
        beforeSend: function(){
            $('#Registar button[type=submit]').prop('disable',true);
        },
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function(data){
            window.location='/home'
            alert("Bienvenido"+ data.correo);
        },
        error:function(xhr, status){
            alert(xhr.responseJSON.Message);
        },
        complete: function(){
            $('#Registar button[type=submit]').prop('disable',false);
        }
    })


});


$(document).on('submit', '#Registrar',function (e){
    e.preventDefault();
    $.ajax({
        beforeSend: function(){
            $('#Registar button[type=submit]').prop('disable',true);
        },
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function(data){
           
            alert("Bienvenido"+ data.correo+", Ya puedes iniciar Sessión");
            window.location='/home'
        },
        error:function(xhr, status){
            alert(xhr.responseJSON.Message);
        },
        complete: function(){
            $('#Registar button[type=submit]').prop('disable',false);
        }
    })


});