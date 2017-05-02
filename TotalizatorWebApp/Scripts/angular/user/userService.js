(function (angular) {
    angular
            .module('userModule')
            .factory('userService', userService);
    userService.$inject = ['$http'];

    function userService($http) {
        var services = {
            setCurrUser:setCurrUser,
            getLeague : getLeague,
            getLeagues: getLeagues,
            getStages: getStages,
            getMatches: getMatches,
            getBlankPA: getBlankPA,
            getAllUsers: getAllUsers,
            getValidTotalizators: getValidTotalizators,
            getAllTotalizators:getAllTotalizators,
            getTotalizator:getTotalizator,
            createTotalizator: createTotalizator,
            addUser: addUser,
            getBlunkResults: getBlunkResults,
            setTManagerId:setTManagerId,
            setForecast: setForecast,
            senRequest: senRequest,
            getUserNotifications: getUserNotifications,
            
            //getNextTotalizatorId: getNextTotalizatorId
        }
        return services;

        function setCurrUser() {
            var promise = $http.get('/User/SetCurrUser');
            return promise;
        }

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
            var promise = $http.post('/User/SetTotalizatorUser', { "userId": userid, "totalizatorId": totalizatorId });
            return promise;
        }

        function createTotalizator(organaizerId, tTitle, tPoints, stage, tAccess) {
            console.log('createTotalizator tAccess ', tAccess);
            console.log('createTotalizator tTitle ', tTitle);
            console.log('createTotalizator stage ', stage);
            console.log('createTotalizator tPoints ', tPoints);

            var promise = $http.post('/User/AddTotalizator', 
                 { "organaizerId":organaizerId,"stage": stage, "tTitle": tTitle, "tPoints": tPoints, "tAccess": tAccess });
                 
            return promise;
        }

        function getValidTotalizators(userId) {
            var promise = $http.get('/User/GetAllValidTotalizators', { params: { "userId": userId } });
            return promise;
        }

        function getAllTotalizators() {
            var promise = $http.get('/User/GetAllTotalizatorsWithUsers');
            return promise;
        }

        function getTotalizator(tId) {
            console.log('getTotalizator ', tId)
            var promise = $http.get('/User/GetTotalizator', { params: { "tId": tId } });
            return promise;
        }

        function getBlunkResults(stageId) {
            var promise = $http.get('/User/GetBlunkResults', { params: { "stageId": stageId } });
            return promise;
        }

        function setTManagerId(tid,userId) {
            var promise = $http.get('/User/SetTManagerId', { params: { "tid": tid, "userId": userId } });
            return promise;
        }

        function setForecast(matchResults,tmanagerId) {
            console.log(matchResults);
            matchResults.forEach(function (matchResult) {
                console.log('GuestTeamName', matchResult.GuestTeamName);
                $http.post('/User/SetForecast', { "matchResult": matchResult, "tmanagerId": tmanagerId });
            })
        }
       
        function senRequest(userId, totalId, orgId) {
            var promise = $http.post('/User/SenRequest', { "userId": userId, "totalId": totalId, "orgId": orgId });
            return promise;
        }

        function getUserNotifications(userId) {
            console.log(userId);
            var promise = $http.get('/User/GetUserNotifications', { params: { "userId": userId } });
            return promise;
        }
    }
})(angular);