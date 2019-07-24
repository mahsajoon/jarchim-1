$(document).ready(function () {
    $(".psd-input-radius").each(function () {
        $(this).wrap('<div class="psd-item-radius">')
        var p = $(this).attr("placeholder")
        $(this).before('<p class="psd-label-radius">' + p + '</p>')
        $(this).removeAttr('placeholder')
    });

    $(".psd-input-ltr-radius").each(function () {
        $(this).wrap('<div class="psd-item-ltr-radius">')
        var p = $(this).attr("placeholder")
        $(this).before('<p class="psd-label-ltr-radius">' + p + '</p>')
        $(this).removeAttr('placeholder')
    });

  var formInputs = $('.psd-input-radius');
    formInputs.focus(function () {
        $(this).parent().children('p.psd-label-radius').addClass('psd-label-radius-top');
    });
    formInputs.focusout(function () {
        if ($.trim($(this).val()).length == 0) {
            $(this).parent().children('p.psd-label-radius').removeClass('psd-label-radius-top');
        }
    });
    $('p.psd-label-radius').click(function () {
        $(this).parent().children('input').focus();
    });

    var formInputs = $('.psd-input-ltr-radius');
    formInputs.focus(function () {
        $(this).parent().children('p.psd-label-ltr-radius').addClass('psd-label-ltr-radius-top');
    });
    formInputs.focusout(function () {
        if ($.trim($(this).val()).length == 0) {
            $(this).parent().children('p.psd-label-ltr-radius').removeClass('psd-label-ltr-radius-top');
        }
    });

    $('p.psd-label-ltr-radius').click(function () {
        $(this).parent().children('input').focus();
    });

    $("body").on("keyup", ".english-input-one", function () {
        var vPdhExpEn = 0

        if ($("#switch_left").prop("checked") == true) {
            vPdhExpEn = 1
        }
        if (vPdhExpEn == 1) {
            var textInput = this.value;
            var test = switchKey(textInput);
            $('.english-input-one').val(test);
        }
    })
    function switchKey(value) {
        if (!value) {
            return;
        }
        var persianChar = ["ض", "ص", "ث", "ق", "ف", "غ", "ع", "ه", "خ", "ح", "ج", "چ", "ش", "س", "ی", "ب", "ل", "ا", "ت", "ن", "م", "ک", "گ", "پ", "ظ", "ط", "ز", "ر", "ذ", "د", "ئ", "و", "؟"],
        englishChar = ["q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "[", "]", "a", "s", "d", "f", "g", "h", "j", "k", "l", ";", "'", "/", "z", "x", "c", "v", "b", "n", "m", ",", "?"];
        for (var i = 0, charsLen = persianChar.length; i < charsLen; i++) {
            value = value.replace(new RegExp(persianChar[i], "g"), englishChar[i]);
        }
        return value;
    }
    $("body").on("keyup", ".english-input", function () {
        var textInput = this.value;
        var test = switchKey(textInput);
        $(this).val(test);

    })

});
function CallEnglishInput(params) {
    for (i = 0; i < params.length; i++) {
        $("#" + params[i]).find(".chosen-search input").addClass("english-input")
    }
}