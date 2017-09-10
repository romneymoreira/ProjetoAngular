﻿(function () {
    'use strict';

    angular.module('app.dataServices')
           .factory('ds.manutencao', dsManutencao);

    dsManutencao.$inject = ['$http', 'appConfig', 'common'];

    function dsManutencao($http, appConfig, common) {

        var apiRoute = common.makeApiRoute('manutencao');
        var service = {
            constants: {
                Tipo: [
	                { Descricao: 'Inclusão', Codigo: '1' },
	                { Descricao: 'Alterção', Codigo: '2' },
	                { Descricao: 'Exclusão', Codigo: '3' }
                ],
                Status: [
                       { Descricao: 'Pendente', Codigo: '1' },
                       { Descricao: 'Em Andamento', Codigo: '2' },
                       { Descricao: 'Concluído', Codigo: '3' }
                ]
            },
            getAllSetores: getAllSetores,
            getAllAtividades: getAllAtividades,
            getAtividadeById: getAtividadeById,
            save: save
        };
        return service;

        function getAllSetores() {
            return $http.get(common.makeUrl([apiRoute, 'setores']));
        }

        function getAllAtividades() {
            return $http.get(common.makeUrl([apiRoute, 'listar']));
        }

        function getAtividadeById(id) {
            return $http.get(common.makeUrl([apiRoute, 'byId']), { params: { id: id } });
        }
        function save(model) {
            return $http.post(common.makeUrl([apiRoute, 'save']), model);
        }
    }
})();
