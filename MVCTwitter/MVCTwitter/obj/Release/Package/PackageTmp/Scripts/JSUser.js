/// <reference path="JSTweet.js" />
/// <reference path="JSTweet.js" />
/// <reference path="JSTweet.js" />
/// <reference path="JSTweet.js" />
$(document).ready(function () {
    //Kayıt Olma Butonu
    $('#btnSignUp').click(function () {
        var vName = $("#txtRegName").val();
        //var vSurname = $("#txtSurname").val();
        var vEmail = $("#txtRegMail").val();
        var vPassword = $("#txtRegPass").val();
     
     
        $.ajax({
            type: "POST",
            url: "/User/SignUp",
            data: '{Name:"' + vName +                  
                  '",Username:"'+vName+
                  '",Email:"' + vEmail +
                  '",Password:"' + vPassword +
                  '"}',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                alert("Kayıt Olma Başarılı");
               
            },            
            error: function (response) {
                alert("Kayıt Olma Başarısız");
            }            
        });
       
    });
    var profileName;
    //Giriş Butonu
    $('#btnLogin').click(function () {
        var vMail = $("#txtLoginMail").val();
        var vPassword = $("#txtLoginPass").val();
        $.ajax({
            type: "POST",
            url: "/User/Login",
            data: '{EMail: "' + vMail +
                  '",Password:"' + vPassword +
                  '"}',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                $('#loginModal').modal('toggle');
                location.reload();

            },
            error: function (response) {
                alert(response.responseText);
            }
        });
        profileName = vMail;
    }).delay(1000)
    View();
  

    //Çıkış Butonu
    $('#btnExit').click(function () {
        $.ajax({
            type: "POST",
            url: "/User/Exit",            
            contentType: "application/json; charset=utf-8",
            success: function (response) {                
                    location.reload();
            },
            error: function (response) {
                alert(response.responseText+"SADA");
            }
        });
    });
    function View() {
        $.ajax({
            type: "POST",
            url: "/Tweet/View",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                for (var i = response.length - 1; i >= 0; i--) {
                    $("#divTweetView").append(
                 "<div id='divTweet' class='col-sm-9 col-md-9 col-lg-9 well'>" +
                    "<div class='row'>" +
                     "<div class='col-sm-3 col-md-3 col-lg-3 well'>" +
                        "<p id='pKullanici'>" + response[i].Name + "</p>" +
                        "<img src='~/Img/friends.png' class='img-circle' height='55' width='55' alt='Avatar'>" +
                     "</div>" +
                     "<div class='col-sm-6 col-md-6 col-lg-6'>" + response[i].Tweet +
                        "<input type='hidden' id='gizliTweetID' value='" + response[i].ID + "'/>" +
                         "<input type='hidden' id='gizliUserID' value='" + response[i].UserID+ "'/>" +
                     "</div>" +
                     "</div>" +
                  "<div class='row'>" +
                     "<form method='post'>"+
                     "<div class='col-sm-3 col-md-3 col-lg-3'>" +
                        "<button type='button' gizliTweetID='" + response[i].ID + "' gizliUserID='" + response[i].UserID + "' id='btnFavorite' class='btn btn-default'>" + 'Beğen' + "<span class='glyphicon glyphicon-heart'>" + "</button>" +
                     "</div>"+
                    "<div class='col-sm-6 col-md-6 col-lg-6'>" +
                    "</div>" +
                    "</div>"+
                  "</div>" +
               "</div>");


                }

            },
            error: function (response) {
                $("#alert").text(response);
            }
        });
    }

});