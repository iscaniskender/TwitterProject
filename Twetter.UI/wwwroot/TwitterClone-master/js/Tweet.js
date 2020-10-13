function Like(takipciid, tweetid,rtactive) {
    debugger;

    var buttonlike = $("button[name=" + tweetid + "]").val();
    if (buttonlike == false) {
        let like ={
            TweetId: tweetid,
            UserId: takipciid,
            Isdeleted: "False",
            Isactive: "True"
        };
        $.ajax({
            type: "POST",
            url: "/Like/Likeoperation",
            data: like,
            //dataType :"Json",
            success: function (success) {
                debugger;
                $("button[name=" + tweetid + "]").css("color", "red");
                getirici();
            },
        });
    }
    else {
        let like = {
            TweetId: tweetid,
            UserId: takipciid,
            Isdeleted: "True",
            Isactive: "True"
        };
        $.ajax({
            type: "POST",
            url: "/Like/Likeoperation",
            data: like,
            //dataType :"Json",
            success: function (success) {
                debugger;
                $("button[name=" + tweetid + "]").css("color", "grey");
                getirici();
            },
        });
    }
}

function retweet(takipciid, tweetid,rtactive) {
    debugger;


    if (rtactive == "False") {
        let like = {
            TweetId: tweetid,
            UserId: takipciid,
            Isdeleted: "False",
            Isactive: "True"
        };
        $.ajax({
            type: "POST",
            url: "/Retweet/rtoperation",
            data: like,
            //dataType :"Json",
            success: function (success) {
                debugger;
                $("button[id=rt-"+ tweetid +"]").css("color", "green");
                getirici();
            },
        });
    }
    else {
        let like = {
            TweetId: tweetid,
            UserId: takipciid,
            Isdeleted: "True",
            Isactive: "False"
        };
        $.ajax({
            type: "POST",
            url: "/Retweet/rtoperation",
            data: like,
            //dataType :"Json",
            success: function (success) {
                debugger;
                $("button[id=rt-"+ tweetid + "]").css("color", "grey");
                getirici();
            },
        });
    }
}










function getirici() {
    debugger;
    $.ajax({
        type: "POST",
        url: "/Like/Posttweet",
        //data: { id: id },
        dataType: "html",
        success: function (data) {
            console.log("işlem başarılı");
            $('#panel').html(data);
        },

    });
}
   