(function (angular) {
    var appModule = angular
              .module("userModule")
              .controller("UserNgController", UserNgController)
              .directive("stateButton", stateButton);

    UserNgController.$inject = ['$scope', 'userService'];

    function UserNgController($scope, userService) {
        var app = this;
        app.leagues = [];
        app.currLeague = [];
        app.currLeagueId = 1;
        app.currStages = [];
        app.currStage = [];
        app.currPoints = [];
        app.users = [];
        app.currTotalizatorIndex = 0;


        Init();
        
        app.onLeagueChange = function () {
            console.log('onLeagueChange');
            console.log(app.currLeagueId);
            userService.getStages(app.currLeagueId)
               .then(function (respond) {
                   app.currStages = respond.data;
               });
            
        }

        app.onPAChange = function () {
            console.log('you select ', app.currPoints);
        }

        app.onUserAdd = function (UserId) {
            console.log('onAdd', UserId);
        }

        function Init() {
            userService.getLeagues().then(function (respond) {
                app.leagues = respond.data;
            })

            userService.getBlankPA().then(function (respond) {
                app.currPoints = respond.data;
            })

            userService.getAllUsers().then(function (respond) {
                app.users = respond.data;
            })

            //userService.getNextTotalizatorId().then(function (respond) {
            //    app.currTotalizatorIndex = respond.data;
            //})
            

        }
    }

    function stateButton() {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                console.log('stateButton');
                element.on('click', function () {
                    console.log('btn click');
                    $(this).removeClass('btn-info').addClass('btn-success');
                    $(this).find('span').removeClass('glyphicon-plus').addClass('glyphicon-ok');
                    $(this).unbind("click");
                });
            }
        }
    }
})(angular);