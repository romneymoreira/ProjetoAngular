(function () {
	'use strict';

	angular.module('app.dataServices')
           .factory('ds.dashboard', DsDashboard);

	DsDashboard.$inject = ['$http', 'appConfig', 'common'];

	function DsDashboard($http, appConfig, common) {

	    var apiRoute = common.makeApiRoute('dashboard');
		var service = {
		    getAll: getAll
		};
		return service;

		function getAll() {
		    return $http.get(apiRoute);
		}
	}
})();
