using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Entity.MatchLayer;
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

        private static List<Team> teams = new List<Team>()
        {
            new Team() {Name = "AFC Bournemouth"},new Team() {Name = "Middlesbrough FC"},
            new Team() {Name = "Hull City FC"},new Team() {Name = "Watford FC"},
            new Team() {Name = "Swansea City FC"},new Team() {Name = "Stoke City FC"},
            new Team() {Name = "West Ham United FC"},new Team() {Name = "Everton FC"},
            new Team() {Name = "Burnley FC"},new Team() {Name = "Manchester United FC"}
        };

        private static List<Match> matches = new List<Match>()
        {
            new Match() {HomeTeam = teams[0], GuestTeam = teams[1], Stage = new Stage() {Name="Round", MatchDay=34 } },
            new Match() {HomeTeam = teams[2], GuestTeam = teams[3], Stage = new Stage() {Name="Round", MatchDay=34 } },
            new Match() {HomeTeam = teams[4], GuestTeam = teams[5], Stage = new Stage() {Name="Round", MatchDay=34 } },
            new Match() {HomeTeam = teams[6], GuestTeam = teams[7], Stage = new Stage() {Name="Round", MatchDay=34 } },
            new Match() {HomeTeam = teams[8], GuestTeam = teams[9], Stage = new Stage() {Name="Round", MatchDay=34 } }

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

        public static PointsAnalysis pointRules = new PointsAnalysis() { Full = 50, GoalDif = 30, JustWinner = 10 };


    }
}
