(function (angular) {
    var appModule = angular
              .module("userModule", ["kendo.directives"])
              .controller("UserNgController", UserNgController)
              .directive("stateButton", stateButton);

    UserNgController.$inject = ['$scope', 'userService'];

    appModule.filter("jsDate", function () {
        return function (x) {
            return new Date(parseInt(x.substr(6)));
        };
    });

    function UserNgController($scope, userService) {
        var app = this;
        app.currUser = {};
        //app.leagues = [];
        app.currLeague = [];
        app.currLeagueId = 1;
        app.currStages = [];
        app.tTitle = "";
        app.tStageId = 0;
        app.tPoints = [];
        app.tAccess = 'Public';
        app.users = [];
        app.totalizators = [];
        app.matchResults = [];
        app.selectedTiD = 0;
        app.showMatches = false;

        console.log('UserNgController');
        Init();
        
        app.onLeagueChange = function () {
            console.log('onLeagueChange');
            console.log(app.currLeagueId);
            userService.getStages(app.currLeagueId)
               .then(function (respond) {
                   app.currStages = respond.data;
               });
            
        }

        app.onAddTotalizator = function () {
            console.log('onAddTotalizator');
            console.log('Stage', app.tStageId);
            userService.createTotalizator(app.currUser.UserId, app.tTitle, app.tPoints, app.tStageId, app.isTPublic)
            .then(function(respond){
                //userService.getTotalizator(respond.data).then(function (respond) {
                //    console.log('onAddTotalizator    ', respond.data);
                //    app.totalizators.push(respond.data);
                //    console.log(app.totalizators);
                //    //location.href = '/User/Index';
                //})
            })
            //userService.addUser(1, 2);
        }
        app.onTotalizator = function (stageId,totalizatorId) {
            userService.getBlunkResults(stageId).then(function (response) {
                app.matchResults = response.data;
                app.showMatches = true;
                app.selectedTiD = totalizatorId;
            })
        }

        app.onForecast = function () {
            userService.setTManagerId(app.selectedTiD, app.currUser.UserId)
            .then(function (response) {
                userService.setForecast(app.matchResults, response.data);
            })
        }

        function Init() {
            console.log('init');
            
            userService.setCurrUser().then(function(respond) {
                app.currUser = respond.data;
                //console.log('user', app.currUser);
            })

            userService.getLeagues().then(function (respond) {
                app.leagues = respond.data;
            })

            userService.getBlankPA().then(function (respond) {
                app.tPoints = respond.data;
            })

            userService.getAllUsers().then(function (respond) {
                app.users = respond.data;
            })

            userService.getAllTotalizators().then(function (respond) {
                app.totalizators = respond.data;
                console.log(app.totalizators);
            })

            //userService.getNextTotalizatorId().then(function (respond) {
            //    app.currTotalizatorIndex = respond.data;
            //})
            

        }

        $scope.onUserAdd = function (s) {
            console.log(app.addedUsersId);
            app.addedUsersId.push(s.UserId);
            console.log('onUserAdd', s);
            console.lof(addedUsersId);
        }

        $scope.mainGridOptions = {
            dataSource: {
                transport: {
                    read: function (e) {
                        // on success
                        userService.getAllTotalizators().then(function (respond) {
                            var t = respond.data;
                            e.success(t);
                        })
                        // on failure
                        //e.error("XHR response", "status code", "error message");
                    }
                },
                pageSize: 5,
                serverPaging: true,
                serverSorting: true
            },
            //data: app.users,
            sortable: true,
            pageable: true,
            //dataBound: function () {
            //    this.expandRow(this.tbody.find("tr.k-master-row").first());
            //},
           
            columns: [{
                field: "Name",
                title: "Name",
                width: "120px"
            },{
                field: "isPublic",
                title: "isPublic",
                width: "240px"
            }
                //{ command: { text: "Add", click: app.onUserAdd(dataItem) }, title: " ", width: "180px" }
                //{ template: '<button class="btn-info" ng-click="onUserAdd(dataItem)" state-button><span class="glyphicon glyphicon-plus"></span></button>' }
            ]
        };
        $scope.leaguesDataSource = {
            transport: {
                read: function (e) {
                    // on success
                    console.log('productsDataSource');
                    userService.getLeagues().then(function (respond) {
                        var leagues = respond.data;
                        console.log('productsDataSource', leagues);
                        e.success(leagues);
                    })
                }
            }
           
        };
       
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