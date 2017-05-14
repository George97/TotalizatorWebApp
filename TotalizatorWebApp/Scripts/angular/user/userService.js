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
            getBlunkResults: getBlunkResults,
            setTManagerId:setTManagerId,
            setForecast: setForecast,
            senRequest: senRequest,
            getUserNotifications: getUserNotifications,
            acceptUser: acceptUser,
            rejectUser: rejectUser,
            removeNotification: removeNotification,
            userHasAccess: userHasAccess,
            postResult: postResult
        }
        return services;

        function setCurrUser() {
            var promise = $http.get('/Data/SetCurrUser');
            return promise;
        }

        function getLeague(id) {
            console.log(id);
            var promise = $http.get('/Data/GetLeague', { params: { "LeagueId": id } });
            return promise;
        }

        function getLeagues() {
            var promise = $http.get('/Data/GetLeagues');
            return promise;
        }

        function getStages(leagueId) {
            var promise = $http.get('/Data/GetStages', { params: { "leagueId": leagueId } });
            return promise;
        }

        function getMatches(stageId) {
            var promise = $http.get('/Data/GetMatches', { params: { "stageId": stageId } })
            return promise;
        }

        function getBlankPA() {
            var promise = $http.get('/Data/GetBlankPointAnalysisView');
            return promise;
        }

        function getAllUsers() {
            var promise = $http.get('/Data/GetAllUsers');
            return promise;
        }

        //function addUser(userid,totalizatorId) {
        //    var promise = $http.post('/User/SetTotalizatorUser', { "userId": userid, "totalizatorId": totalizatorId });
        //    return promise;
        //}

        function createTotalizator(organaizerId, tTitle, tPoints, stage, tAccess) {
            var promise = $http.post('/Data/AddTotalizator',
                 { "organaizerId":organaizerId,"stage": stage, "tTitle": tTitle, "tPoints": tPoints, "tAccess": tAccess });
                 
            return promise;
        }

        function getValidTotalizators(userId) {
            var promise = $http.get('/Data/GetAllValidTotalizators', { params: { "userId": userId } });
            return promise;
        }

        function getAllTotalizators() {
            var promise = $http.get('/Data/GetAllTotalizatorsWithUsers');
            return promise;
        }

        function getTotalizator(tId) {
            console.log('getTotalizator ', tId)
            var promise = $http.get('/Data/GetTotalizator', { params: { "tId": tId } });
            return promise;
        }

        function getBlunkResults(stageId) {
            var promise = $http.get('/Data/GetBlunkResults', { params: { "stageId": stageId } });
            return promise;
        }

        function setTManagerId(tid, userId, access) {
            var promise = $http.get('/Data/SetTManagerId', { params: { "tid": tid, "userId": userId, "access": access } });
            return promise;
        }

        function setForecast(matchResults,totalId,userId) {
            var promise = $http.post('/Data/SetForecast', { "matchResults": matchResults, "totalId": totalId, "userId": userId });
            console.log(matchResults);
            return promise;
            //matchResults.forEach(function (matchResult) {
            //    console.log('GuestTeamName', matchResult.GuestTeamName);
            //    $http.post('/Data/SetForecast', { "matchResult": matchResult, "tmanagerId": tmanagerId });
            //})
        }
       
        function senRequest(userId, totalId, orgId) {
            var promise = $http.post('/Data/SendRequest', { "userId": userId, "totalId": totalId, "orgId": orgId });
            return promise;
        }

        function getUserNotifications(userId) {
            console.log(userId);
            var promise = $http.get('/Data/GetUserNotifications', { params: { "userId": userId } });
            return promise;
        }

        function acceptUser(userId, totalId) {
            console.log(userId, totalId);
            var promise = $http.post('/Data/AcceptUser', { "userId": userId, "totalId": totalId });
            return promise;
        }

        function rejectUser(userId, totalId) {
            var promise = $http.post('/Data/RejectUser', { "userId": userId, "totalId": totalId });
            return promise;
        }

        function removeNotification(nId) {
            var promise = $http.post('/Data/RemoveNotification', { "nId": nId });
            return promise;
        }

        function userHasAccess(userId, totalId) {
            return $http.get('/Data/UserHasAccess', { params: { "userId": userId, "totalId": totalId } });
        }

        function postResult(results) {
            console.log(results);
            $http.post('/Data/PostResult', { "results": results });
        }
    }
})(angular);