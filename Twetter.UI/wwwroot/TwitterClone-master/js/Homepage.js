
function postTweet(userid) {
    debugger;
    let text = $("#tweet").val();

    debugger;
    let user = {
        UserId: userid,
        Text: text
    };

    $.ajax({
        type: "POST",
        url: "/Home/Posttweet",
        data: user,
        //dataType :"Json",
        success: function (response) {

        },
        error: function () {

        }
    });
}
//function search() {
//    debugger;
//    let text = $("#search").val();

//    debugger;
//    let user = {
//        Username: text
//    };

//    $.ajax({
//        type: "POST",
//        url: "/Home/Search",
//        data: user,
//        //dataType :"Json",
//        success: function (response) {
//            location.href = "Profile/Index/1";
//        },
//        error: function () {

//        }
//    });
//}

