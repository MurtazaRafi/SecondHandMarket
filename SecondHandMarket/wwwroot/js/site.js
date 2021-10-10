
//Create view

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


var count = 0;

var upload = function (e) {
    e.preventDefault();

    var formGroup = $(".myFormGroup");
    var div = formGroup.find("div:eq(" + count + ")");

    var file = div.find('input')[0];
    var cl = file.click();

}

function removeDiv(elem) {
    $(elem).parent('div').remove();

    if (count <= 6) {
        var formGroup = $(".myFormGroup");
        var div = document.createElement("div");
        div.className = "img-wrap";

        if (count == 6) {
            div.innerHTML = ('<input type="file" class="file" accept="image/*"  onchange="previewImage(event)" id="Files" name="Files" style="padding-left:0" /> <span class="delete" onclick = "removeDiv(this)" >&times </span> <img class= "upload-Btn img-wrap" src = "/Pics/Välj bild.PNG" onclick="upload(event)"> ');
        }
        else {
        div.innerHTML = ('<input type="file" class="file" accept="image/*"  onchange="previewImage(event)" id="Files" name="Files" style="padding-left:0" /> <span class="delete" onclick = "removeDiv(this)" >&times </span> <img class= "upload-Btn img-wrap" src = "/Pics/kamera.PNG" onclick="upload(event)"> ');
        }
        formGroup.append(div);
    }
    count--;
}

var previewImage = function (event) {
    var image = $(event.target).parent().find('img')[0];
    image.src = URL.createObjectURL(event.target.files[0]);

    count++;
    if (count < 6) { 

        var span = $(event.target).parent().find('span')[0];
        span.style.visibility = "visible";
        var formGroup = $(".myFormGroup");
        var div = formGroup.find("div:eq(" + count + ")");

        var nextImage = div.find('img')[0];

        nextImage.src = "/Pics/Välj bild.PNG"
    }
}

// Create view end