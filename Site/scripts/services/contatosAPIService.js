angular.module("listaTelefonica").factory('contatosAPI', function($http, config){
	var _getContatos = function(){
		return $http({
			method: 'POST',
			url: config.baseUrl + 'getContatos'
		});
	};

	var _addContato = function(contato){
		return $http({
			method: 'POST',
			url: config.baseUrl + 'saveContato',
			data: contato
		});
	};

	return {
		getContatos: _getContatos,
		addContato:  _addContato

	};
});