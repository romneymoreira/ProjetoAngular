(function () {
    'use strict';

    angular
        .module('app.manutencao')
        .controller('CrudManutencao', CrudManutencao);

    CrudManutencao.$inject = ['$scope', '$http', '$q', '$modalInstance', 'blockUI', 'common', 'ds.manutencao'];

    function CrudManutencao($scope, $http, $q, $modalInstance, blockUI, common, dsManutencao) {

        common.setBreadcrumb('Manutenção');
        var vm = this;
        $scope.forms = {};
        vm.formValid = true;

        //Funções
        vm.init = init;
        vm.save = save;

        vm.Titulo = "Incluir Atividade";

        //Feature Start
        init();

        //Implementations
        function init() {
            var date = new Date(), y = date.getFullYear(), m = date.getMonth();
            vm.data = moment(date).format("DD/MM/YYYY");
            vm.tipos = dsManutencao.constants.Tipo;
            vm.status = dsManutencao.constants.Status;
            var blocker = blockUI.instances.get('blockModal');
            blocker.start();

            var pSetores = dsManutencao.getAllSetores();
            pSetores.then(function (result) {
                vm.setores = result.data;
            });

            $q.all([pSetores]).then(function () {
            })['finally'](function () {
                blocker.stop();
            }).catch(function (ex) {
                exception.throwEx(ex);
            });
        }

        function save() {
            vm.formValid = common.validateForm($scope.forms.editForm);
            if (vm.formValid) {
                vm.AlertMessage = "";
            }
            else {
                vm.AlertClassI = 'fa fa-exclamation-triangle';
                vm.AlertClassDiv = 'alert alert-danger';
                vm.AlertMessage = "Preencha os campos em vermelho.";
            }
        }

        function cancel() {
            $modalInstance.dismiss('cancel');
            //$modalInstance.close(true);
        }
    }
})();