var vPsdValidatFlag
var vValidateInput = '.psd-validate'
var vValidatePositiveInput = '.psd-validate-positive';
var vValidateCompareInput = '.psd-validate-compare';
var vValidatePassword = '.psd-validate-password';
var vValidateNumber = '.psd-validate-number';
var vValidateLimitedChars = '.psd-validate-limited-chars';
var vValidatePpId = '.psd-validate-ppId'
var vValidateUserCode = '.psd-validate-user-code';
function fValidPpId(pValue) {
    var vValidPpId = false
    while (pValue.length < 10) {
        pValue = "0" + pValue
    }
    var vSum = 0
    var vCheck0 = parseInt(pValue.substring(9))
    for (i = 0; i <= 8; i++) {
        vSum += parseInt(parseInt(pValue.charAt(i))) * (10 - i)
    }
    var vCheck = vSum % 11
    if (vCheck > 1) { vCheck = 11 - vCheck }
    if (vCheck != vCheck0) return vValidPpId
    vValidPpId = true
    return vValidPpId
}
$(document).on("focusout", vValidateInput, function (e) {
    vValue = $(this).val()
    if (vValue.length == 0) {
        vCaption = "لطفا فیلد را تکمیل کنید"
        vNextText = $(this).next().text()
        if (vNextText == "")
            $(this).after("<span data-validate-type='required' class='psd-error-msg'>" + vCaption + "</span>")
    }
    else {
        if ($(this).next().hasClass("psd-error-msg") && $(this).next().data("validate-type") == 'required')
            $(this).next().remove()
    }
})
$(document).on("focusout", vValidatePositiveInput, function (e) {
    vValue = parseInt($(this).val())
    if (vValue <= 0) {
        vCaption = " لطفا مقدار بزرگتر از صفر وارد کنید. "
        vNextText = $(this).next().text()
        if (vNextText == "")
            $(this).after("<span data-validate-type='positive' class='psd-error-msg'>" + vCaption + "</span>")
    }
    else {
        if ($(this).next().hasClass("psd-error-msg") && $(this).next().data("validate-type") == 'positive')
            $(this).next().remove()
    }
})
$(document).on("focusout", vValidateCompareInput, function (e) {
    vValue = $(this).val()
    vCompareId = $(this).data('compare-id')
   vCaption = $(this).data('caption')
    vCompareVal = $("#" + vCompareId + "").val()
    if (vValue.length > 0 && vCompareVal.length > 0) {
        if (vValue != vCompareVal) {
            vCaption = "عدم سازگاری " + vCaption
            vNextText = $(this).next().text()
            if (vNextText == "")
            {
                $(this).after("<span data-validate-type='compare' class='psd-error-msg'>" + vCaption + "</span>")
            }
                
        }
        else {
            if ($(this).next().hasClass("psd-error-msg") && $(this).next().data("validate-type") == 'compare')
                $(this).next().remove()
        }
    }
})
$(document).on("focusout", vValidatePassword, function (e) {
    vValue = $(this).val()
    var vReg = new RegExp(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d$@$!%*#?&]{6,}$/);
    if (vReg.test(vValue)) {
          if ($(this).next().hasClass("psd-error-msg") && $(this).next().data("validate-type") == 'password')
            $(this).next().remove()
    }
    else {
        vNextText = $(this).next().text()
        if (vNextText == "")
            $(this).after("<span data-validate-type='password' class='psd-error-msg'>رمز عبور معتبر نیست </span>")
    }
})
$(document).on("focusout", vValidateUserCode, function (e) {
    vValue = $(this).val()
    var vReg = new RegExp("^[A-Za-z0-9][A-Za-z0-9!@#_$%&*]*$");
    if (vReg.test(vValue)) {
        if ($(this).next().hasClass("psd-error-msg") && $(this).next().data("validate-type") == 'user-code')
            $(this).next().remove()
    }
    else {
        vNextText = $(this).next().text()
        if (vNextText == "")
            $(this).after("<span data-validate-type='user-code' class='psd-error-msg'>کد کاربری معتبر نیست. </span>")
    }
})
$(document).on("focusout", vValidateLimitedChars, function (e) {
    vValue = $(this).val()
    var vMin = $(this).data("min-length")
    var vMax = $(this).data("max-length")
    vCaption = ""
   if (vValue.length>0 &&(vValue.length < vMin || vValue.length > vMax)) {
        vNextText = $(this).next().text()
        if (vNextText == "")
            $(this).after("<span data-validate-type='stringlength' class='psd-error-msg'>مقدار فیلد معتبر نیست </span>")
    }
    else {
        if ($(this).next().hasClass("psd-error-msg") && $(this).next().data("validate-type") == 'stringlength')
            $(this).next().remove()
    }
})
$(document).on("focusout", vValidatePpId, function (e) {
    vValue = $(this).val()
    if (!fValidPpId(vValue)) {
        vNextText = $(this).next().text()
        if (vNextText == "")
            $(this).after("<span data-validate-type='ppid' class='psd-error-msg'>کد ملی  معتبر نیست </span>")
    }
    else {
        if ($(this).next().hasClass("psd-error-msg") && $(this).next().data("validate-type") == 'ppid')
            $(this).next().remove()
    }
})
$(document).on('change', 'select.psd-validate', function (e) {
    var vValue = $(this).val();
    if (vValue == null || vValue == 0) {
        vCaption = "لطفا یکی از موارد را انتخاب کنید"
        vNextText = $(this).parent().children(".psd-error-msg").text()
        if (vNextText == "")
            $(this).parent().append("<span data-validate-type='required' class='psd-error-msg'>" + vCaption + "</span>")
    }
    else {
        if ($(this).next().hasClass("psd-error-msg") && $(this).next().data("validate-type") == 'required')
        $(this).parent().children(".psd-error-msg").remove()
    }
});
$(document).on("keydown", vValidateNumber, function (e) {
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
       (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
        (e.keyCode >= 35 && e.keyCode <= 40)) {
        return;
    }
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
})
function fValidate() {
    $(vValidateInput).each(function () {
        vNodeName = $(this).prop('nodeName')
        vValue = $(this).val()
        if (vNodeName == "INPUT" || vNodeName == "TEXTAREA") {
            if (vValue.length == 0) {
                vPsdValidatFlag = false
                vCaption = "لطفا فیلد را تکمیل کنید."
                vNextText = $(this).next().text()
                if (vNextText == "")
                    $(this).after("<span class='psd-error-msg'>" + vCaption + "</span>")
            }
        }
        else if (vNodeName == "SELECT") {
            if (vValue == null || vValue == 0) {
                vCaption = "لطفا یکی از موارد را انتخاب کنید."
                vNextText = $(this).parent().children(".psd-error-msg").text()
                if (vNextText == "")
                    $(this).parent().append("<span class='psd-error-msg'>" + vCaption + "</span>")
            }
        }
    })
}
function fPositiveValidate() {
    $(vValidatePositiveInput).each(function () {
        if (vValue != null) {
           vValue = parseInt($(this).val())
             if (vValue <= 0) {
                vPsdValidatFlag = false
                vCaption = "لطفا مقدار بزرگتر از صفر وارد کنید. "
                vNextText = $(this).next().text()
                if (vNextText == "")
                    $(this).after("<span class='psd-error-msg'>" + vCaption + "</span>")
            }
        }

    })
}
function fPasswordValidate() {
    $(vValidatePassword).each(function () {
        vValue =$(this).val()
        if (vValue != null) {
            var vReg = new RegExp(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d$@$!%*#?&]{6,}$/);
              if (!vReg.test(vValue)) {
                vPsdValidatFlag = false
                vCaption = "رمز عبور معتبر نیست. "
                vNextText = $(this).next().text()
                if (vNextText == "")
                    $(this).after("<span class='psd-error-msg'>" + vCaption + "</span>")
            }
        }

    })
}
function fCompareValidate() {
    $(".psd-validate-compare").each(function () {
        vValue = parseInt($(this).val())
        if (vValue != null) {
            vCompareId = $(this).data('compare-id')
            vCaption = $(this).data('caption')
            vCompareVal = $("*[data-compare-id=" + vCompareId + "]").val()
            if (vValue.length > 0 && vCompareVal.length > 0) {
                if (vValue != vCompareVal) {
                    vPsdValidatFlag = false
                    vCaption = "عدم سازگاری " + vCaption
                    vNextText = $(this).next().text()
                    if (vNextText == "")
                        $(this).after("<span class='psd-error-msg'>" + vCaption + "</span>")
                }

            }
        }
    })
}
function fLimittedCharsValidate() {
    $(vValidateLimitedChars).each(function () {
        vValue = parseInt($(this).val())
        if (vValue != null) {
            var vMin = $(this).data("min-length")
            var vMax = $(this).data("max-length")
            if (vValue.length < vMin || vValue.length > vMax) {
                vPsdValidatFlag = false
                vCaption = "مقدار فیلد معتبر نیست. "
                vNextText = $(this).next().text()
                if (vNextText == "")
                    $(this).after("<span class='psd-error-msg'>" + vCaption + "</span>")
            }
        }
    })
}
function fPpIdValidate() {
    $(vValidatePpId).each(function () {
        vValue = $(this).val()
        if (vValue != null) {
            if (!fValidPpId(vValue)) {
                vPsdValidatFlag = false
                vCaption = " کد ملی معتبر نیست. "
                vNextText = $(this).next().text()
                if (vNextText == "")
                    $(this).after("<span class='psd-error-msg'>" + vCaption + "</span>")
            }
        }
    })
}
function fValidateForm() {
    vPsdValidatFlag = true
    fValidate()
    fPositiveValidate()
    fPasswordValidate()
    fLimittedCharsValidate()
    //fCompareValidate()
    if (vPsdValidatFlag == false) {
        return false
    }
    else
        return true
}