$(document).ready(function () {

    $('#srt').each(function() {
        parse_srt(this);
        srt_to_html();
        $('#srt-select').append(srt_menu);
    })


    /* Draw modal dialog on click */
    $('.srt-click').click(function(event, ui) {
        event.preventDefault();
        var srt_id = event.currentTarget.children[0].innerHTML;

        render_dialog_form(srt_id);

        $('#srt-modal').modal({
            show : false
        });
        $('#srt-modal').modal('show');
    });
   
    /* Save Changes to modal dialog */
    $('#srt-update').click(function(event, ui) {
        var srt_id = $('#srt-dialog-form form').attr('id').slice(5);
        srt_object[srt_id]['time']['start'] = $('#time_start').val();
        srt_object[srt_id]['time']['end'] = $('#time_end').val();

        /* loop through texts and update them */
        for (var t in srt_object[srt_id]['text'])
        {
            srt_object[srt_id]['text'][t] = $('#text_' + t +'').val();
        }

        var srt_text = ""
        for (var text in srt_object[srt_id]["text"]) { srt_text +='    <p class="list-group-item-text">' + srt_object[srt_id]["text"][text] + '</p>' }

        $('#' + srt_id + '').html(
            '    <h4 class="list-group-item-heading">' + srt_id + '</h4>'
            +'    <p class="list-group-item-text">' + srt_object[srt_id]["time"]["start"] +' --> ' + srt_object[srt_id]["time"]["end"] + '</p>'
            + srt_text
        );
    });

    /* Save changes and update SRT file on site.*/
    $('#srt-save').click(function (event, ui) {
        
        var payload = new Object();
        var sub_string = obj_to_srt();
        payload["sub_string"] = sub_string;
        payload["id"] = $('#subtitle_id').text();
        $.post("../update_subtitle", payload, function (data) {
            console.log('hit');
        });
    });
});


/***************************************************
 * This function renders the dialog form from the  *
 * srt_object int o the modal form div.            *
 ***************************************************/
function render_dialog_form(srt_id) {

    var time_start = srt_object[srt_id]['time']['start'];
    var time_end   = srt_object[srt_id]['time']['end'];
    var text_arr   = [];

    for (var t in srt_object[srt_id]['text'])
    {
        text_arr[t] = srt_object[srt_id]['text'][t];
    }

    /* Prepare text objects for 'divination' */    
    var text_str = "";
    for ( var t in text_arr)
    {
        var c = parseInt(t) + 1;
        text_str +=     '<div class="input-group">'
        text_str +=     '<span class="input-group-addon">' + c + '</span>'
        text_str +=     '<input id="text_' + t + '" name="text_' + t + '" type="text" value="' + text_arr[t] + '" class="form-control"/>'
        text_str +=     '</div> <!-- input-group-->'
    }

    /* Create div for our dialog popup */
    $('#srt-dialog-form').html(
          '<form id="form_' + srt_id + '" class="form-guy" " role="form">'
        + '    <div class="row">'
        + '            <div class="col-lg-6">'
        + '            <div class="input-group">'
        + '                    <span class="input-group-addon">Start</span>'
        + '                    <input type="text" name="time_start" id="time_start" value="' + time_start + '" class="form-control""/>'
        + '            </div>'
        + '            </div>'
        + '            <div class="col-lg-6">'
        + '            <div class="input-group">'
        + '                    <span class="input-group-addon">End</span>'
        + '                    <input type="text" name="time_end" id="time_end" value="' + time_end + '" class="form-control""/>'
        + '            </div> <!-- input-group -->'
        + '            </div> <!-- col-lg-6 -->'
        + '    </div> <!-- row -->'
        + '    ' + text_str 
        + '</form>'
    );
};

/*---------------------------SRT-PARSER---------------------------------------*/
/*----------------------------------------------------------------------------*/
var srt_menu = "";
var srt_object = new Object();
/* Structure :
 *   {
 *      linenr : {
 *          time : {
 *              start : 00:00:00,000,
 *              end   : 00:00:00,000,
 *          },
 *          text : {
 *              line1 : blablabla,
 *              line2 : dingodingodingo
 *              }
 *      }
 *   }
 */

function parse_srt(el) {
    var text = el.textContent || el.innerText;

    /* Split our srt element into inspanudual lines*/
    var text_line_array = text.split('\n');

    /* 
     * Off by one may occur here, tread lightly
     * and carry a large stick
     */

    for (var i = 0; i < text_line_array.length; i++) {
        
        /* first line is always line identifier*/
        srt_object[text_line_array[i]] = [];  
        var tmp = text_line_array[i];
        i++;
        //TODO: split time into start/end
        var time_arr = text_line_array[i].split(" --> ");
        srt_object[tmp]["time"] = [ ];
        srt_object[tmp]["time"]["start"] = time_arr[0];
        srt_object[tmp]["time"]["end"] = time_arr[1];
        i++;
        var j = 0;
        srt_object[tmp]["text"] = [];
        while (text_line_array[i] !== "") {
            srt_object[tmp]["text"][j] = text_line_array[i];
            i++;
            j++;
        }
    }
    delete srt_object[''];
};

/* Create html menu items */
function srt_to_html() { 
    srt_menu +='<div id="srt-list-group" class="list-group">'
    for (var i in srt_object)
    {
        /* srt-click class for jquery*/
        srt_menu +='  <a href="#" id="' + i + '" class="list-group-item srt-click">'
        srt_menu +='    <h4 class="list-group-item-heading">' + i + '</h4>'
        srt_menu +='    <p class="list-group-item-text">' + srt_object[i]["time"]["start"] +' --> ' + srt_object[i]["time"]["end"] + '</p>'
        for (var text in srt_object[i]["text"]) { srt_menu +='    <p class="list-group-item-text">' + srt_object[i]["text"][text] + '</p>' }
        srt_menu +='  </a>'
    } 
    srt_menu += '</div>'
};



function obj_to_srt() {

    var srt_string = "";
    for (var i in srt_object)
    {
        srt_string += i + '\n'
        srt_string += srt_object[i]["time"]["start"]
        srt_string += ' --> '
        srt_string += srt_object[i]["time"]["end"]
        srt_string += '\n'
        for (var t in srt_object[i]["text"])
        {
            srt_string +=srt_object[i]["text"][t]
        }
        srt_string += '\n'
        srt_string += '\n'
    }

    return srt_string;
};