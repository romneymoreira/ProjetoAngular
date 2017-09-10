(function () {
	'use strict';

	angular.module('app.dataServices')
           .factory('ds.financeiro', dsFinanceiro);

	dsFinanceiro.$inject = ['$http', 'appConfig', 'common'];

	function dsFinanceiro($http, appConfig, common) {

	    var apiRoute = common.makeApiRoute('financeiro');

		var service = {
			getContasApagarReceber: getContasApagarReceber,
			getParcelaById: getParcelaById,
			salvarFinanceiro: salvarFinanceiro,
			listarmeiospagamento: listarmeiospagamento,

			getTransferencias: getTransferencias,
			getTransferenciaById: getTransferenciaById,
			saveTransferencia: saveTransferencia,
			excluirTransferencia: excluirTransferencia,
			alterarParcela: alterarParcela,
			excluirParcela: excluirParcela,
			pesquisar: pesquisar,
			gerarparcelas: gerarparcelas,

			listarcheques: listarcheques,
			pesquisarCheques: pesquisarCheques,
			excluircheque: excluircheque,
			getChequeById: getChequeById,
			salvarCheque: salvarCheque,
			listarbancos: listarbancos,
			excluirbanco: excluirbanco,
			getBancoById: getBancoById,
			salvarBanco: salvarBanco,

			// contas
			listarContas: listarContas,
			excluirConta: excluirConta,
			getContaById: getContaById,
			saveConta: saveConta,
			pesquisarContas: pesquisarContas,

			// plano de contas 
			listarPlanodeContas: listarPlanodeContas,
			excluirPlanoConta: excluirPlanoConta,
			savePlanoConta: savePlanoConta,
			pesquisarPlanoContas: pesquisarPlanoContas,
			getPlanoContaById: getPlanoContaById,

			getFinanceiroPorId: getFinanceiroPorId
		};

		return service;


		function getFinanceiroPorId(id) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/getFinanceiroPorId?id=" + id);
		    return $http.get(common.makeUrl([apiRoute, 'getFinanceiroPorId']), { params: { id: id } });
		}

		//Implementação das funções
		//***********************************   plano de conta     ***************************************************

		function listarPlanodeContas() {
		    //return $http.get(servicebase.urlApi() + "/financeiro/listarPlanodeContas");
		    return $http.get(common.makeUrl([apiRoute, 'listarPlanodeContas']));
		}

		function excluirPlanoConta(id) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/excluirPlanoConta?id=" + id);
		    return $http.get(common.makeUrl([apiRoute, 'excluirPlanoConta']), { params: { id: id } });
		}

		function savePlanoConta(model) {
		    //return $http.post(servicebase.urlApi() + "/financeiro/savePlanoConta", model);
		    return $http.post(common.makeUrl([apiRoute, 'savePlanoConta']), model);
		}

		function pesquisarPlanoContas(nome, codigo, tipo) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/pesquisarPlanoContas?nome=" + nome + "&codigo=" + codigo + "&tipo=" + tipo);
		    return $http.get(common.makeUrl([apiRoute, 'pesquisarPlanoContas']), { params: { nome: nome, codigo: codigo, tipo: tipo } });

		}

		function getPlanoContaById(id) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/getPlanoContaById?id=" + id);
		    return $http.get(common.makeUrl([apiRoute, 'getPlanoContaById']), { params: { id: id } });
		}

		//Implementação das funções
		//***********************************   meio de pagamento     ***************************************************
		function listarmeiospagamento() {
		    //return $http.get(servicebase.urlApi() + "/financeiro/listarmeiospagamento");
		    return $http.get(common.makeUrl([apiRoute, 'listarmeiospagamento']));
		}

		//Implementação das funções
		//***********************************   conta     ***************************************************
		function listarcontas() {
		    //return $http.get(servicebase.urlApi() + "/financeiro/listarContas");
		    return $http.get(common.makeUrl([apiRoute, 'listarContas']));
		}

		function excluirConta(id) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/excluirConta?id=" + id);
		    return $http.get(common.makeUrl([apiRoute, 'excluirConta']), { params: { id: id } });
		}

		function getContaById(id) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/getContaById?id=" + id);
		    return $http.get(common.makeUrl([apiRoute, 'getContaById']), { params: { id: id } });
		}

		function saveConta(model) {
		    //return $http.post(servicebase.urlApi() + "/financeiro/saveConta", model);
		    return $http.post(common.makeUrl([apiRoute, 'saveConta']), model);
		}

		function pesquisarContas(nome, codigo) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/pesquisarContas?nome=" + nome + "&codigo=" + codigo);
		    return $http.get(common.makeUrl([apiRoute, 'pesquisarContas']), { params: { nome: nome, codigo: codigo } });
		}


		//***********************************   financeiro     ***************************************************

		function getContasApagarReceber(tipo) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/getContasApagarReceber?tipo=" + tipo);
		    return $http.get(common.makeUrl([apiRoute, 'getContasApagarReceber']), { params: { tipo: tipo } });
		}



		function excluirParcela(idFinanceiro, idParcela) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/excluirParcela?idFinanceiro=" + idFinanceiro + "&idParcela=" + idParcela);
		    return $http.get(common.makeUrl([apiRoute, 'excluirParcela']), { params: { idFinanceiro: idFinanceiro, idParcela: idParcela } });
		}

		function pesquisar(tipo, descricao, tipoConta) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/pesquisar?tipo=" + tipo + "&descricao=" + descricao + "&tipoConta=" + tipoConta);
		    return $http.get(common.makeUrl([apiRoute, 'pesquisar']), { params: { tipo: tipo, descricao: descricao, tipoConta: tipoConta } });
		}


		function listarContas() {
		    //return $http.get(servicebase.urlApi() + "/financeiro/listarContas");
		    return $http.get(common.makeUrl([apiRoute, 'listarContas']));
		}

		function getTransferencias() {
		    //return $http.get(servicebase.urlApi() + "/financeiro/getTransferencias");
		    return $http.get(common.makeUrl([apiRoute, 'getTransferencias']));
		}

		function getTransferenciaById(id) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/getTransferenciaById?id=" + id);
		    return $http.get(common.makeUrl([apiRoute, 'getTransferenciaById']), { params: { id: id } });
		}

		function excluirTransferencia(id) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/excluirTransferencia?id=" + id);
		    return $http.get(common.makeUrl([apiRoute, 'excluirTransferencia']), { params: { id: id } });
		}

		function getParcelaById(id) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/getById?id=" + id);
		    return $http.get(common.makeUrl([apiRoute, 'getById']), { params: { id: id } });
		}

		function gerarparcelas(model) {
		    //return $http.post(servicebase.urlApi() + "/financeiro/gerarparcelas", model);
		    return $http.post(common.makeUrl([apiRoute, 'gerarparcelas']), model);
		}

		function saveTransferencia(model) {
		    //return $http.post(servicebase.urlApi() + "/financeiro/saveTransferencia", model);
		    return $http.post(common.makeUrl([apiRoute, 'saveTransferencia']), model);
		}

		function alterarParcela(model) {
		    //return $http.post(servicebase.urlApi() + "/financeiro/alterarParcela", model);
		    return $http.post(common.makeUrl([apiRoute, 'alterarParcela']), model);
		}

		function salvarFinanceiro(model) {
		    //return $http.post(servicebase.urlApi() + "/financeiro/salvarFinanceiro", model);
		    return $http.post(common.makeUrl([apiRoute, 'salvarFinanceiro']), model);
		}

		//***********************************   cheques     ***************************************************
		function listarcheques() {
		    //return $http.get(servicebase.urlApi() + "/financeiro/listarcheques");
		    return $http.get(common.makeUrl([apiRoute, 'listarcheques']));
		}

		function excluircheque(id) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/excluircheque?id=" + id);
		    return $http.get(common.makeUrl([apiRoute, 'excluircheque']), { params: { id: id } });
		}

		function getChequeById(id) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/getChequeById?id=" + id);
		    return $http.get(common.makeUrl([apiRoute, 'getChequeById']), { params: { id: id } });
		}

		function pesquisarCheques(emitente, banco) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/pesquisarCheques?emitente=" + emitente + "&banco=" + banco);
		    return $http.get(common.makeUrl([apiRoute, 'pesquisarCheques']), { params: { emitente: emitente, banco: banco } });
		}

		function salvarCheque(model) {
		    //return $http.post(servicebase.urlApi() + "/financeiro/salvarCheque", model);
		    return $http.post(common.makeUrl([apiRoute, 'salvarCheque']), model);
		}

		//***********************************   bancos     ***************************************************
		function listarbancos() {
		    //return $http.get(servicebase.urlApi() + "/financeiro/listarbancos");
		    return $http.get(common.makeUrl([apiRoute, 'listarbancos']));
		}

		function excluirbanco(id) {
		   // return $http.get(servicebase.urlApi() + "/financeiro/excluirbanco?id=" + id);
		    return $http.get(common.makeUrl([apiRoute, 'excluirbanco']), { params: { id: id } });
		}

		function getBancoById(id) {
		    //return $http.get(servicebase.urlApi() + "/financeiro/getBancoById?id=" + id);
		    return $http.get(common.makeUrl([apiRoute, 'getBancoById']), { params: { id: id } });
		}

		function salvarBanco(model) {
		    //return $http.post(servicebase.urlApi() + "/financeiro/salvarBanco", model);
		    return $http.post(common.makeUrl([apiRoute, 'salvarBanco']), model);
		}
	}
})();
