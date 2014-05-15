var CommentCount = 0;

$(document).ready(function () {
	GetAllComments();

    $("#SubmitComment").click(function () {
        if ($("#CommentText").val() != "") {
            var commentPost = { "Username": null, "CommentText": $("#CommentText").val(), "CommentDate": null };
            $.ajax({
                type: "POST",
                url: "/Home/Index/",
                data: commentPost,
                dataType: "json",
                success: function (commentPost) {
                    if (commentPost.Count === CommentCount + 1) { //if no comments have been added in the meantime
                        commentPost.CommentDate = ConvertStringToJSDate(commentPost.CommentDate); //we do the date conversion on the client
                        $("#CommentList").loadTemplate($("#CommentTemplate"), commentPost, { append: true }); //append template to comment list
                        InjectID(CommentCount); //attach id attributes to our html
                    }
                    else {
                        $("#CommentList").empty(); //if a comment has been added in the meantime we empty the comment list
                        GetAllComments(); //and get all the comments from the server
                    }
                    CommentCount++;
                }
            })
            eraseText(); //clear text box
            $("#CommentError").hide(); //hide error message
        }
        else {
            $("#CommentError").html("The comment cannot be empty :("); //create error message
            $("#CommentError").show(); //show error message
        }
        
    });

    $(".list-group").on("click", ".like-comment", function () {
        var ServerID = parseInt($(this).closest("li").attr("id")) + 1; //id that we use on the server
        var commentPost = { "ID": ServerID };                          //the first id is #like0, couldn't
        $.ajax({
            type: "POST",
            url: "/Home/AddLike/",
            data: commentPost,
            dataType: "json",
            success: function (like) {
                if(like.Username == "") //if user has already liked the comment we turn the Username property
                {                       //into an empty string in the home controller
                    alert("You have already liked this comment!");
                }
                else
               	{
                    var item = $("<li/>").text(like.Username + " liked this.").addClass("like-item");
                    var ClientID = like.CommentID - 1; //id that we use on the client the first id is
                    var ID_Selector = "#like" + ClientID; //#like0, couldn't figure out how to change it 
	                $(ID_Selector).append(item);       //so this is how we solved this problem
	            }
            }
        });
    });
});

function GetAllComments() {
    $.ajax({
        type: "GET",
        url: "/Home/GetComments/",
        data: {},
        dataType: "json",
        success: function (comments) {
        	for(var i = 0; i < comments.length; i++) {
        	    var data = {
        	        "Username": comments[i].Username,
        	        "CommentText": comments[i].CommentText,
        	        "CommentDate": comments[i].CommentDate,
        	        "ID": comments[i].ID
        	    };
        	    $("#CommentList").loadTemplate($("#CommentTemplate"), data, { append: true }); //load comment template
                InjectID(i); //attach id attributes to our html
                GetLikes(comments[i]); //get likes for our comment
        	}
        	CommentCount = comments[comments.length - 1].Count; //saves the amount of comments associated with the last comment
        	if (CommentCount === 0) {
        	    CommentCount = 2; //because we have two comments in the beginning
        	}

        }
    });
}

function InjectID(id) { //injects id attributes to the appropriate html elements
    $("li.comment").each(function (id) {
        $(this).attr("id", id);
    });

    $("ul.likes").each(function (id) {
        $(this).attr("id", "like" + id);
    });
}

function GetLikes(comment) //gets all likes associated with comment
{
    $.ajax({
        type: "GET",
        url: "/Home/GetLikes/",
        data: comment,
        dataType: "json",
        success: function (likes, comment) {
            var CommentID = likes[0].CommentID - 1;
            for (var i = 0; i < likes.length; i++) {
                var item = $("<li/>").text(likes[i].Username + " liked this.").addClass("like-item"); //create li element
                var ID_Selector = "#like" + CommentID; //id for like list
                $(ID_Selector).append(item); //append like to list
            }
        }
    });
}

function ConvertStringToJSDate(dt) {
	var dtE = /^\/Date\((-?[0-9]+)\)\/$/.exec(dt);
	if(dtE) {
	    dt = moment().format("D. MMMM - HH:mm - ");
		return dt;
	}
	return null;
}

function eraseText() {
    document.getElementById("CommentText").value = "";
}