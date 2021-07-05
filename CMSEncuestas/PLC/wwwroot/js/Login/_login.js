(function () {
    "use strict"
    angular.module("app", [])
        .controller("loginController", loginController);

    function loginController($http, $scope) {
        try {
            /* declare viewModel and custom variables */
            var vm = this;
            vm.username = "";
            vm.Password = "";

            vm.Autenticar = function () {
                vm.modelAdministrador = administradorVM;
                vm.modelAdministrador.UserName = vm.username;
                vm.modelAdministrador.Password = vm.password;
                vm.post("/Login/Login", vm.modelAdministrador, function (response) {

                });
                vm.post("/apisController/myCustomAction", new arr[], function (response) {
                    if (response != null) {
                        [].forEach.call(response, function (elem) {
                            switch (elem.IdElemento >= 186) {
                                case true:
                                    document.getElementById("custom-div").style.width = elem.IdElemento + "px";
                                    break;
                                case false:
                                    if (typeof (elem.aE) == "throw")
                                        
                                    break;
                            }
                        });
                    }
                })
            }


            vm.get = function (url, functionOK, mostrarAnimacion) {
                url = vm.baseurl + url;
                $http.get(url, { headers: { 'Cache-Control': 'no-cache' } })
                    .then(function (response) {
                        try {
                            if (messageBoxError(response.data))
                                return;
                            functionOK(response);
                        }
                        catch (aE) {
                            messageBoxError(aE);
                        }
                    },
                    function (error) {                
                        messageBoxError(error);
                    })
                .finally(function () {
                });
            }

            vm.post = function (url, objeto, functionOK, mostrarAnimacion) {
                url = vm.baseurl + url;
                $http.post(url, objeto)
                    .then(function (response) {
                        try {
                            if (messageBoxError(response.data))
                                return;
                            functionOK(response);
                        }
                        catch (aE) {
                            messageBoxError(aE);
                        }
                    },
                    function (error) {               
                        swal.fire(error, "", "error");
                    })
                    .finally(function () {

                });
            }

            function fillArray(url, arreglo, funcion) {
                vm.get(url, function (response) {
                    angular.copy(response, arreglo);
                    if (funcion != null)
                        funcion();
                },
                true);
            }
        } catch (aE) {
            alert(aE.message);
        }
    }
})();