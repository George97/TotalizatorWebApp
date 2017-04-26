(function (angular) {
    angular
            .module('userModule')
            .factory('userService', userService);
    userService.$inject = ['$http'];

    function userService($http) {
        var services = {
            getLeague : getLeague,
            getLeagues: getLeagues,
            getStages: getStages,
            getMatches: getMatches,
            getBlankPA: getBlankPA,
            getAllUsers: getAllUsers,
            getNextTotalizatorId: getNextTotalizatorId
        }
        return services;

        function getLeague(id) {
            console.log(id);
            var promise = $http.get('/User/GetLeague', { params: { "LeagueId": id } });
            return promise;
        }

        function getLeagues() {
            var promise = $http.get('/User/GetLeagues');
            return promise;
        }

        function getStages(leagueId) {
            var promise = $http.get('/User/GetStages', { params: { "leagueId": leagueId } });
            return promise;
        }

        function getMatches(stageId) {
            var promise = $http.get('/User/GetMatches', { params: { "stageId": stageId } })
            return promise;
        }

        function getBlankPA() {
            var promise = $http.get('/user/GetBlankPointAnalysisView');
            return promise;
        }

        function getAllUsers() {
            var promise = $http.get('/User/GetAllUsers');
            return promise;
        }

        function addUser(userid,totalizatorId) {
            var promise = $http.post('/User/SetTotalizatorUser', { params: { "userId": userid, "totalizatorId": totalizatorId } });
            return promise;
        }

        function getNextTotalizatorId() {
            var promise = $http.get('/User/GetNextTotalizatorId');
            return promise;
        }
    }
})(angular);