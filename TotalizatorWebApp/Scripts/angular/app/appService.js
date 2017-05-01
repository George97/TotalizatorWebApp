(function (angular) {
    angular
        .module('appModule')
        .factory('appService', appService);

    appService.$inject = ['$http'];

    function appService($http) {
        console.log('create appService');
        var services = {
            userExist: userExist
        }
        return services;

        function userExist(login,pass) {
            var promise = $http.post('/Home/UserExist', { params: { "login": login, "pass": pass } });
            return promise;
        }
    }
})(angular);