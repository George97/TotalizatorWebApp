(function (angular) {
    var appModule = angular
              .module("userModule")
              .controller("UserNgController", UserNgController)
    UserNgController.$inject = ['$scope', 'userService'];

    function UserNgController($scope, userService) {
        var app = this;
        app.leagues = [];
        app.currLeague = [];
        app.selectedLeague = [];

        Init();
        
        app.onChahgeCB = function(){
            console.log('onChahgeCB');
        }

        function Init() {
            userService.getLeagues().then(function (respond) {
                app.leagues = respond.data;
            });
        }
    }
})(angular);