(function (angular) {
    var appModule = angular
              .module("adminModule", ["kendo.directives", "jtt_footballdata"])
              .controller("AdminNgController", AdminNgController)
              .directive("stateButton", stateButton);

    AdminNgController.$inject = ['$scope', 'adminService', 'footballdataFactory'];

    appModule.filter("jsDate", function () {
        return function (x) {
            return new Date(parseInt(x.substr(6)));
        };
    });

    function AdminNgController($scope, adminService, footballdataFactory) {
        var app = this;
        var apiKey = 'fc4ac8dc49df48c491d4b35b973937d4';
        app.users = [];
        app.totalizators = [];
        app.leagues = [];
        app.stages = [];
        app.currLeagueId = 1;
        app.currStages = [];
        app.tStageId = 1;
        app.LeagueId = 1;
        app.MatchDay = 1;

        Init();

        app.onLeagueChange = function () {
            console.log('onLeagueChange');
            console.log(app.currLeagueId);
            adminService.getStages(app.currLeagueId)
               .then(function (respond) {
                   app.currStages = respond.data;
                   console.log(app.currStages);
               });
        }

        app.getUsers = function () {
            console.log('getUsers');
            return new kendo.data.DataSource({
                data: app.users,
                pageSize: 10
            });
        }

        $scope.getTotals = function () {
            return new kendo.data.DataSource({
                data: app.totalizators,
                pageSize: 10
            });
        }

        app.onLeagueChange = function () {
            console.log('onLeagueChange');
            console.log(app.currLeagueId);
            adminService.getStages(app.currLeagueId)
               .then(function (respond) {
                   app.currStages = respond.data;
               });
        }

        $scope.onUserBanned = function (user) {
            adminService.banUser(user.UserId);
        }
        //$scope.onPointsCalculate = function (total){
        //    adminService.totalCalculate(total.TotalizatorId);
        //}
        app.gridTotalOptions = {
            columns: [
                { field: "Name", title: "Name" },
                { field: "OrganaizerLogin", title: "OrganaizerLogin" },
                { field: "Access", title: "Access" },
                //{ template: '<button class="btn-info" ng-click="onPointsCalculate(dataItem)" state-button><span class="glyphicon glyphicon-plus"></span></button>' }
            ],
            sortable: true,
            pageable: true
        };
        app.gridUserOptions = {
            columns: [
                { field: "Login", title: "Login" },
                { field: "FullName", title: "FullName" },
                { field: "Points", title: "Points" },
                { template: '<button class="btn-info" ng-click="onUserBanned(dataItem)" state-button><span class="glyphicon glyphicon-plus"></span></button>' }
            ],
            sortable: true,
            pageable: true,
        };

        app.apiFunc = function () {
            console.log('apiFunc', app.LeagueId, app.MatchDay);
            footballdataFactory.getFixturesBySeason({
                //id: 426,
                id: app.LeagueId,
                matchday: app.MatchDay,
                //league: 'CL',
                apiKey: apiKey,
            }).then(function (_data) {
                console.log('++');
                console.info("getFixturesBySeason", _data);
                adminService.postResult(_data.data.fixtures)
            });
        }

        app.onResultInit = function () {
            console.log('onResultInit');
            console.log('app.tStageId');
            app.apiFunc();
        }

        function Init() {
            adminService.getAllUsers().then(function (respond) {
                app.users = respond.data;
            })

            adminService.getLeagues().then(function (respond) {
                app.leagues = respond.data;
            })

            adminService.getAllTotalizators().then(function (respond) {
                app.totalizators = respond.data;
                console.log(app.totalizators);
            })
        }
        $scope.leaguesDataSource = {
            transport: {
                read: function (e) {
                    // on success
                    console.log('productsDataSource');
                    adminService.getLeagues().then(function (respond) {
                        var leagues = respond.data;
                        console.log('productsDataSource', leagues);
                        e.success(leagues);
                    })
                }
            }
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