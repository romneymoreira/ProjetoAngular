(function () {
    'use strict';

    var appManutencao = angular.module('app.pessoa', ['angular-loading-bar', 'app.config', 'webcam', 'ImageCropper']);

    appManutencao.config(["$stateProvider", "appConfig", function ($stateProvider, appConfig) {

        $stateProvider
        .state("pessoa", {
            parent: 'app',
            url: appConfig.routePrefix + "/pessoa",
            views: {
                'content': {
                    templateUrl: "app/pessoa/listar.pessoa.html",
                    controller: "PessoaListController as vm"
                }
            },
            data: { requireAuth: true }
        });
    }]);

})();