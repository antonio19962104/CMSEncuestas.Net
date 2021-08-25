/* Author: José Antonio Murillo García
 * Email: j.antoniomg96@outlook.com
 * Version: 1.0
 * Update: 24/08/2021
 * Description: Funciones globales del sitio
 */
(function () {
    /*
     * Libraries
     */
    //const jquery = require("/CMSEncuestas.Net/CMSEncuestas/PL/Scripts/jquery-3.4.1");
    //const popper = require("@popperjs/core");
    //const html2canvas = require("/CMSEncuestas.Net/CMSEncuestas/PL/Scripts/libs/html2canvas");
    //const linQ = require("/CMSEncuestas.Net/CMSEncuestas/PL/Scripts/libs/LinQ");
    const linQ2 = import("/CMSEncuestas.Net/CMSEncuestas/PL/Scripts/libs/LinQ");
    
    /*
     * Instance of objects
     */
    var encuesta = localStorage.getItem("modelEncuesta");

    /*
     * instance of pdf document
     */
    const docReporte = new jsPDF();
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
                return false;/* not exist error */
            }
            else {
                hideLoad();
                swal.fire("Ha ocurrido un error", data.ErrorMessage, "error");
                $("#header").append('<div class="col-8" style="margin-left:auto; margin-right:auto;"><div class="title-error" style="background-color: #efefef; height:30px; text-align:center"><span style="vertical-align:middle; font-weight:bold">Titulo</span></div><div class="body mt-2">Se ha producido un error el ejecutar la definicion del metodo GetDatFromBD</div></div>');
                return data.Correct;/* exist error */
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
     * return url apis Encuesta
    */
    var getUrlApisEncuesta = function () {
        return getBaseUrl() + "/apisEncuesta/";
    }
    /*
     * return url apis Base de Datos 
    */
    var getUrlApisEncuesta = function () {
        return getBaseUrl() + "/apisBD/";
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
    String.prototype.format = function () {
        var args = arguments;
        return this.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined'
                ? args[number]
                : match
                ;
        });
    };
    /**
     * add specified class by id element
     * @param {any} elemId
     * @param {any} className
     */
    var addClassByElementId = function (elemId, className) {
        document.getElementById(elemId).classList.add(className);
    }
    /**
     * add specified class to all elems with elemClass parameter
     * @param {any} elemClass
     * @param {any} className
     */
    var addClassByClassName = function (elemClass, className) {
        var elements = document.getElementsByClassName(elemClass);
        [].forEach.call(elements, function (elem) {
            elem.classList.add(className);
        });
    }
    /**
     * remove specified class by id element
     * @param {any} elemId
     * @param {any} className
     */
    var removeClassByElementId = function (elemId, className) {
        document.getElementById(elemId).className.remove(className);
    }
    /**
     * remove specified class to all elems with elemClass parameter
     * @param {any} elemClass
     * @param {any} className
     */
    var removeClassByClassName = function (elemClass, className) {
        var elements = document.getElementsByClassName(elemClass);
        [].forEach.call(elements, function (elem) {
            elem.classList.remove(className);
        });
    }
    /**
     * return if dom element has specified class
     * @param {any} elem
     * @param {any} className
     */
    var hasClass = function (elem, className) {
        return elem.classList.contains(className);
    }
    /**
     * add page with specified div content to pdf
     * @param {any} divId
     */
    var addContentPDF = function (divId) {
        var finalPaddingTop = 2;
        docReporte.addPage();
        docReporte.addHTML($('#' + divId)[0], 0, (finalPaddingTop / 2), { /* options */ },
            function () {
                /* then function */
            });
    }
    /**
     * return filter array by nameFilter and valFilter specified
     * @param {Array} arr
     * @param {String} nameFilter
     * @param {String} valFilter
     */
    var where = function (arr, nameFilter, valFilter) {
        return Enumerable.from(arr).where(o => o.nameFilter == valFilter).toList();
    }
    /**
     * return if array contains valFilter in nameFilter specified
     * @param {Array} arr
     * @param {String} nameFilter
     * @param {String} valFilter
     */
    var contains = function (arr, nameFilter, valFilter) {
        return Enumerable.from(arr).contains(o => o.nameFilter == valFilter).toList();
    }
    /**
    * return array order by nameFilter specified asc
    * @param {Array} arr
    * @param {String} nameOrder
    */
    var orderBy = function (arr, nameOrder) {
        return Enumerable.from(arr).orderBy(o => o.nameOrder).toList();
    }
    /**
     * return response of get request by ajax
     * @param {String} url
     * @param {Array} paramsName
     * @param {Array} paramsVal
     */
    var getRequest = function (url, paramsName, paramsVal) {
        if (paramsName.length != paramsVal.length) {
            swal.fire("El numero de parametros debe coincider con el numero de valores", "", "info").then(function () {
                return false;
            });
            return false;
        }
        url = setParams(url, paramsName, paramsVal);
        $.ajax({
            url: url.substring(0, (url.length - 1)),
            type: "GET",
            success: function (response) {
                return response;
            },
            error: function (err) {
                return err;
            }
        });
    }
    /**
     * return response of post request by ajax
     * @param {String} url
     * @param {Array} paramsName
     * @param {Array} paramsVal
     * @param {Object} object
     */
    var postRequest = function (url, paramsName, paramsVal, object) {
        if (paramsName.length != paramsVal.length) {
            swal.fire("El numero de parametros debe coincider con el numero de valores", "", "info").then(function () {
                return false;
            });
            return false;
        }
        url = setParams(url, paramsName, paramsVal);
        $.ajax({
            url: url,
            type: "POST",
            data: object == null ? [] : object,
            success: function (response) {
                return response;
            },
            error: function (err) {
                return err;
            }
        });
    }
    /**
     * set params to url
     * @param {String} url
     * @param {Array} paramsName
     * @param {Array} paramsVal
     */
    var setParams = function (url, paramsName, paramsVal) {
        url += "/?";
        [].forEach.call(paramsName, function (item, index) {
            url += item + "=" + paramsVal[index] + "&";
        });
        return url.substring(0, (url.length - 1));
    }
})();