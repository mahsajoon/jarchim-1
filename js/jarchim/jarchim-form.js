function fIsEmpty(p) {
 return jQuery.isEmptyObject(p);
}
function fValidateForm() {
 var vReturn = false;
 $(".psd-validate").each(function () {
  if (fIsEmpty($(this))) {
  }
 })
}

//function fFormGetValue() {
// var vVal = '';
// $(".psd-input").each(function () {
//     var vId = $(this).attr('id');
//     if (!jQuery.isEmptyObject(vId)) {
//    if (vVal.length != 0) vVal += ',';
//    vVal += '"' + vId + '":"' + $(this).val() + '"';
//  }
// });
// vVal = '{' + vVal + '}';
//    alert(vVal)
// var obj = JSON.parse(vVal);
// return JSON.parse(vVal);
//}
function fFormGetValue() {
    var vVal = '';
    $(".psd-input").each(function () {
        var vId = $(this).attr('id');
        if (!jQuery.isEmptyObject(vId)) {
            if (vVal.length != 0) vVal += ',';
            vVal += '"' + vId + '":' + JSON.stringify($(this).val()) + '';
        }
    });
    vVal = '{' + vVal + '}';
    return JSON.parse(vVal);
}
//function fLoadControls() {
// EnableMdDateTimePickers();
// $(".chosen-select").chosen();
//}

function adjustHeight(el) {
    el.style.height = (el.scrollHeight > el.clientHeight) ? (el.scrollHeight) + "px" : "70px";
}
$(document).ready(function () {
 //Radio---
 $(document).on("change", ".psd-input-radio", function () {
 var value = $(this).val();
 var top_id = $(this).data("top-id");
 if (value == 0) {
     value=false 
 }
 else
 {
     value = true
 }
  $("#" + top_id).val(value);
 });
    //checkbox---
 $(document).on("change", ".psd-checkbox", function () {
     var value = this.checked ? 1 : 0;
     $(this).val(value);
     fCheckBoxChildHide(this);
  });
    //MonthYear---
 $(document).on('change', '.psd-input-month-year', function () {
     var top_id = $(this).data("top-id");
     var y = parseInt($("#" + top_id + "_year").val());
     if (y < 1000 || y > 9999) return;
     var m = parseInt($("#" + top_id + "_month").val());
     if (m < 1 || m > 12) return;
     var my = y * 100 + m;
     $("#" + top_id).val(my);
 });
 //Age---
 $(document).on('blur', '.psd-input-age', function () {
  var top_id = $(this).data("top-id");
  var y = parseInt($("#" + top_id + "_age_year").val());
  var m = parseInt($("#" + top_id + "_age_month").val());
  var d = parseInt($("#" + top_id + "_age_day").val());
  $("#" + top_id).val(fAge2Day(y, m, d));
 });
//time 
 $(document).on('blur', '.psd-input-time', function () {
  var vValue = $(this).val();
  var top_id = $(this).data("top-id");
  var vTime = fTimeTotalMinute(vValue);
  $("#" + top_id).val(vTime);
 });
});
function fCheckBoxChildHide(p) {
    var value = p.checked ? "1" : "0";
    var child_id = $(p).data("child-id");
    var child_hide = $(p).data("child-hide");
    if (child_id == undefined || child_hide == undefined) return;
    if (value == child_hide) {
        $("*[data-top-id=" + child_id + "]").parent().addClass("psd-none")
    } else {
        $("*[data-top-id=" + child_id + "]").parent().removeClass("psd-none");
    }
    //if (value == child_hide) {
    //    $("#" + child_id).addClass("psd-invisible");
    //} else {
    //    $("#" + child_id).removeClass("psd-invisible");
    //}
}
$(document).on("keyup", ".psd-autoCompelete", function (e) {
    vDataUrl = $(this).attr("data-url")
    vDataParam = $(this).attr("list")
    //var vFunctionName = window[vDataUrl]
    //vFunctionName(vDataParam, e, $(this).val(), vDataUrl)
    fCompleteData(vDataParam, e, $(this).val(), vDataUrl)
});
function fCompleteData(pId, pEvent, pValue, pDataUrl) {
    if (pValue.length < 1) {
        return
    }
    if ((pEvent.which <= 90 && pEvent.which >= 48) || (pEvent.which == 8) || (pEvent.which == 46)) {
        url = fGetUrl()
        alert(url)
        $.ajax({
            url: url + pDataUrl,
            dataType: "text",
            data: { "pName": pValue },
            type: "POST",
            async: "true",
            cache: false,
            beforeSend: function () {
                $("#" + pId).empty()
            },
            success: function (result) {
                aList = JSON.parse(result)
                for (i in aList) {
                    item = aList[i]
                    $("#" + pId).append("<option value='" + item.value + "'>")
                }
            }
        });
    }
}
function fChoosenComplete(pValue, pDataUrl, pSelectId, pThis, pStatus, pObject) {
    aSelectedValues = new Array()
    if (pStatus == "multiple")
        aSelectedValues = fGetSelectedValue(pSelectId)
    $.ajax({
        url: vUrl + pDataUrl,
        type: "POST",
        contentType: 'application/json',
        data: JSON.stringify(pObject),
        async: false,
        cache: false,
        beforeSend: function () {
            if (pStatus == "multiple") {
                $("#" + pSelectId + " option").each(function () {
                    if (fInArray($(this).attr("value"), aSelectedValues)) { }
                    else {
                        $(this).remove()
                    }
                });
            }
            else {
                $("#" + pSelectId).empty()
            }
        },
        success: function (result) {
            fLoginViewCheck(result)
            aList = JSON.parse(result)
            for (i in aList) {
                if (i == 0) {
                    vClass = "active-result "
                }
                else {
                    vClass = "active-result"
                }
                item = aList[i]
                if (fInArray(item.id, aSelectedValues)) { }
                else { $("#" + pSelectId).append("<option value='" + item.id + "'>" + item.value + "</option>") }
            }
            if (pStatus == "multiple") { fSetSelectedValue(aSelectedValues, pSelectId) }
            if (aList.length > 0)
                $("#" + pSelectId).trigger("chosen:updated");
            pThis.val(pValue)
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
            $('span.psd-loader').css('display', 'none')
        }
    });
}

//function fLockForm(pLock, pList) {
//   if (pLock == true) {
//      $(".psd-input").prop('disabled', true)
//      $(".psd-ok").prop('disabled', true)
//      $(".psd-cancel").prop('disabled', true)
//      //$("#" + pList).prop('disabled', true)
//      $("#" + pList).removeClass("psd-tree-disable")
//      $(".psd-add").prop('disabled', false)
//      $(".psd-remove").prop('disabled', false)
//      $(".psd-edit").prop('disabled', false)
//   }
//   if (pLock == false) {
//      $(".psd-input").prop('disabled', false)
//      $(".psd-ok").prop('disabled', false)
//      $(".psd-cancel").prop('disabled', false)
//      //$("#" + pList).prop('disabled', false)
//      $("#" + pList).addClass("psd-tree-disable")
//      $(".psd-add").prop('disabled', true)
//      $(".psd-remove").prop('disabled', true)
//      $(".psd-edit").prop('disabled', true)
//   }
//}

function fLockForm(pLock, pList) {
 if (pLock == true) {
  $(".psd-dv-where select").prop('disabled', false).trigger("chosen:updated")
  $(".psd-div-ok-cancel").addClass("psd-invisible")
  $("#" + pList).removeClass("psd-tree-disable")
  $(".psd-dv-cud").removeClass('psd-invisible')
 }
 if (pLock == false) {
  $(".psd-dv-where select").prop('disabled', true).trigger("chosen:updated")
  //$(".psd-div-ok-cancel").css('visibility', 'show')
  $(".psd-div-ok-cancel").removeClass("psd-invisible")
  $("#" + pList).addClass("psd-tree-disable")
  $(".psd-dv-cud").addClass('psd-invisible')
 }
}
function fCheckTreeDisable() {
 if ($(".psd-tree").hasClass("psd-tree-disable")) {
  return "y"
 }
 else {
  return "n"
 }

}
