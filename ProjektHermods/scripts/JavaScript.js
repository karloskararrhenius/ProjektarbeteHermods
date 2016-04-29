function moveButton(elem) {

    if ($(elem).parent().attr("id") == "nonSelectedT") {
        $(elem).detach().appendTo('#selected');
    }
    else if ($(elem).parent().attr("id") == "nonSelected") {
        $(elem).detach().appendTo('#selected');
    }

    else {
        $(elem).detach().appendTo('#nonSelected');
    }
}
function copy() {
    var data = document.getElementById('SearchText').value;
    if (data.length === 0) {


    }else{
        document.getElementById('selected').innerHTML += "<button id='btnDanger' onclick='moveButton(this)' type='button' class='btn-danger'>" + data + "</button><br/>";
    }
    
}
    

  $(document).ready(function () {
      $("#SearchText").autocomplete({
          source: function (request, response) {
              $.ajax({
                  url: "/Search/AutoCompleteIngrediens",
                  type: "POST",
                  dataType: "json",
                  data: { term: request.term },
                  success: function (data) {
                      if (data.length > 0) {
                          response($.map(data, function (item) {
                              return {
                                  label: item.Name,
                                  val: item.Name
                              };
                          }))
                      } else {
                          response([{ label: 'Inga resultat', val: "" }]);
                      }
                  }
              });
          }
          })
      });
  

      

$(".Kött-open-button-1").click(function () {
    $("div.Kött-div-1").show("slow");

    $("div.Grönsaker-div-1").hide("slow");
    $("div.Fisk-div-1").hide("slow");
});

$(".Grönsaker-open-button-1").click(function () {
    $("div.Grönsaker-div-1").show("slow");

    $("div.Kött-div-1").hide("slow");
    $("div.Fisk-div-1").hide("slow");
});

$(".Fisk-open-button-1").click(function () {
    $("div.Fisk-div-1").show("slow");

    $("div.Grönsaker-div-1").hide("slow");
    $("div.Kött-div-1").hide("slow");
});

$(".Hide-1").click(function () {
    $(".div-1").hide("slow");
});

