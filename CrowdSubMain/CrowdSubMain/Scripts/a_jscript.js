﻿$(document).ready(function () {
    var subtitle_id = $("#this_subtitle_id").text();
    parseInt(subtitle_id, 10);
    // Sækir fjölda commenta á server
    $.get("../GetCount", subtitle_id,function (data) {
        count = data;
        console.log(count)
    });

    //Send comment
    $("#senda").click(function () {
        
        var sendData = {
            "sc_comment": $("#CommentText").val(),
            "sc_sub_id": subtitle_id
        };

            // Validation sem athugar hvort input sé tómt
            if ($("#CommentText").val() === "") {
                $("#submitCommentError").html("The comment field cannot be empty :(");
                $("#submitCommentError").show();
            }
            else {
                $.post("../post_comment", sendData, function (data) {

                    // Ef Comment error var birtur þá fjarlægist hann hér við póstun nýs comments
                    $("#submitCommentError").hide();

                    for (key in data) {

                        // Breyta sem skilar dagsetningu á ákjósnalegu formi
                        var date = data[key].CommentDate = ConvertStringToJSDate(data[key].CommentDate);

                        // Póstar kommentum frá fjölda síðasta kommenti póstað s.br count breytu sem sækir fjölda kommenta á server
                        if (key >= count) {
                            count++;
                            $(" #Comments li:last-child").before('\
                            <li class="list-group-item">\
                                <p>\
                                    <span class="glyphicon glyphicon-user"></span>\
                                    <span class="text-primary">'  + data[key].Username + '</span>\
                                    <span>' + data[key].CommentText + '</span>\
                                </p>\
                                <p>\
                                    <span class="text-muted">' + date + ' </span>\
                                    <a id="like-button" class="like-comment" href="#">Like <span class="glyphicon glyphicon-thumbs-up"></span></a>\
                                </p>\
                            </li>'
                            );
                            $("#like-button").click(likeFunction);
                        }
                    }
                });     
            }       
            // Hreinsar út textaboxið eftir að hafa submit-að commenti
            $("#CommentText").val("");
    });
});

// Formatar dagsetningu svo hún lúkki einsog fyrirmyndin
function ConvertStringToJSDate(dt) {
    var dtE = /^\/Date\((-?[0-9]+)\)\/$/.exec(dt);
    if (dtE) {
        var dt = new Date(parseInt(dtE[1], 10));
        var months = {
            "0": "January",
            "1": "February",
            "2": "March",
            "3": "April",
            "4": "May",
            "5": "June",
            "6": "July",
            "7": "August",
            "8": "September",
            "9": "October",
            "10": "November",
            "11": "December"
        };
        
        return dt.getDate() + ". " + months[dt.getMonth()] + " " + dt.getHours() + ":" + dt.getMinutes() + " -";
    }
    return null;
}