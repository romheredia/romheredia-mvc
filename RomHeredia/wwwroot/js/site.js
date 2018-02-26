// Write your JavaScript code.

if (document.URL.indexOf("/Blog/Details") >= 0) {
    var postId = document.getElementById("commentsContainer").getAttribute("data-post-id");
    //console.log(postId);
    var webApiUrl = ['/api/posts/', postId, '/comments'].join('/');

    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: webApiUrl,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $("#DIV").html('');
                var DIV = '';
                $.each(data, function (i, item) {
                    var rows = "<tr>" +
                        "<td id='comment'>" + item.body + "</td>" +
                        "</tr>";
                    $('#Table').append(rows);
                }); //End of foreach Loop   
                console.log(data);
            }, //End of AJAX Success function  

            failure: function (data) {
                alert(data.responseText);
            }, //End of AJAX failure function  
            error: function (data) {
                alert(data.responseText);
            } //End of AJAX error function  

        });
    });
}