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
				url = getUrlApis() + url;
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
				url = getUrlApis() + url;
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




        } catch (aE) {
            swal.fire();
        }
    }
})();