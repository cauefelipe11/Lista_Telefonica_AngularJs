mainControllerFn = function($scope, $filter, uppercaseFilter, contatosAPI, operadoreasAPI, serialGenerator){
	$scope.app = "Lista Telefônica";

	//$scope.tiposInscricoes = [
	//	{nome: "CPF",   id: "9999 9999", len: 14 },
	//	{nome: "CNPJ",  id: "9999 9988", len: 18}
	//];

	$scope.contatos = [
		//{nome: "Cauê",   data: new Date(), telefone: "9999-9999", operadora: {nome: "Vivo", codigo: 15, categoria: "Celular"}},
		//{nome: "Caio",   data: new Date(), telefone: "9999-9988", operadora: {nome: dssTim, codigo: 41, categoria: "Celular"}},
		//{nome: "Sandra", data: new Date(), telefone: "9999-9977", operadora: {nome: "Oi",   codigo: 14, categoria: "Celular"}},
		//{nome: "Bento",  data: new Date(), telefone: "9999-9966", operadora: {nome: "Vivo", codigo: 15, categoria: "Celular"}}
	];

	//var dssGvt = "gvt";
	//dssGvt = $filter('uppercase')(dssGvt);

	//var dssTim = "tim";
	//dssTim = uppercaseFilter(dssTim);


	$scope.operadoras = [
		//{nome: "Oi",       codigo: 14, categoria: "Celular", preco: 1},
		//{nome: "Vivo",     codigo: 15, categoria: "Celular", preco: 2},
		//{nome: dssTim,     codigo: 41, categoria: "Celular", preco: 4},
		//{nome: dssGvt,     codigo: 25, categoria: "Fixo",    preco: 5},
		//{nome: "Embratel", codigo: 21, categoria: "Fixo",    preco: 1}
	];

	var carregaContatos = function(){
		contatosAPI.getContatos().then(
			function success(response){
				$scope.contatos = response.data;
				//alert(response.data);
			},
			function failure(response){
				$scope.message = "Aconteceu um problema: " + response.data;
			}
		);

	};

	var carregaOperadoras = function(){
		operadoreasAPI.getOperadoras().then(
			function success(response){
				$scope.operadoras = response.data;
			},
			function failure(response){
				$scope.message = "Aconteceu um problema: " + response.data;
			}
		);
	};

	$scope.addContato = function(contato){				
		contato.serial = serialGenerator.generate();

		contatosAPI.addContato(contato).then(
			function success(response){
				//$scope.contatos.push(angular.copy(contato));
				carregaContatos();
				delete $scope.contato;
				$scope.contatoForm.$setPristine();
			},
			function failure(response){
				$scope.message = "Aconteceu um problema: " + response.data;
			}
		);
		
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
		$scope.direcaoOrder = $scope.criterioOrdenacao == campo ? !$scope.direcaoOrder : false;
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