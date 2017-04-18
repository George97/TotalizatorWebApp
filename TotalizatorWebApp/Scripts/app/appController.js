(function (angular) {
    var appModule = angular
        .module("appModule")
        .controller("AppController", AppController)
        .directive("stateButton", stateButton);
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
        app.onAdd = function (MatchId) {
            appService.addTotalizator(MatchId).
                then(function (response) {
                    setSuccessState(MatchId);
                }, function (response) {
                    alert('Failed add totalizator operation!!');
                });
        }

        function setSuccessState(MatchId) {
            console.log('setSuccessState', $("#MatchId"));
            $("#MatchId").css("background-color", "green");
            console.log('setSuccessState', $("#MatchId"));
        }
    };

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
