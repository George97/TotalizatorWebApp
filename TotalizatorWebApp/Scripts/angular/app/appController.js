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
        app.login = "";
        app.pass = "";

        app.onLog = function () {
            appService.userExist(app.login, app.pass);
                //if (respond.data < 0) {
                //    console.log("try again");
                //}
                //else {
                //    appService.loggedUserId = respond.data;
                //    console.log(appService.loggedUserId);
                //        console.log("Hello");
                //        //window.location.href = "/User/Index";

                //}
            //})
        }
    }
})(angular);
