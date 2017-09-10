/**
*
*  Controller Login
*  ==============================================================
* 
**/

(function () {
    'use strict';

    angular.module('app')
           .controller('loginController', loginController);

    loginController.$inject = ['$rootScope', '$scope', '$state', 'common', 'notification', 'authService'];

    function loginController($rootScope, $scope, $state, common, notification, authService) {
        var vm = this;
        vm.message = '';
        vm.formValid = false;
        vm.User = {
            UserName: "",
            Password: ""
        }

        $rootScope.$state = $state;
        authService.logOut();

        vm.login = function () {

            vm.message = '';
            vm.formValid = common.validateForm($scope.loginForm);

            console.log($scope.loginForm);

            if (vm.formValid) {
                authService.login(vm.User).then(function (response) {
                    console.log(response);
                    $state.go('dashboard');

                },
                    function (err) {
                        if(err != null)
                            notification.showError(err.error_description);
                        else
                            notification.showError("Ocorreu um erro ao processar o login.");
                    });
            } else {
                vm.message = 'Favor preencher os campos abaixo:';
            }

        };

    }
})();