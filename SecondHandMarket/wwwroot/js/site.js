
$(document).ready(function () {
    $("#categories").find("option").first().hide();
});

$(document).ready(function () {
    $("#locations").find("option").first().hide();
});

$(function () {
    $("select#locations").change(function () {
        var lId = $(this).val();
        GetSubLocations(lId);
    });
});

$(function () {
    $("select#sublocations").find("option").first().hide();
});

function GetSubLocations(lId) {
    $("select#sublocations").empty().append('<option value="0" disabled="disabled" , selected="selected">Välj kommun</option>');
    $("select#sublocations").find("option").first().hide();
    //TODO fixa subcategory controller och ha metoden där (kalla på den)
    $.getJSON(`/Advertisements/GetSubLocations?lId=${lId}`, function (data) {
        $.each(data, function (i, item) {
            $("select#sublocations").append(`<option value="${item.id}">${item.name}</option>`);
        });
    });
}



$(function () {
    let uploadBtn = document.getElementsByClassName('upload-Btn');
    $(uploadBtn).click(function (e) {
        e.preventDefault();
        $('#fileId1').click();
    }
    );
});


fileId1.onchange = evt => {
    var images = [image1, image2, image3, image4, image5, image6];
    var files = $("#fileId1")[0].files;

    for (var i = 0; i < files.length; i++) {

        images[i].src = URL.createObjectURL(files[i])
    }
}

//$(function () {
//    let deleteButton = document.getElementById('deleteButton');
//    deleteButton.onclick = function () {
//        //document.getElementById("fileId1").value = null;
//        //document.getElementById("fileId1").remove();
//        //document.getElementById("fileId1").setAttribute("id", "");

//        if (document.getElementById("fileId2").value != "") {
//            document.getElementById("fileId2").setAttribute("id", "fileId1");

//            //document.getElementById("image2").setAttribute("id", "image1");
//            document.getElementById("div1").remove();
//            document.getElementById("div2").setAttribute("id", "div1");
//            //var img2 = $("#div2").children('img').eq(0);
//            //img2.setAttribute("id", "image1");

//        }
//        else {

//            image1.src = "/Pics/kamera.PNG";
//        }
//        //TODO lägg till If sats (om fil 2 null visa kamera annars ej)
//    };
//});


//fileId2.onchange = evt => {
//    var images = [image1, image2, image3, image4, image5, image6];
//    var files = [fileId1, fileId2];
//    var file = (files[0])[0].files;

//        image2.src = URL.createObjectURL(file[0])
//}

var loadFile = function (event) {
    var output = document.getElementById('image2');
    output.src = URL.createObjectURL(event.target.files[0]);
    $("#close").show();
};


$('#deleteButton').click(function () {
    var div = $(this).parent();
    div.remove();
})

//(function () {
//    let deleteButton = document.getElementById('deleteButton');
//    deleteButton.onclick = function () {
//        document.getElementById("fileId1").value = null;
//        //document.getElementById("fileId2").setAttribute("id", "fileId1");
//        image1.src = "/Pics/kamera.PNG";
//    };
//});


