mainControllerFn = function($scope, $http, $filter, uppercaseFilter){
	$scope.app = "Lista Telefônica";

	var dssTim = "tim";
	dssTim = uppercaseFilter(dssTim);

	$scope.tiposInscricoes = [
		{nome: "CPF",   id: "9999 9999", len: 14 },
		{nome: "CNPJ",  id: "9999 9988", len: 18}

	];

	$scope.contatos = [
		{nome: "Cauê",   data: new Date(), telefone: "9999 9999", operadora: {nome: "Vivo", codigo: 15, categoria: "Celular"}, cor: "yellow"},
		{nome: "Caio",   data: new Date(), telefone: "9999 9988", operadora: {nome: dssTim, codigo: 41, categoria: "Celular"}, cor: "red"},
		{nome: "Sandra", data: new Date(), telefone: "9999 9977", operadora: {nome: "Oi",   codigo: 14, categoria: "Celular"}, cor: "green"},
		{nome: "Bento",  data: new Date(), telefone: "9999 9966", operadora: {nome: "Vivo", codigo: 15, categoria: "Celular"}, cor: "blue"}
	];

	var carregaContatos = function(){
		
		/*
		$http.get("http://localhost:3412/contatos").success(function (data) {
			$scope.contatos = data;
		}).error(function (data, status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
		*/

	};

	var carregaOperadoras = function(){
		/*
		$http.get("http://localhost:3412/operadoras").success(function (data) {
			$scope.operadoras = data;
		});
		*/
	};

	var dssGvt = "gvt";
	dssGvt = $filter('uppercase')(dssGvt);


	$scope.operadoras = [
		{nome: "Oi",       codigo: 14, categoria: "Celular", preco: 1},
		{nome: "Vivo",     codigo: 15, categoria: "Celular", preco: 2},
		{nome: dssTim,     codigo: 41, categoria: "Celular", preco: 4},
		{nome: dssGvt,     codigo: 25, categoria: "Fixo",    preco: 5},
		{nome: "Embratel", codigo: 21, categoria: "Fixo",    preco: 1}
	];

	$scope.addContato = function(contato){				
		$scope.contatos.push(angular.copy(contato));
		delete $scope.contato;
		$scope.contatoForm.$setPristine();
	};

	$scope.delContato = function(contatos){
		$scope.contatos = contatos.filter(function(contato){
			if (!contato.selecionado) return contato;
		});
	};

	$scope.isContatoSelecionado = function(contatos){
		return contatos.some(function(contato){
			return contato.selecionado;
		});
	};

	$scope.ordenarPor = function(campo){
		$scope.direcaoOrder = !($scope.criterioOrdenacao != campo);
		$scope.criterioOrdenacao = campo;


	};

	$scope.showMsg = function(event){
		//alert(event.keyCode);
		//alert(event.altKey);
	};


	carregaContatos();
	carregaOperadoras();

	};


angular.module("listaTelefonica").controller('listaTelefonicaCtrl', mainControllerFn);