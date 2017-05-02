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
        app.userNotifications = [];
        //app.leagues = [];
        app.currLeague = [];
        app.currLeagueId = 1;
        app.currStages = [];
        app.tTitle = "";
        app.tStageId = 0;
        app.tPoints = [];
        app.tAccess = 'Public';
        app.users = [];
        app.validTotal = [];
        app.allTotal = [];
        app.matchResults = [];
        app.selectedTiD = 0;
        app.SelectedTotal = {};
        app.showMatches = false;
        app.msgShow = false;
        app.tCurrId = -1;

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
            .then(function (respond) {
                location.href = '/User/Index';
                //userService.getTotalizator(respond.data).then(function (respond) {
                //    console.log('onAddTotalizator    ', respond.data);
                //    app.totalizators.push(respond.data);
                //    console.log(app.totalizators);
                //    //location.href = '/User/Index';
                //})
            })
            //userService.addUser(1, 2);
        }
        app.onTotalizator = function (t) {
            app.SelectedTotal = t;
            console.log(t.isPublic);
            if (t.isPublic) {
                userService.getBlunkResults(t.StageId).then(function (response) {
                    app.matchResults = response.data;
                    app.showMatches = true;
                    app.selectedTiD = t.TotalizatorId;
                })
            }
            else {
                app.msgShow = true;
            }
        }
        app.onSend = function () {
            console.log(app.SelectedTotal);
            userService.senRequest(app.currUser.UserId, app.SelectedTotal.TotalizatorId, app.SelectedTotal.OrganaizerId).then(function (respond) {
                app.msgShow = false;
            })
        }

        app.onForecast = function () {
            userService.setTManagerId(app.selectedTiD, app.currUser.UserId)
            .then(function (response) {
                userService.setForecast(app.matchResults, response.data)
                app.showMatches = false;
            })
        }
        app.getUserOf = function (id) {
            console.log(id);
            if (id == undefined) { id = 1; }
            console.log(id);
            userService.getTotalUsers(id).then(function (respond) {
                console.log(respond.data);
                return respond.data;
            })
        }
        app.setUsers = function (users) {
            return new kendo.data.DataSource({
                data: users,
                pageSize: 5
            });
        }

        app.getUsers = function () {
            return new kendo.data.DataSource({
                data: app.users,
                pageSize: 10
            });
        }
        app.gridTotalOptions = {
            dataSource:{
                pageSize:4
            },
            columns: [
                { field: "Login", title: "Login" },
                { field: "FullName", title: "FullName" }
            ],
            sortable: true,
            pageable: true
        };
        app.gridUserOptions = {
            columns: [
                { field: "Login", title: "Login" },
                { field: "FullName", title: "FullName" },
                { field: "Points", title: "Points" }
            ],
            sortable: true,
            pageable: true,
        };

        function Init() {
            console.log('init');
            
            userService.setCurrUser().then(function(respond) {
                app.currUser = respond.data;
                console.log(respond.data.UserId);
                userService.getValidTotalizators(respond.data.UserId).then(function (respond) {
                    app.validTotal = respond.data;
                    console.log(app.validTotal);
                })
                userService.getUserNotifications(respond.data.UserId).then(function (respond) {
                    app.userNotifications = respond.data;
                })
            })

            userService.getAllTotalizators().then(function (respond) {
                app.allTotal = respond.data;
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