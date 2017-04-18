(function (angular) {
    angular
        .module('appModule')
        .factory('appService', appService);
    appService.$inject = ['$http'];

    function appService($http) {
        var service = {
            getMatches: _getMatches,
            addTotalizator: _addTotalizator
        }
        return service;

        function _getMatches() {
            var promise = $http.get("/Home/GetMatches");
            return promise;
        }

        function _addTotalizator(id) {
            var promise = $http.post("/Home/AddTotalizator", { MatchId: id });
            return promise;
        }
    }
})(angular);