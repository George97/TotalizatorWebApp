(function (angular) {
    var appModule = angular
              .module("userModule", ["kendo.directives", "jtt_footballdata"])
              .controller("UserNgController", UserNgController)
              .directive("stateButton", stateButton);

    UserNgController.$inject = ['$scope', 'userService', 'footballdataFactory'];

    appModule.filter("jsDate", function () {
        return function (x) {
            return new Date(parseInt(x.substr(6)));
        };
    });

    function UserNgController($scope, userService, footballdataFactory) {
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
            })
        }
        app.onTotalizator = function (t) {
            app.SelectedTotal = t;
            app.selectedTiD = t.TotalizatorId;
            userService.userHasAccess(app.currUser.UserId, t.TotalizatorId).then(function (respond) {
                console.log(respond.data);
                userService.setTManagerId(app.selectedTiD, app.currUser.UserId, respond.data);
                if (respond.data=="True") {
                    userService.getBlunkResults(t.StageId).then(function (response) {
                        app.matchResults = response.data;
                        app.showMatches = true;
                        app.selectedTiD = t.TotalizatorId;
                })
                }
                else {
                    app.msgShow = true;
                }
            })
        }
        app.onSend = function () {
            console.log(app.SelectedTotal);
            userService.senRequest(app.currUser.UserId, app.SelectedTotal.TotalizatorId, app.SelectedTotal.OrganaizerId).then(function (respond) {
                app.msgShow = false;
            })
        }

        app.onForecast = function () {
            userService.setForecast(app.matchResults, app.selectedTiD, app.currUser.UserId)
                .then(function (respond) {
                    location.href = '/User/MakeForecast';
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

        app.onAccept= function(notificationId,totalId,userId){
            userService.acceptUser(userId, totalId).then(function (respond) {
                userService.removeNotification(notificationId).then(function (respond) {
                    location.href = '/User/Index';
                })
            })
        }

        app.onReject = function (notificationId, totalId, userId) {
            userService.rejectUser(userId, totalId).then(function (respond) {
                userService.removeNotification(notificationId).then(function (respond) {
                    location.href = '/User/Index';
                })
            })
        }

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
                console.log(app.allTotal);
            })

            userService.getLeagues().then(function (respond) {
                app.leagues = respond.data;
            })

            userService.getStages(app.currLeagueId).then(function (respond) {
                app.currStages = respond.data;
            })

            userService.getBlankPA().then(function (respond) {
                app.tPoints = respond.data;
            })

            userService.getAllUsers().then(function (respond) {
                app.users = respond.data;
            })
        }

        $scope.onUserAdd = function (s) {
            console.log(app.addedUsersId);
            app.addedUsersId.push(s.UserId);
            console.log('onUserAdd', s);
            console.lof(addedUsersId);
        }

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