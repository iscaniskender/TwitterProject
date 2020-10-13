
function fallowbutton(takipciid, takipid) {
    debugger;
    var text = $("#fallow-button").text();
    if (text == "Takip Et") {
        let connectionopen = {
            TakipciId: takipciid,
            takipid: takipid,
            Isdeleted: "False",
            Isactive: "True"
        };
        $.ajax({
            type: "POST",
            url: "/Connection/AddConnection",
            data: connectionopen,
            //dataType :"Json",
            success: function (success) {
                debugger;
                $("#fallow-button").css({ "background-color": "#1da1f2", "color": "#d8e8f2" });
                $("#fallow-button").text("Takip Ediliyor");
                getirici1(takipid);
            },
        });
    }
    else {
        let connectionopen = {
            TakipciId: takipciid,
            takipid: takipid,
            Isdeleted: "True",
            Isactive: "True"
        };
        debugger;
        $.ajax({
            type: "POST",
            url: "/Connection/AddConnection",
            data: connectionopen,
            //dataType :"Json",
            success: function (success) {
                $("#fallow-button").css({ "color": "#1da1f2", "background-color": "#d8e8f2" });
                $("#fallow-button").text("Takip Et");
                getirici1(takipid);
            },
        });
    }
}
function getirici1(idgelen) {
    debugger;
    $.ajax({
        type: "POST",
        url: "/Home/GetbyFallowsTable",
        data: { id: idgelen},
        dataType: "html",
        success: function (data) {
            console.log("işlem başarılı");
            $('#panel').html(data);
        },
    });
}
