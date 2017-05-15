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
        public static List<FixtureView> fixtures = new List<FixtureView>()
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
                                result = new ResultView() {goalsHomeTeam = 0, goalsAwayTeam = 0 } },
        };

        private static List<User> users = new List<User>()
        {
            new User() {UserId = 1,Login="tMosby",FullName="Ted Mosby",Points=77 },
            new User() {UserId = 2,Login="bStinson",FullName="Barney Stinson",Points=97 },
            new User() {UserId = 3, Login="user1", FullName= "user1Name" , Points = 75 },
            new User() {UserId = 4, Login = "user2" , FullName = "user2Name", Points = 80},
            new User() {UserId = 5, Login = "user3", FullName= "user3Name", Points = 71}
        };

        private static List<League> league = new List<League>()
        {
            new League() {LeagueId=1, Name = "Premier League" }
        };

        private static List<Stage> stages = new List<Stage>()
        {
            new Stage() {StageId =1, Name= "Round", MatchDay=34 ,LeagueId =1}
        };

        private static List<Match> matches = new List<Match>()
        {
            new Match() {HomeTeam = teams[0], GuestTeam = teams[1], Stage = stages[0] ,StageId=1},
            new Match() {HomeTeam = teams[2], GuestTeam = teams[3], Stage = stages[0] ,StageId=1},
            new Match() {HomeTeam = teams[4], GuestTeam = teams[5], Stage = stages[0] ,StageId=1},
            new Match() {HomeTeam = teams[6], GuestTeam = teams[7], Stage = stages[0] ,StageId=1},
            new Match() {HomeTeam = teams[8], GuestTeam = teams[9], Stage = stages[0] ,StageId=1}

        };

        private static List<Team> teams = new List<Team>()
        {
            new Team() {TeamId=1 ,Name = "AFC Bournemouth"},new Team() {TeamId=2, Name = "Middlesbrough FC"},
            new Team() {TeamId=3, Name = "Hull City FC"},new Team() {TeamId=4, Name = "Watford FC"},
            new Team() {TeamId=5, Name = "Swansea City FC"},new Team() {TeamId=6, Name = "Stoke City FC"},
            new Team() {TeamId=7, Name = "West Ham United FC"},new Team() {TeamId=8, Name = "Everton FC"},
            new Team() {TeamId=9, Name = "Burnley FC"},new Team() {TeamId=10, Name = "Manchester United FC"}
        };

        public static List<PointsAnalysis> pointsAnalysis = new List<PointsAnalysis>()
        {
            new PointsAnalysis() { Full = 50, GoalDif = 30, JustWinner = 10 },
            new PointsAnalysis() { Full = 90, GoalDif = 50, JustWinner = 20 },
            new PointsAnalysis() { Full = 50, GoalDif = 20, JustWinner = 10 },
            new PointsAnalysis() { Full = 100, GoalDif = 15, JustWinner = 5 },
            new PointsAnalysis() { Full = 58, GoalDif = 30, JustWinner = 5 },
            new PointsAnalysis() { Full = 41, GoalDif = 22, JustWinner = 10 }
        };

        //toDo: create different stages(test date validity)
        private static List<Totalizator> totalizators = new List<Totalizator>()
        {
            new Totalizator() { TotalizatorId = 1, Name = "total1", OrganaizerId=1, Organaizer = users[0], StageId = 1, Stage = stages[0],
                                isPublic = true, Validity=new DateTime(2017, 4, 22, 17, 00, 00), PointsAnalysis = pointsAnalysis[0] },
            new Totalizator() { TotalizatorId = 2, Name = "total2", OrganaizerId=2, Organaizer = users[1], StageId = 1, Stage = stages[0],
                                isPublic = false, Validity=new DateTime(2017, 4, 22, 17, 00, 00), PointsAnalysis = pointsAnalysis[5] },
            new Totalizator() { TotalizatorId = 3, Name = "total3", OrganaizerId=3, Organaizer = users[2], StageId = 1, Stage = stages[0],
                                isPublic = true, Validity=new DateTime(2017, 4, 22, 17, 00, 00), PointsAnalysis = pointsAnalysis[4] },
            new Totalizator() { TotalizatorId = 4, Name = "total4", OrganaizerId=4, Organaizer = users[3], StageId = 1, Stage = stages[0],
                                isPublic = false, Validity=new DateTime(2017, 4, 22, 17, 00, 00), PointsAnalysis = pointsAnalysis[3] },
            new Totalizator() { TotalizatorId = 5, Name = "total5", OrganaizerId=5, Organaizer = users[4], StageId = 1, Stage = stages[0],
                                isPublic = true, Validity=new DateTime(2017, 4, 22, 17, 00, 00), PointsAnalysis = pointsAnalysis[2] },
            new Totalizator() { TotalizatorId = 6, Name = "total6", OrganaizerId=3, Organaizer = users[2], StageId = 1, Stage = stages[0],
                                isPublic = false, Validity=new DateTime(2017, 4, 22, 17, 00, 00), PointsAnalysis = pointsAnalysis[1] },
        };

        private static List<TotalizatorManager> tManagers = new List<TotalizatorManager>()
        {
            new TotalizatorManager() {TotalizatorManagerId = 1, TotalizatorId = 1, UserId = 2 , User = users[1] , UserAccess = true }
        };



        public static List<Forecast> forecasts1 = new List<Forecast>()
        {
            new Forecast() {Match = matches[0],HomeTeamGoals =2, GuestTeamGoals = 1 },
            new Forecast() {Match = matches[1],HomeTeamGoals =0, GuestTeamGoals = 5 },
            new Forecast() {Match = matches[2],HomeTeamGoals =0, GuestTeamGoals = 0 },
            new Forecast() {Match = matches[3],HomeTeamGoals =0, GuestTeamGoals = 2 },
            new Forecast() {Match = matches[4],HomeTeamGoals =2, GuestTeamGoals = 1 }
        };

        public static List<Forecast> forecasts2 = new List<Forecast>()
        {
            new Forecast() {Match = matches[0],HomeTeamGoals =3, GuestTeamGoals = 1 },
            new Forecast() {Match = matches[1],HomeTeamGoals =5, GuestTeamGoals = 4 },
            new Forecast() {Match = matches[2],HomeTeamGoals =2, GuestTeamGoals = 0 },
            new Forecast() {Match = matches[3],HomeTeamGoals =3, GuestTeamGoals = 3 },
            new Forecast() {Match = matches[4],HomeTeamGoals =0, GuestTeamGoals = 0 }
        };


    }
}
