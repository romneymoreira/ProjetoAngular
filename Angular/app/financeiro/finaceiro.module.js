(function () {
    'use strict';

    var appManutencao = angular.module('app.financeiro', ['angular-loading-bar', 'app.config']);

    appManutencao.config(["$stateProvider", "appConfig", function ($stateProvider, appConfig) {

        $stateProvider
        .state("receber", {
            parent: 'app',
            url: appConfig.routePrefix + "/financeiro/:tipo",
            views: {
                'content': {
                    templateUrl: "app/financeiro/lista_financeiro.html",
                    controller: "FinanceiroController as vm"
                }
            },
            data: { requireAuth: true }
        })
         .state("pagar", {
             parent: 'app',
             url: appConfig.routePrefix + "/financeiro/:tipo",
             views: {
                 'content': {
                     templateUrl: "app/financeiro/lista_financeiro.html",
                     controller: "FinanceiroController as vm"
                 }
             },
             data: { requireAuth: true }
         })
         .state("addparcelas", {
             parent: 'app',
             url: appConfig.routePrefix + "/novaConta/:id?tipo",
             views: {
                 'content': {
                     templateUrl: "app/financeiro/crud_financeiro.html",
                     controller: "CrudFinanceiro as vm"
                 }
             },
             data: { requireAuth: true }
         })
         .state("planocontas", {
             parent: 'app',
             url: appConfig.routePrefix + "/planocontas",
             views: {
                 'content': {
                     templateUrl: "app/financeiro/lista_planocontas.html",
                     controller: "PlanoContas as vm"
                 }
             },
             data: { requireAuth: true }
         })
         .state("transferencias", {
             parent: 'app',
             url: appConfig.routePrefix + "/transferencias",
             views: {
                 'content': {
                     templateUrl: "app/financeiro/lista_transferencias.html",
                     controller: "Transferencias as vm"
                 }
             },
             data: { requireAuth: true }
         })
         .state("editarparcela", {
             parent: 'app',
             url: appConfig.routePrefix + "/Parcelas/:id?tipo",
             views: {
                 'content': {
                     templateUrl: "app/financeiro/edit_parcela.html",
                     controller: "EditarParcela as vm"
                 }
             },
             data: { requireAuth: true }
         })
         .state("cheques", {
             parent: 'app',
             url: appConfig.routePrefix + "/cheques",
             views: {
                 'content': {
                     templateUrl: "app/financeiro/lista.cheque.html",
                     controller: "Cheques as vm"
                 }
             },
             data: { requireAuth: true }
         })
         .state("bancos", {
             parent: 'app',
             url: appConfig.routePrefix + "/bancos",
             views: {
                 'content': {
                     templateUrl: "app/financeiro/lista.banco.html",
                     controller: "Bancos as vm"
                 }
             },
             data: { requireAuth: true }
         })
         .state("conta", {
             parent: 'app',
             url: appConfig.routePrefix + "/conta",
             views: {
                 'content': {
                     templateUrl: "app/financeiro/lista.conta.html",
                     controller: "Conta as vm"
                 }
             },
             data: { requireAuth: true }
         })
        .state("dashboardfinanceiro", {
            parent: 'app',
            url: appConfig.routePrefix + "/dashboardfinanceiro",
            views: {
                'content': {
                    templateUrl: "app/financeiro/dashboard_financeiro.html",
                    controller: "DashboardFinanceiro as vm"
                }
            },
            data: { requireAuth: true }
        });
    }]);

})();


