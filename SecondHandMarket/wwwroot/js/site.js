﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


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


fileId.onchange = evt => {
    var images = [image1, image2, image3, image4, image5, image6];
    var files = $("#fileId")[0].files;

    for (var i = 0; i < files.length; i++) {

        images[i].src = URL.createObjectURL(files[i])
    }
}

$(function () {
    let uploadBtn = document.getElementsByClassName('upload-Btn');
    $(uploadBtn).click(function (e) {
        e.preventDefault();
        $('#fileId').click();
    }
    );
});