$(document).ready(function () {

    $('#srt').each(function() {
        parse_srt(this);
        srt_to_html();
        $('#srt-select').html(
         '<div id="srt-menu">'
         + srt_menu
         + '</div>'
         + '<div class="btn-group">'
         + '<button id="srt-update" type="button" class="btn btn-default">Update</button>'
         + '<button id="srt-addline" type="button" class="btn btn-default">Add Line</button>'
         + '</div>'
         + '</div>'
        );
    })

    globmenu = $('#srt-menu').menu({
        menus   : "div",
        select: function (event, ui) {
            var srt_id = event.currentTarget.attributes['id'].value;

            if ((event.keyCode || event.which) == 13) {
                console.log(event);
                console.log('eeep');
            }
            draw_dialog(srt_id);
        },
        //refresh : function (event, ui) { }
    });

});


function draw_dialog(srt_id) {
    var dialog_options =  {
        /* Base options */
        height        : 400,
        width         : 450,
        autoOpen      : false,
        modal         : true,
        closeOnEscape : true,

        /* Define buttons */
        buttons  : {
            "Update line" : function() {

                /* assign new values to srt object */
                srt_object[srt_id]['time']['start'] = $('#time_start').val();
                srt_object[srt_id]['time']['end'] = $('#time_end').val();

                /* loop through texts and update them */
                var text_html = "";
                for (var t in srt_object[srt_id]['text'])
                {
                    console.log($('#text_' + t + '').val());
                    srt_object[srt_id]['text'][t] = $('#text_' + t + '').val();
                    
                    text_html += '<span class="table-row">';
                    text_html += srt_object[srt_id]['text'][t];
                    text_html += '</span>';
                    text_html += '<br/>';
                }

                /* Update html */
                $('#' + srt_id + '').html(
                          '<span id="' + srt_id +'">'
                        + '<a href="#srt-menu">'
                        + '<span id=' + srt_id + ' class="table">'
                        + '<span id="row-1" class="table-row">'
                        + '<span id="number" class="table-cell">' + srt_id + '</span>' 
                        + '<span id="row-2" class="table-row">'
                        + '<span id="time" class="table-cell">'
                        + srt_object[srt_id]["time"]["start"]
                        + ' >>  ' 
                        + srt_object[srt_id]["time"]["end"]
                        + '</span>'
                        + '</span>'
                        + '<br/>'
                        + text_html
                        + '</span>'
                        + '</span>'
                        + '</a>'
                        + '</span>'
                );

                //globmenu.menu('refresh', true);
                $(this).dialog("close");
                },

                "Cancel"      : function() {
                $(this).dialog("close");
            },
        },
        
        /* Close event callback */
        close: function (event, ui) {
            $(this).dialog('destroy').remove();
        }
    };

    render_dialog_form(srt_id);

    $('#dialog_form').modal({
        show : false
    });
    $('#dialog_form').modal('show');
};

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
        /* Use 1 index for 'Normal people' */
        var c = parseInt(t) + 1;
        text_str += '<div class="input-group">'
        text_str += '<span class="input-group-addon">' + c + '</span>'
        text_str += '<input id="text_' + t + '" name="text_' + t + '" type="text" value="' + text_arr[t] + '" class="form-control"/>'
        text_str += '</div>'
    }

    /* Create div for our dialog popup */
    $('#dialog').append(
        +'<div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">'
        +'  <div class="modal-dialog modal-sm">'
        +'      <div class="modal-content">'
        +'          <form role="form" id="dialog_form">'
        +'              <div class="form-group">'
        +'                  <label for="name">Name</label>'
        +'                  <input type="text" class="form-control" id="name" placeholder="Enter Name">'
        +'              </div>'
        +'              <div class="form-group">'
        +'                  <label for="inputfile">File input</label>'
        +'                  <input type="file" id="inputfile">'
        +'                  <p class="help-block">Example block-level help text here.</p>'
        +'              </div>'
        +'              <button type="submit" class="btn btn-default">Submit</button>'
        +'          </form>'
        +'      </div>'
        +'  </div>'
        +'</div>'
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
};

/* Create html menu items */
function srt_to_html() { 
    for (var i in srt_object)
    {
        srt_menu +='<span id="' + i +'">'
        srt_menu +='<a href="#srt-menu">'
        srt_menu +='<span id=' + i + ' class="table">'
        srt_menu +='<span id="row-1" class="table-row">'
        srt_menu +='<span id="number" class="table-cell">' + i + '</span>' 
        srt_menu +='<span id="row-2" class="table-row">'
        srt_menu +='<span id="time" class="table-cell">'
        srt_menu +=srt_object[i]["time"]["start"]
        srt_menu +=' >>  ' 
        srt_menu +=srt_object[i]["time"]["end"]
        srt_menu +='</span>'
        srt_menu +='</span>'
        srt_menu +='<br/>'
          

        for (var text in srt_object[i]["text"]) 
        {
            srt_menu += '<span class="table-row">'
            srt_menu += srt_object[i]["text"][text] 
            srt_menu += '</span>'
            srt_menu += '<br/>'
        }

        srt_menu +='</span>'
        srt_menu +='</span>'
        srt_menu +='</a>'
        srt_menu +='</span>'
    } 
};
