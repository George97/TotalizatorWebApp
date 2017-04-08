(function (angular) {
    angular
        .module('appModule')
        .factory('appService', appService);
    appService.$inject = ['$http'];

    function appService($http) {
        var service = {
            getMatches: _getMatches
        }
        return service;

        function _getMatches() {
            var promise = $http.get("/Home/GetMatches");
            return promise;
        }
    }
})(angular);