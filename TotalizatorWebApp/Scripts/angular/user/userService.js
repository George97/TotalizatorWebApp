(function (angular) {
    angular
            .module('userModule')
            .factory('userService', userService);
    userService.$inject = ['$http'];

    function userService($http) {
        var services = {
            getLeagues: getLeagues,
            getStages: getStages,
            getMatches: getMatches
        }
        return services;

        function getLeagues() {
            var promise = $http.get('/User/GetLeagues');
            return promise;
        }

        function getStages(leagueId) {
            var promise = $http.get('/User/GetStages', leagueId);
            return promise;
        }

        function getMatches(stageId) {
            var promise = $http.get('/User/GetMatches', stageId)
            return promise;
        }
    }
})(angular);