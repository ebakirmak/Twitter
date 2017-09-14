$(document).ready(function () {

   

    //Tweetler gösterilsin. 1 dakikada bir yeni gelen tweet olup olmadığına bakılack
    function View() {
    
        var vID = $('#gizliTweetID:first').val();
            $.ajax({
            type: "POST",
            url: "/Tweet/View",
            data: '{SonTweetID:"' + vID +
            '"}',
            contentType: "application/json; charset=utf-8",
            success: function (response) {                
                for (var i = 0; i < response.length; i++) {
                    $("#divTweetView").prepend(                   
                   "<div id='#divTweet' class='col-sm-9 col-md-9 col-lg-9 well'>" +
                    "<div class='row'>"+
                     "<div class='col-sm-3 col-md-3 col-lg-3 well'>" +
                        "<p id='pKullanici'>"+response[i].Name+"</p>" +
                        "<img src='~/Img/friends.png' class='img-circle' height='55' width='55' alt='Avatar'>" +
                     "</div>"+
                     "<div class='col-sm-6 col-md-6 col-lg-6'>" + response[i].Tweet +
                        "<input type='hidden' id='gizliTweetID' value='" + response[i].ID + "'/>" +                      
                           "<input type='hidden' id='gizliUserID' value='" + response[i].UserID + "'/>" +
                     "</div>" +
                     "</div>"+
                     "<div class='row'>" +
                     "<div class='col-sm-3 col-md-3 col-lg-3'>"+
                        "<button type='button' id='abc' class='btn btn-default'>" + 'Beğen' + "<span class='glyphicon glyphicon-heart'>" + "</button>" +
                    "<div class='col-sm-6 col-md-6 col-lg-6'>" +
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
    window.setInterval( function () {
        View();
    },5000);




    //Tweet Gönderme Butonu
    $('#btnTweetSend').click(function () {
        var vTweet = $("#txtTweet").val();
        $.ajax({
            type: "POST",
            url: "/Tweet/Send",
            data: '{tweet:"' + vTweet +
                  '"}',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                $('#tweetModal').modal('toggle');
                $('#txtTweet').val("");
            },
            error: function (response) {
                $("#txtTweet").text(response);
            }
        });

    });

    //Tweet Favorilere Alma Butonu
    $('#divTweetView').on('click', '#btnFavorite', function () {
        var TweetID = $(this).attr('gizliTweetID');
        var UserID = $(this).attr('gizliUserID');
        $.ajax({
            type: "POST",
            url: "/Favorites/setFavorites",
            data: '{TweetID:"' + TweetID +
                   '",UserID:"'+UserID+
            '"}',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                

            },
            error: function (response) {
                $("#alert").text(response);
            }
        });
        $(this).text("Beğendin").attr("class", "btn btn-success");
    });
});