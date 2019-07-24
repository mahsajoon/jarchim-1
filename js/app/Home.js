function fSearchAds(pCtrl, pAction) {
    vCatId = $("#cat_id").val()
    vAdSavePer = $("#ad_save_per").val()
    vCityId = $("#city_id").val()
    var vObject = { ad_save_per: vAdSavePer, ad_cat: vCatId, ad_city: vCityId }
    vPartial = fPartialGet("Home/SearchAds", vObject)
    $("#inconsistency").html(vPartial)

}

function fNewsLetter() {
    //if (!fValidateForm())
    //    return false
    aData = fFormGetValue()
    vDtl = fAdd("Home", "DupEmail", aData)
    if (vDtl.pError != null && vDtl.pError != "") {
        $(".cf-msg").html('<div style="color:red">' + vDtl.pError + '</div>')
        return 0
    }
    if (vDtl.pSuccess != null && vDtl.pSuccess != "") {
        $(".cf-msg").html('<div style="color:green">' + vDtl.pSuccess + '</div>')
        return 0
    }
}

function Register() {
    //if (!fValidateForm())
    //    return false
    aData = fFormGetValue()
    vDtl = fAdd("Home", "Register", aData)
    if (vDtl.pError != null && vDtl.pError != "") {
        $(".cf-msg").html('<div style="color:red">' + vDtl.pError + '</div>')
        return 0
    }
    if (vDtl.pSuccess != null && vDtl.pSuccess != "") {
        $(".cf-msg").html('<div style="color:green">' + vDtl.pSuccess + '</div>')
        return 0
    }
}

function login() {
    //if (!fValidateForm())
    //    return false
    aData = fFormGetValue()
    vDtl = fAdd("Home", "login", aData)
    if (vDtl.pError != null && vDtl.pError != "") {
        $(".cf-msg").html('<div style="color:red">' + vDtl.pError + '</div>')
        return 0
    }
    if (vDtl.pSuccess != null && vDtl.pSuccess != "") {
        $(".cf-msg").html('<div style="color:green">' + vDtl.pSuccess + '</div>')
        window.location.href = vUrl + "Home/Index";
        return 0
    }

}