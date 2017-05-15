using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Entity.MatchLayer;
using TotalizatorWebApp.Database.Entity.UserLayer;
using TotalizatorWebApp.Database.Models.API;

namespace UnitTestProject
{
    public class DataStorage
    {
        public static List<FixtureView> fixtures
        {
            get
            {
                return new List<FixtureView>()
                {
                    new FixtureView() { homeTeamName = "AFC Bournemouth", awayTeamName = "Middlesbrough FC",
                                        date = new DateTime(2017, 4, 22, 17, 00, 00), matchday= 34,
                                        result = new ResultView() {goalsHomeTeam = 2, goalsAwayTeam = 1 } },
                    new FixtureView() { homeTeamName = "Hull City FC", awayTeamName = "Watford FC",
                                        date = new DateTime(2017, 4, 22, 17, 00, 00), matchday= 34,
                                        result = new ResultView() {goalsHomeTeam = 5, goalsAwayTeam = 0 } },
                    new FixtureView() { homeTeamName = "Swansea City FC", awayTeamName = "Stoke City FC",
                                        date = new DateTime(2017, 4, 22, 17, 00, 00), matchday= 34,
                                        result = new ResultView() {goalsHomeTeam = 2, goalsAwayTeam = 2 } },
                    new FixtureView() { homeTeamName = "West Ham United FC", awayTeamName = "Everton FC",
                                        date = new DateTime(2017, 4, 22, 17, 00, 00), matchday= 34,
                                        result = new ResultView() {goalsHomeTeam = 1, goalsAwayTeam = 3 } },
                    new FixtureView() { homeTeamName = "Burnley FC", awayTeamName = "Manchester United FC",
                                        date = new DateTime(2017, 4, 23, 16, 15, 00), matchday= 34,
                                        result = new ResultView() {goalsHomeTeam = 0, goalsAwayTeam = 0 } }

                };
            }
        }

        public static List<User> users
        {
            get
            {
                return new List<User>()
                {
                    new User() {UserId = 1,Login="tMosby",FullName="Ted Mosby",Points=77 },
                    new User() {UserId = 2,Login="bStinson",FullName="Barney Stinson",Points=97 },
                    new User() {UserId = 3, Login="user1", FullName= "user1Name" , Points = 75 },
                    new User() {UserId = 4, Login = "user2" , FullName = "user2Name", Points = 80},
                    new User() {UserId = 5, Login = "user3", FullName= "user3Name", Points = 71}
                };
            }
        }

        public static List<League> league
        {
            get
            {
                return new List<League>()
                {
                    new League() {LeagueId=1, Name = "Premier League" }
                };
            }
        }

        public static List<Stage> stages
        {
            get
            {
                return new List<Stage>()
                {
                    new Stage() {StageId =1, Name= "Round", MatchDay=34 ,LeagueId =1, League = league[0]},
                    new Stage() {StageId = 2, Name ="Round", MatchDay = 38, LeagueId = 1, League = league[0] },
                    new Stage() {StageId = 3, Name ="Round", MatchDay = 30, LeagueId = 1, League = league[0] }

                };
            }
        }

        public static List<Match> matches
        {
            get
            {
                return new List<Match>()
                {
                    new Match() {MatchId= 1, HomeTeam = teams[0], GuestTeam = teams[1], Stage = stages[0] ,StageId=1},
                    new Match() {MatchId= 2, HomeTeam = teams[2], GuestTeam = teams[3], Stage = stages[0] ,StageId=1},
                    new Match() {MatchId= 3, HomeTeam = teams[4], GuestTeam = teams[5], Stage = stages[0] ,StageId=1},
                    new Match() {MatchId= 4, HomeTeam = teams[6], GuestTeam = teams[7], Stage = stages[0] ,StageId=1},
                    new Match() {MatchId= 5, HomeTeam = teams[8], GuestTeam = teams[9], Stage = stages[0] ,StageId=1},

                    new Match() {MatchId= 6, HomeTeam = teams[1], GuestTeam = teams[9], Stage = stages[1] ,StageId=2},
                    new Match() {MatchId= 7, HomeTeam = teams[8], GuestTeam = teams[3], Stage = stages[1] ,StageId=2},
                    new Match() {MatchId= 8, HomeTeam = teams[5], GuestTeam = teams[4], Stage = stages[2] ,StageId=3},
                    new Match() {MatchId= 9, HomeTeam = teams[2], GuestTeam = teams[6], Stage = stages[2] ,StageId=3}

                };
             }
        }

        public static List<Team> teams
        {
            get
            {
                return new List<Team>()
                {
                    new Team() {TeamId=1 ,Name = "AFC Bournemouth"},new Team() {TeamId=2, Name = "Middlesbrough FC"},
                    new Team() {TeamId=3, Name = "Hull City FC"},new Team() {TeamId=4, Name = "Watford FC"},
                    new Team() {TeamId=5, Name = "Swansea City FC"},new Team() {TeamId=6, Name = "Stoke City FC"},
                    new Team() {TeamId=7, Name = "West Ham United FC"},new Team() {TeamId=8, Name = "Everton FC"},
                    new Team() {TeamId=9, Name = "Burnley FC"},new Team() {TeamId=10, Name = "Manchester United FC"}
                };
            }
        }

        public static List<PointsAnalysis> pointsAnalysis
        {
            get
            {
                return new List<PointsAnalysis>()
                {
                    new PointsAnalysis() { Full = 50, GoalDif = 30, JustWinner = 10 },
                    new PointsAnalysis() { Full = 90, GoalDif = 50, JustWinner = 20 },
                    new PointsAnalysis() { Full = 50, GoalDif = 20, JustWinner = 10 },
                    new PointsAnalysis() { Full = 100, GoalDif = 15, JustWinner = 5 },
                    new PointsAnalysis() { Full = 58, GoalDif = 30, JustWinner = 5 },
                    new PointsAnalysis() { Full = 41, GoalDif = 22, JustWinner = 10 }
                };
            }
        }

        public static List<Totalizator> totalizators
        {
            get
            {
                return new List<Totalizator>()
                {
                    new Totalizator() { TotalizatorId = 1, Name = "total1", OrganaizerId=1, Organaizer = users[0], StageId = 1, Stage = stages[0],
                                        isPublic = true, Validity=new DateTime(2017, 4, 22, 17, 00, 00), PointsAnalysis = pointsAnalysis[0] },

                    new Totalizator() { TotalizatorId = 2, Name = "total2", OrganaizerId=2, Organaizer = users[1], StageId = 1, Stage = stages[0],
                                        isPublic = false, Validity=new DateTime(2017, 4, 22, 17, 00, 00), PointsAnalysis = pointsAnalysis[5] },

                    new Totalizator() { TotalizatorId = 3, Name = "total3", OrganaizerId=3, Organaizer = users[2], StageId = 2, Stage = stages[1],
                                        isPublic = true, Validity=new DateTime(2017, 5, 22, 17, 00, 00), PointsAnalysis = pointsAnalysis[4] },

                    new Totalizator() { TotalizatorId = 4, Name = "total4", OrganaizerId=4, Organaizer = users[3], StageId = 3, Stage = stages[2],
                                        isPublic = false, Validity=new DateTime(2017, 3, 20, 17, 00, 00), PointsAnalysis = pointsAnalysis[3] },

                    new Totalizator() { TotalizatorId = 5, Name = "total5", OrganaizerId=5, Organaizer = users[4], StageId = 3, Stage = stages[2],
                                        isPublic = true, Validity=new DateTime(2017, 3, 20, 17, 00, 00), PointsAnalysis = pointsAnalysis[2] },

                    new Totalizator() { TotalizatorId = 6, Name = "total6", OrganaizerId=3, Organaizer = users[2], StageId = 2, Stage = stages[1],
                                        isPublic = false, Validity=new DateTime(2017, 5, 22, 17, 00, 00), PointsAnalysis = pointsAnalysis[1] },
                };
            }
        }

        public static List<TotalizatorManager> tManagers
        {
            get
            {
                return new List<TotalizatorManager>()
                {
                    new TotalizatorManager() {TotalizatorManagerId = 1, TotalizatorId = 2, UserId = 2 , User = users[1] , UserAccess = true },
                    new TotalizatorManager() {TotalizatorManagerId = 2, TotalizatorId = 2, UserId = 1 , User = users[0] , UserAccess = true },
                    new TotalizatorManager() {TotalizatorManagerId = 3, TotalizatorId = 2, UserId = 3 , User = users[2] , UserAccess = false },
                    new TotalizatorManager() {TotalizatorManagerId = 4, TotalizatorId = 3, UserId = 3 , User = users[2] , UserAccess = true },
                    new TotalizatorManager() {TotalizatorManagerId = 5, TotalizatorId = 3, UserId = 1 , User = users[0] , UserAccess = false },
                    new TotalizatorManager() {TotalizatorManagerId = 6, TotalizatorId = 6, UserId = 4 , User = users[3] , UserAccess = true },
                    new TotalizatorManager() {TotalizatorManagerId = 7, TotalizatorId = 6, UserId = 5 , User = users[4] , UserAccess = true }
                };
            }
        }



        public static List<Forecast> forecasts1
        {
            get
            {
                return new List<Forecast>()
                {
                    new Forecast() {ForecastId = 1, Match = matches[0],HomeTeamGoals =2, GuestTeamGoals = 1, TotalizatorManagerId = 1},
                    new Forecast() {ForecastId = 2, Match = matches[1],HomeTeamGoals =0, GuestTeamGoals = 5, TotalizatorManagerId = 1},
                    new Forecast() {ForecastId = 3, Match = matches[2],HomeTeamGoals =0, GuestTeamGoals = 0, TotalizatorManagerId = 1},
                    new Forecast() {ForecastId = 4, Match = matches[3],HomeTeamGoals =0, GuestTeamGoals = 2, TotalizatorManagerId = 1},
                    new Forecast() {ForecastId = 5, Match = matches[4],HomeTeamGoals =2, GuestTeamGoals = 1, TotalizatorManagerId = 1},
                };
            }
        }

        public static List<Forecast> forecasts2
        {
            get
            {
                return new List<Forecast>()
                {
                    new Forecast() {ForecastId = 1,Match = matches[0],HomeTeamGoals =3, GuestTeamGoals = 1 },
                    new Forecast() {ForecastId = 2,Match = matches[1],HomeTeamGoals =5, GuestTeamGoals = 4 },
                    new Forecast() {ForecastId = 3,Match = matches[2],HomeTeamGoals =2, GuestTeamGoals = 0 },
                    new Forecast() {ForecastId = 4,Match = matches[3],HomeTeamGoals =3, GuestTeamGoals = 3 },
                    new Forecast() {ForecastId = 5,Match = matches[4],HomeTeamGoals =0, GuestTeamGoals = 0 }
                };
            }
        }

        public static List<Forecast> forecasts3
        {
            get
            {
                return new List<Forecast>()
                {
                    new Forecast() { ForecastId = 1, Match = matches[5],HomeTeamGoals = 2, GuestTeamGoals = 1, TotalizatorManagerId = 1},
                    new Forecast() { ForecastId = 2, Match = matches[7],HomeTeamGoals = 2, GuestTeamGoals = 1, TotalizatorManagerId = 2},
                    new Forecast() { ForecastId = 3, Match = matches[8],HomeTeamGoals = 2, GuestTeamGoals = 1, TotalizatorManagerId = 2},
                    new Forecast() { ForecastId = 4, Match = matches[6],HomeTeamGoals = 2, GuestTeamGoals = 1, TotalizatorManagerId = 4}
                };
            }
        }

    }
}
