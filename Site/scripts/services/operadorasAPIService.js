angular.module("listaTelefonica").service('operadoreasAPI',  function($http, config){
	this.getOperadoras = function(){
		return $http({
			method: 'POST',
			url: config.baseUrl + 'getOperadoras'
		});
	};
	
});