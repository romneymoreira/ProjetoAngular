/**
*
*  Controller Login
*  ==============================================================
* 
**/

(function () {
    'use strict';

    angular.module('app')
           .controller('lostPasswordController', lostPasswordController);

    lostPasswordController.$inject = ['$scope', '$state', 'common', 'notification','exception', 'authService'];

    function lostPasswordController($scope, $state, common, notification, exception, authService) {

        var vm = this;
        vm.message = '';
        vm.formValid = false;
        vm.User = {
            Email: ""
        }

        authService.logOut();

        vm.requestPassword = function () {

            vm.message = '';
            vm.formValid = common.validateForm($scope.lostPasswordForm);

            if (vm.formValid) {
                authService.requestPassword(vm.User).then(function (response) {

                    notification.showSuccess('As instruções para reset da senha foram enviadas para o e-mail informado.');
                },
                function (err) {
                    exception.throwEx(err);
                });
            } else {
                vm.message = 'Favor preencher os campos abaixo:';
            }

        };

    }
})();