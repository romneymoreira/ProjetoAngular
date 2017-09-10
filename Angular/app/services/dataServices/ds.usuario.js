(function () {
    'use strict';

    angular.module('app.dataServices')
           .factory('ds.usuario', dsUsuario);

    dsUsuario.$inject = ['$http', 'appConfig', 'common'];

    function dsUsuario($http, appConfig, common) {

        var apiRoute = common.makeApiRoute('usuario');
        var service = {
            Usuarios: [
                { Id: 1, Nome: 'Usuario 1', Email: 'usuario1@gmail.com', DataNascimento: '01/11/1982' },
                { Id: 2, Nome: 'Usuario 2', Email: 'usuario2@gmail.com', DataNascimento: '01/10/1982' },
                { Id: 3, Nome: 'Usuario 3', Email: 'usuario3@gmail.com', DataNascimento: '01/10/1985' },
                { Id: 4, Nome: 'Usuario 4', Email: 'usuario4@gmail.com', DataNascimento: '06/10/1982' },
                { Id: 5, Nome: 'Usuario 5', Email: 'usuario5@gmail.com', DataNascimento: '01/12/1982' },
                { Id: 6, Nome: 'Usuario 6', Email: 'usuario6@gmail.com', DataNascimento: '01/10/1988' },
                { Id: 7, Nome: 'Usuario 7', Email: 'usuario7@gmail.com', DataNascimento: '15/10/1982' },
                { Id: 8, Nome: 'Usuario 8', Email: 'usuario8@gmail.com', DataNascimento: '21/10/1982' },
                { Id: 9, Nome: 'Usuario 9', Email: 'usuario9@gmail.com', DataNascimento: '01/11/1982' },
                { Id: 10, Nome: 'Usuario 10', Email: 'usuario10@gmail.com', DataNascimento: '01/05/1982' },
                { Id: 11, Nome: 'Usuario 11', Email: 'usuario11@gmail.com', DataNascimento: '01/06/1982' },
                { Id: 12, Nome: 'Usuario 12', Email: 'usuario12@gmail.com', DataNascimento: '09/10/1982' },
                { Id: 13, Nome: 'Usuario 13', Email: 'usuario13@gmail.com', DataNascimento: '08/10/1982' },
                { Id: 14, Nome: 'Usuario 14', Email: 'usuario14@gmail.com', DataNascimento: '07/10/1982' },
                { Id: 15, Nome: 'Usuario 15', Email: 'usuario15@gmail.com', DataNascimento: '03/10/1982' },
                { Id: 16, Nome: 'Usuario 16', Email: 'usuario16@gmail.com', DataNascimento: '01/02/1982' },
                { Id: 17, Nome: 'Usuario 17', Email: 'usuario17@gmail.com', DataNascimento: '01/01/1982' },
                { Id: 18, Nome: 'Usuario 18', Email: 'usuario18@gmail.com', DataNascimento: '06/10/1982' }
            ],
            getTipoLogradouro: getTipoLogradouro,
            getCidades: getCidades
            
        };
        
           

        return service;

        function getTipoLogradouro() {
            return $http.post(common.makeUrl([apiRoute, 'getTipoLogradouro']));
        }

        function getCidades(estado) {
            return $http.get(common.makeUrl([apiRoute, 'getCidades', estado]));
        }

    }
})();
