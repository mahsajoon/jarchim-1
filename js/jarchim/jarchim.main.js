$("body").on("click", ".psd-tr-check", function () {
 vId = $(this).data("tr-key")
 $("*[data-radio-key=" + vId + "]").prop("checked", true)
})
$(document).ready(function () {
 fBodyLoad();
 $(".modal-statup").modal('show');
 fLoadControls();
});
function fBodyLoad() {
 //var i = fRandom(1, 14).toString();
 //url = fGetUrl()
 //var vBg = "URL('" + url + "images/bg/filband/filband_" + i + ".jpg') no-repeat center fixed";
 //$("#test").html(vBg);
 //$("#dvBody").css("background", vBg);
}
function fLoadControls() {
 EnableMdDateTimePickers();
 $(".chosen-select").chosen();
 $(".psd-checkbox").each(function () {
  fCheckBoxChildHide(this);
 });
 $(".psd-gauge").each(function () {
  fGaugeLoad(this);
 });
 $("div").each(function () {
  if ($(this).hasClass("psd-ajax")) {
   fAjaxLoad(this);
  }
 })
 $(".psd-tree").each(function () {
  $(this).treetable({ expandable: true });
 });
}
//---Event Of From To Date------
$(document).on("click", ".psd-ft-date", function (e) {
 var p = $(this).data("date");
 if (p == undefined) return;
 var aDate = [$("#" + p + "_From").val(), $("#" + p + "_To").val()];
 if (aDate[0] == undefined) return;
 if (aDate[1] == undefined) return;
 var vStatus = $(e.target).parents("button").data("id");
 var vArrow = $(e.target).parents("button").data("arrow");
 aDate = fFromToDateChange(aDate[0], aDate[1], vStatus, vArrow);
 aDate[0] = fFDateFormat(aDate[0]);
 aDate[1] = fFDateFormat(aDate[1]);
 $("#" + p + "_From").val(aDate[0]);
 $("#" + p + "_To").val(aDate[1]);
});

$(".psd-ft-date").hover(function () {
 $(this).children(":first").removeClass("psd-hide");
 $(this).children(":last").removeClass("psd-hide");
}, function () {
 $(this).children(":first").addClass("psd-hide");
 $(this).children(":last").addClass("psd-hide");
});
//---Ajax-----
function fAjaxLoad(pElm) {
 if (pElm == undefined) return;
 vUrl = fGetUrl()
 var url = vUrl + $(pElm).data("url");
 if (url == undefined) return;
 var type = $(pElm).data("type");
 if (type == undefined) type = 'GET';
 var dataType = $(pElm).data("data-type");
 if (dataType == undefined) dataType = 'json';
 var data = $(pElm).data("data");
 if (data == undefined) data = '';
 var autoRefresh = $(pElm).data("auto-refresh");
 if (autoRefresh == undefined) autoRefresh = false;
 $.ajax({
  url: url,
  type: type,
  contentType: "application/json;charset=utf-8",
  dataType: dataType,
  async: false,
  data: data,
  success: function (pResult) {
   if (pResult != "") {
    $(pElm).html(pResult);
   }
   if (!autoRefresh) $(pElm).removeClass("psd-ajax");
  },
  error: function (errormessage) {
   alert(errormessage.responseText);
  }
 });
}
function fGetUrl() {
 //project = window.location.pathname.split('/');
 //url = window.location.protocol + '//' + window.location.host + '/' + project[1] + '/'
 url = window.location.protocol + '//' + window.location.host + '/'
 return url;
}
//------
vUrl = fGetUrl()
function fNavigateUser() {
 window.location.href = vUrl + "User/login"
}
function fLoginViewCheck(pData) {
 var n = pData.indexOf("loginvalkey")
 if (n > 0) {
  fNavigateUser()
 }
}
function fList(pCtrl, pAction, pObject) {
 if (typeof pObject == 'undefined') {
  pObject = {}
 }
 var vData = []
 $.ajax({
  url: vUrl + pCtrl + "/" + pAction,
  dataType: "json",
  contentType: 'application/json',
  data: JSON.stringify(pObject),
  type: "POST",
  cache: false,
  async: false,
  beforeSend: function () {
   $('span.psd-loader').css('display', 'block')
  },
  success: function (data) {
   vData = data
   $('span.psd-loader').css('display', 'none')
  },
  error: function (errormessage) {
   alert(errormessage)
   //fNavigateUser()
   $('span.psd-loader').css('display', 'none')
  }
 });
 return vData
}
function fAdd(pCtrl, pAction, pData) {
 $('#btnCancel').prop('disabled', true);
 var vAddedObject
 $.ajax({
  url: vUrl + pCtrl + '/' + pAction,
  type: "POST",
  contentType: 'application/json',
  data: JSON.stringify(pData),
  dataType: "json",
  cache: false,
  async: false,
  beforeSend: function () {
   $('span.psd-loader').css('display', 'block')
  },
  success: function (data) {
   $('#btnCancel').prop('disabled', false);
   $('span.psd-loader').css('display', 'none')
   vAddedObject = data
  }
      ,
  error: function (errormessage) {
   fNavigateUser()
   $('span.psd-loader').css('display', 'none')
  }
 });
 return vAddedObject
}
function fModalShow(pMdlId, pMdlBodyId, pContent) {
 $("#" + pMdlId).modal('show')
 $("#" + pMdlBodyId).empty()
 $("#" + pMdlBodyId).html(pContent)
}
function fPartialGet(pUrl, pData) {
 var vPartial
 $.ajax({
  url: vUrl + pUrl,
  type: "POST",
  contentType: 'application/json',
  data: JSON.stringify(pData),
  cache: false,
  async: false,
  beforeSend: function () {
   $('span.psd-loader').css('display', 'block')
  },
  success: function (data) {
   $('span.psd-loader').css('display', 'none')
   fLoginViewCheck(data)
   vPartial = data
  },
  error: function (errormessage) {
   alert(errormessage)
   $('span.psd-loader').css('display', 'none')
  }
 });
 return vPartial
}
function fUtf8ToB64(str) {
 return window.btoa(unescape(encodeURIComponent(str)));
}
function fB64ToUtf8(str) {
 return decodeURIComponent(escape(window.atob(str)));
}
//function fFillSelect(pUrl, pSrcId, pDesId) {
// vId = $("#" + pSrcId).val()
// $.ajax({
//  url: pUrl,
//  data: { pId: vId },
//  type: "Get",
//  async: false,
//  cache: false,
//  beforeSend: function () {
//   $("#" + pDesId).empty()
//  },
//  success: function (result) {
//   aList = JSON.parse(result)
//   for (i in aList) {
//    item = aList[i]
//    $("#" + pDesId).append("<option value='" + item.id + "'>" + item.value + "</option>")
//   }
//   $("#" + pDesId).trigger("chosen:updated");
//  }
//     ,
//  error: function (errormessage) {
//   fNavigateUser()
//   $('span.psd-loader').css('display', 'none')
//  }
// });
//}
function fFillSelect(pUrl, pSrcId, pDesId, pHasDefault, pDefaultVal, pDefaultText) {
 vId = $("#" + pSrcId).val()
 $.ajax({
  url: pUrl,
  data: { pId: vId },
  type: "Get",
  async: false,
  cache: false,
  beforeSend: function () {
   $("#" + pDesId).empty()
  },
  success: function (result) {
   if (result.length > 0) {
    aList = JSON.parse(result)
    if (pHasDefault > 0) {
     $("#" + pDesId).append("<option value='" + pDefaultVal + "'>" + pDefaultText + "</option>")
    }
    for (i in aList) {
     item = aList[i]
     $("#" + pDesId).append("<option value='" + item.id + "'>" + item.value + "</option>")
    }
    $("#" + pDesId).trigger("chosen:updated");
   }
  }
     ,
  error: function (errormessage) {
   fNavigateUser()
   $('span.psd-loader').css('display', 'none')
  }
 });
}
function fFillSelectWithData(pUrl, pSrcId, pDesId, pData) {
 $.ajax({
  url: pUrl,
  type: "POST",
  contentType: 'application/json',
  data: JSON.stringify(pData),
  beforeSend: function () {
   $("#" + pDesId).empty()
  },
  success: function (result) {
   aList = JSON.parse(result)
   for (i in aList) {
    item = aList[i]
    $("#" + pDesId).append("<option value='" + item.id + "'>" + item.value + "</option>")
   }
   $("#" + pDesId).trigger("chosen:updated");
  }
      ,
  error: function (errormessage) {
   fNavigateUser()
   $('span.psd-loader').css('display', 'none')
  }
 });
}