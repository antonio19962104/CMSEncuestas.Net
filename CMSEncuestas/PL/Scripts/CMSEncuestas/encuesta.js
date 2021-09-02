(function () {
    "use strinct"
    angular.module("app", []).controller("encuestaController", encuestaController);
	
    function encuestaController($http, $scope) {
		try {
			var vm = this;
			/**
			 * get request
			 * @param {any} url
			 * @param {any} functionOK
			 */
			vm.get = function (url, functionOK) {
				url = getUrlApisEncuesta() + url;
				$http.get(url, { headers: { 'Cache-Control': 'no-cache' } })
					.then(function (response) {
						try {
							if (messageBoxError(response))
								return;
							functionOK(response);
						}
						catch (aE) {
							messageBoxError(aE);
							vm.writeLogFronEnd(aE);
						}
					},
					function (error) {                  
						messageBoxError(error);
					})
				.finally(function () {

				});
			}
			/**
			 * post request
			 * @param {any} url
			 * @param {any} objeto
			 * @param {any} functionOK
			 */
			vm.post = function (url, objeto, functionOK) {
				url = getUrlApisEncuesta() + url;
				$http.post(url, objeto)
					.then(function (response) {
						try {
							if (messageBoxError(response))
								return;
							functionOK(response);
						}
						catch (aE) {
							messageBoxError(aE);
							vm.writeLogFronEnd(aE);
						}
					},
					function (error) {                  
						messageBoxError(error);
					})
				.finally(function () {
						
				});
			}
			/**
			 * fill specified array data
			 * @param {any} url
			 * @param {any} arreglo
			 * @param {any} funcion
			 */
			function fillArray(url, arreglo, funcion) {
				vm.get(url, function (response) {
					angular.copy(response, arreglo);
					if (funcion != null)
						funcion();
				},
				true);
			}
            vm.add = function () {
				vm.post("Add", vm.Encuesta, function (response) {
					switch (response.saveStatus) {
						case 0:
							swal.fire("No se ha podido crear la encuesta", "", "info").then(function () {
								return;
							});
							break;
						case 1:
							swal.fire("La encuesta " + vm.Encuesta.Nombre + " ha sido creada correctamente", "", "success").then(function () {
								vm.getAll();
							});
						default:
					}
				});
            }
            vm.getAll = function () {
				vm.get("GetAll", function (response) {
					vm.Encuestas = response.Objects;
					vm.crearGrid(vm.Encuestas);
				});
            }
            vm.edit = function () {
				vm.post("Edit", vm.Encuesta, function (response) {
					switch (response.saveStatus) {
						case 0:
							swal.fire("No se ha podido actualizar la encuesta", "", "info").then(function () {
								return;
							});
							break;
						case 1:
							swal.fire("La encuesta " + vm.Encuesta.Nombre + " ha sido actualizada correctamente", "", "success").then(function () {
								vm.getAll();
							});
                        default:
                    }
				});
			}
            vm.delete = function (id) {
				vm.get("Delete/?Id=" + id, function (response) {
                    switch (response.saveStatus) {
						case 0:
							swal.fire("No se ha podido eliminar la encuesta", "", "info").then(function () {
								return;
							});
							break;
						case 1:
							swal.fire("La encuesta " + vm.Encuesta.Nombre + " ha sido eliminada correctamente", "", "success").then(function () {
								vm.getAll();
							});
                        default:
                    }
				});
			}
            vm.crearGrid = function () {
				/*kendo*/
            }



        } catch (aE) {
            swal.fire();
        }
    }
})();