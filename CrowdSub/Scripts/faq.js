﻿$(document).ready(function () {
    $(".answers").hide();

    $("#question1").click(function () {
        $("#answer1").toggle();
    });
    $("#question2").click(function () {
        $("#answer2").toggle();
    });
    $("#question3").click(function () {
        $("#answer3").toggle();
    });
    $("#question4").click(function () {
        $("#answer4").toggle();
    });
});