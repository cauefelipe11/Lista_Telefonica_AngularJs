angular.module("listaTelefonica").factory('contatosAPI', function($http){
	var _getContatos = function(){
		return $http({
			method: 'POST',
			url: '.net/api/listaTelefonica/getContatos'
		});
	};

	return {
		getContatos: _getContatos
	};
});