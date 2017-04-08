(function (angular) {
    var appModule = angular
        .module("appModule")
        .controller("AppController", AppController);
    AppController.$inject = ['$scope','$filter', 'appService'];

    appModule.filter("jsDate", function () {
        return function (x) {
            return new Date(parseInt(x.substr(6)));
        };
    });

    function AppController($scope,$filter, appService) {
        var app = this;
        app.matches = [];
        app.Title = "";

        Init();
        function Init() {
            var appPromise = appService.getMatches();
            appPromise.then(function (response) {
                app.matches = response.data;
            })
        }
    };
})(angular);