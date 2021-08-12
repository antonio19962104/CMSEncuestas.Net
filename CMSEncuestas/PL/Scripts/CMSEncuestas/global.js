////const { arrow } = require("@popperjs/core");
////const { type } = require("jquery");

/*
 * return array
 * remove item in array by value
 * implementetion array.remove('data');
*/
Array.prototype.remove = function () {
    var what, a = arguments, L = a.length, ax;
    while (L && this.length) {
        what = a[--L];
        while ((ax = this.indexOf(what)) !== -1) {
            this.splice(ax, 1);
        }
    }
    return this;
};
/*
 * return string unique id
 * create a unique id key
*/
var getIUD = function () {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}
/*
 * hide loading div
*/
var hideLoad = function () {
    document.getElementById("loading").style.display = "none";
}
/*
 * show loading div
*/
var showLoad = function () {
    document.getElementById("loading").style.display = "block";
}
/**
 * return if data entry is null or empty
 * @param {any} data
 */
var isNullOrEmpty = function (data) {
    if (data == "" || data == null || data == undefined)
        return true;
    else
        return false;
}
/**
 * return swal error if request has error
 * @param {any} data
 */
var messageBoxError = function (data) {
    try {
        if (data.Correct) {
            return false;// not exist error
        }
        else {
            hideLoad();
            swal.fire("Ha ocurrido un error", data.ErrorMessage, "error");
            $("#header").append('<div class="col-8" style="margin-left:auto; margin-right:auto;"><div class="title-error" style="background-color: #efefef; height:30px; text-align:center"><span style="vertical-align:middle; font-weight:bold">Titulo</span></div><div class="body mt-2">Se ha producido un error el ejecutar la definicion del metodo GetDatFromBD</div></div>');
            return data.Correct;// exist error
        }
    } catch (aE) {
        console.error(aE);
    }
}
/**
 * return value of specified parameter in url
 * @param {any} key
 */
var getParamByUrl = function (key) {
    try {
        var url_string = window.location.href;
        var url = new URL(url_string);
        var param = url.searchParams.get(key);
        console.log(param);
        return param;
    } catch (aE) {
        return "";
    }
}
/*
 * return base url
*/
var getBaseUrl = function () {
    return window.location.href.split("/")[0] + "//" + window.location.href.split('/')[2];
}
/*
 * return current url
*/
var getCurrentUrl = function () {
    return getBaseUrl() + "/" + window.location.href.split('/')[3] + "/" + window.location.href.split('/')[4];
}
/*
 * return url apis
*/
var getUrlApis = function () {
    return getBaseUrl() + "/" + window.location.href.split('/')[3] + "/" + window.location.href.split('/')[4] + "/apisEncuesta/";
}
/**
 * return base64 image
 * @param {any} e
 */
var getImageBase64 = function (e) {
    try {
        var element = $('#' + e.target.id);
        if (element[0].files.length > 0) {
            if (!validaTipoArchivo()) {
                swal("Tipo de archivo no válido", "", "info").then(function () {
                    return "";
                });
            }
            else {
                var file = element[0].files[0];
                var reader = new FileReader();
                reader.onloadend = function () {
                    return reader.result;
                }
                reader.readAsDataURL(file);
            }
        }
        else {
            swal("Debes elegir una imagen", "", "info").then(function () {
                return "";
            });
        }
    } catch (aE) {
        console.log(aE.message);
    }
}
/*
 * return bool
 * valid type file load
*/
var validaTipoArchivo = function () {
    try {
        var element = $('#fileChosse');
        if (!element[0].files[0].type.includes("png") && !element[0].files[0].type.includes("jpg") && !element[0].files[0].type.includes("jpeg")) {
            swal("Formato de archivo no admitido", "", "warning");
            $("#nombreArchivo").html("<i class='fas fa-exclamation-triangle text-default' aria-hidden='true'></i> Selecciona un archivo válido");
            return false;
        }
    } catch (aE) {
        ////swal(aE.message, "", "warning");
        return false;
    }
    return true;
}
/*
 * verify storage size
 * and drop if it's more than 4mb
*/
var verificarStorage = function () {
    var _lsTotal = 0,
        _xLen, _x;
    for (_x in localStorage) {
        if (!localStorage.hasOwnProperty(_x)) {
            continue;
        }
        _xLen = ((localStorage[_x].length + _x.length) * 2);
        _lsTotal += _xLen;
    };
    console.log("Total = " + (_lsTotal / 1024).toFixed(2) + " KB");
    var size = (_lsTotal / 1024).toFixed(2);
    var tamanio = parseFloat(size);
    console.log(tamanio);
    if (tamanio >= 4000) {
        localStorage.clear();
    }
}
/**
 * return decimal value rounder with two decimal positions
 * @param {any} value
 */
var roundNumber = function (value) {
    return Math.round(value * 100) / 100;
}
/**
 * return string replaced with specified params
 * @param {any} value
 * @param {any} arrayParams
 */
// if (!String.prototype.format) {
    String.prototype.format = function () {
        var args = arguments;
        return this.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined'
                ? args[number]
                : match
                ;
        });
    };
// }