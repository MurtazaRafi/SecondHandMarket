
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
    //TODO fixa subcetegory controller och ha metoden där (kalla på den)
    $.getJSON(`/Advertisements/GetSubLocations?lId=${lId}`, function (data) {
        $.each(data, function (i, item) {
            $("select#sublocations").append(`<option value="${item.id}">${item.name}</option>`);
        });
    });
}


fileId1.onchange = evt => {
    var images = [image1, image2, image3, image4, image5, image6];
    var files = $("#fileId1")[0].files;

    for (var i = 0; i < files.length; i++) {

        images[i].src = URL.createObjectURL(files[i])
    }
}

$(function () {
    let uploadBtn = document.getElementsByClassName('upload-Btn');
    $(uploadBtn).click(function (e) {
        e.preventDefault();
        $('#fileId1').click();
    }
    );
});


$(function () {
    let deleteButton = document.getElementById('deleteButton');
    deleteButton.onclick = function () {
        document.getElementById("fileId1").value = null;

        if (document.getElementById("fileId2").value != null) {
            document.getElementById("fileId2").setAttribute("id", "fileId1");

        }
        else {

        image1.src = "/Pics/kamera.PNG";
        }
        //TODO lägg till If sats (om fil 2 null visa kamera annars ej)
    };
});


fileId2.onchange = evt => {
    var images = [image1, image2, image3, image4, image5, image6];
    var files = $("#fileId2")[0].files;

    for (var i = 0; i < files.length; i++) {

        image2.src = URL.createObjectURL(files[i])
    }
}

// Experimentrar kan tas bort sen
//var loadFile = function (event) {
//    var output = document.getElementById('output');
//    output.src = URL.createObjectURL(event.target.files[0]);
//    $("#clear").removeClass("hide");
//};




//(function () {
//    let deleteButton = document.getElementById('deleteButton');
//    deleteButton.onclick = function () {
//        document.getElementById("fileId1").value = null;
//        //document.getElementById("fileId2").setAttribute("id", "fileId1");
//        image1.src = "/Pics/kamera.PNG";
//    };
//});


