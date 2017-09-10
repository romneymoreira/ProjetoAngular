﻿(function () {
    'use strict';

    angular
        .module('app.financeiro')
        .controller('CrudPlanoContas', CrudPlanoContas);

    CrudPlanoContas.$inject = ['$scope', '$http', '$modal', '$modalInstance', 'blockUI', 'common', 'notification', 'ds.financeiro', 'id'];

    function CrudPlanoContas($scope, $http, $modal, $modalInstance, blockUI, common, notification, dsFinanceiro, id) {

        var vm = this;
        vm.State = "Incluir Plano de Conta";
        vm.FormMessage = "";

        $scope.forms = {};
        vm.formValid = true;

        //Funções
        vm.init = init;
        vm.save = save;
        vm.cancel = cancel;

        //Feature Start
        init();

        //Implementations
        function init() {
            
            vm.tipos = [{ Key: "Despesa", Value: "Despesa" }, { Key: "Receita", Value: "Receita" }, { Key: "Ativo", Value: "Ativo" }, { Key: "Passivo", Value: "Passivo" }, { Key: "Patrimonio Liquido", Value: "Patrimonio Liquido" }];

            vm.FormMessage = "";

            if (id > 0) {
               
                vm.State = "Editar Plano de Conta";
                var blocker = blockUI.instances.get('blockModalContas');
                blocker.start();
                dsFinanceiro
                    .getPlanoContaById(id)
                    .then(function (result) {
                        vm.planoconta = result.data;
                            
                        if (vm.planoconta.Situacao == 'Ativo')
                            vm.SituacaoA = "Ativo";
                        else
                            vm.SituacaoI = "Inativo";

                        vm.tipoSelecionado = vm.planoconta.Tipo;


                    })
                    .catch(function (ex) {
                        notification.showError(ex.Message);
                    })['finally'](function () {
                        blocker.stop();
                    });
            } else {
                vm.SituacaoA = "Ativo";
            }
        }

        function cancel() {
            $modalInstance.dismiss('cancel');
        }

        function save() {
            $scope.showErrorsCheckValidity = true;
            if ($scope.forms.contas.$valid) {


                if (vm.SituacaoA == 'Ativo')
                    vm.planoconta.Situacao = "Ativo";
                else
                    vm.planoconta.Situacao = "Inativo";

                vm.planoconta.Tipo = vm.tipoSelecionado;

                vm.FormMessage = "";
                var blocker = blockUI.instances.get('blockModalContas');
                blocker.start();

                dsFinanceiro
                    .savePlanoConta(vm.planoconta)
                    .then(function (result) {
                        vm.conta = result.data;
                        if (id == 0)
                            notification.showSuccessBar("Cadastro realizado com sucesso");
                        else
                            notification.showSuccessBar("Alteração realizada com sucesso");

                        $modalInstance.close();
                    })
                    .catch(function (ex) {
                        notification.showError(ex.Message);
                    })['finally'](function () {
                        blocker.stop();
                    });
            }
            else {
                vm.FormMessage = "Existem campos obrigatórios sem o devido preenchimento";
            }
        }

    }
})();