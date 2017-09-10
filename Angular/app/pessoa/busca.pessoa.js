(function () {
    'use strict';

    angular
        .module('app.pessoa')
        .controller('BuscarPessoaController', BuscarPessoaController);

    BuscarPessoaController.$inject = ['$scope', '$http', '$q', '$modal', '$modalInstance', 'DTOptionsBuilder', 'blockUI', 'common', 'notification', 'ds.pessoa'];

    function BuscarPessoaController($scope, $http, $q, $modal, $modalInstance, DTOptionsBuilder, blockUI, common, notification, dsPessoa) {

        var vm = this;

        $scope.forms = {};
        vm.formValid = true;

        //Funções
        vm.init = init;
        vm.cancel = cancel;
        vm.selecionar = selecionar;
        vm.addpessoa = addpessoa;
        vm.buscar = buscar;

        //Feature Start
        init();

        //Implementations
        function init() {
            vm.dtOptions = DTOptionsBuilder
                    .newOptions()
                    .withOption('order', [[0, 'desc']]);
        }

        function buscar() {
            if (vm.nome == undefined || vm.nome == "") {
                vm.FormMessage = "Para realizar a busca você deve preencher o campo nome";
            }
            else {
                vm.FormMessage = "";
                pacienteservice
                   .getPacientesPorNome(vm.nome)
                   .then(function (result) {
                       if (result.data.length == 0)
                           vm.FormMessage = "Nenhum resultado encontrado para a busca realizada.";
                       else
                           vm.pacientes = result.data;
                   })
                   .catch(function (ex) {
                       notification.showError(ex.data.Message);
                   });
            }
        }


        function addpessoa(id) {
            var modalInstance = $modal.open({
                templateUrl: 'app/pessoa/crud.paciente.html',
                controller: 'PessoaController as vm',
                size: 'lg',
                backdrop: 'static',
                resolve: {
                    id: function () {
                        return id;
                    },
                }
            });
            modalInstance.result.then(function () {
                init();
            });
        }

        function selecionar(item) {
            $modalInstance.close(item);
        }

        function cancel() {
            $modalInstance.dismiss('cancel');
        }

    }
})();