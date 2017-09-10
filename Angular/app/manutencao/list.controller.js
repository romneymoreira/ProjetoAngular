(function () {
    'use strict';

    angular
        .module('app.manutencao')
        .controller('Manutencao', Manutencao);

    Manutencao.$inject = ['$scope', '$rootScope', '$http', '$q', '$modal', 'blockUI', 'appConfig', 'common', 'notification', 'exception', 'ds.manutencao'];
    function Manutencao($scope, $rootScope, $http, $q, $modal, blockUI, appConfig, common, notification, exception, dsManutencao) {

        common.setBreadcrumb('Manutenção');
        var vm = this;

        //Funções
        vm.init = init;
        vm.edit = edit;
        vm.excluir = excluir;
        vm.novaAtividade = novaAtividade;
        vm.buscarResponsavel = buscarResponsavel;

        //Feature Start
        init();

        //Implementations
        function init() {
            
            vm.tipos = dsManutencao.constants.Tipo;
            vm.status = dsManutencao.constants.Status;
            var blocker = blockUI.instances.get('blockModal');
            blocker.start();
            var pAtividades = dsManutencao.getAllAtividades();
            pAtividades.then(function (result) {
                vm.atividades = result.data;
            });

            var pSetores = dsManutencao.getAllSetores();
            pSetores.then(function (result) {
                vm.setores = result.data;
            });

            $q.all([pAtividades, pSetores]).then(function () {
            })['finally'](function () {
                blocker.stop();
            }).catch(function (ex) {
                exception.throwEx(ex);
            });
        }

        function edit() { }

        function excluir() {
            //vm.askOptions = { Title: 'Excluir solicitação', Text: 'Deseja mesmo excluir esta solicitação?', Yes: 'Sim', No: 'Não' };
            //notification.ask(vm.askOptions, function (confirm) {
            //    if (confirm) {
            //notification.showSuccess('Beneficiário excluido com sucesso.');
            //    }
            //}
        }

        function buscarResponsavel(search) {
            if (search.length > 2) {

            }
        }

        function novaAtividade() {
            var modalInstance = $modal.open({
                templateUrl: 'app/manutencao/crud.html',
                controller: 'CrudManutencao as vm',
                backdrop: true,
                size: 'lg'
                //resolve: {
                //    endereco: function () {
                //        return endereco;
                //    }
                //}
            });
            modalInstance.result.then(function () {
                init();
            });
        }
    }
})();