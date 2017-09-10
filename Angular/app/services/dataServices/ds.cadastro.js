(function () {
    'use strict';

    angular.module('app.dataServices')
           .factory('ds.cadastro', dsCadastro);

    dsCadastro.$inject = ['$http', 'appConfig', 'common'];

    function dsCadastro($http, appConfig, common) {

        var apiRoute = common.makeApiRoute('cadastro');
        var service = {
            save: save
        };
        return service;

      
        function save(model) {
            return $http.post(common.makeUrl([apiRoute, 'save']), model);
        }
    }
})();
