(function (angular) {
    angular
            .module('adminModule')
            .factory('adminService', adminService);
    adminService.$inject = ['$http'];

    function adminService($http) {
        var services = {
            getLeagues: getLeagues,
            getStages: getStages,
            getAllUsers:getAllUsers,
            getAllTotalizators: getAllTotalizators,
            postResult: postResult,
            banUser: banUser
        }
        return services;

        function getLeagues() {
            var promise = $http.get('/Data/GetLeagues');
            return promise;
        }

        function getStages(leagueId) {
            var promise = $http.get('/Data/GetStages', { params: { "leagueId": leagueId } });
            return promise;
        }

        function getAllUsers() {
            var promise = $http.get('/Data/GetAllUsers');
            return promise;
        }

        function getAllTotalizators() {
            var promise = $http.get('/Data/GetAllTotalizatorsWithUsers');
            return promise;
        }

        function postResult(results) {
            console.log(results);
            $http.post('/Data/PostResult', { "results": results });
        }

        function banUser(userId) {
            $http.post('/Data/BanUser', { "userId": userId });
        }

    }
})(angular);