using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TotalizatorWebApp.DAL.Concrete.Repositories;
using TotalizatorWebApp.Database.Entity.BusinessLayer;


namespace UnitTestProject
{
    [TestClass]
    public class MatchResultTest
    {
        [TestMethod]
        public void pointCalculation()
        {
            //Arange
            MatchRepository matchRepository = new MatchRepository(null);

            List<Forecast> forecast1 = DataStorage.forecasts1;
            PointsAnalysis rules1 = new PointsAnalysis() { Full = 60, GoalDif = 30, JustWinner = 20 };
            double expSum1 = 24;

            List<Forecast> forecast2 = DataStorage.forecasts2;
            PointsAnalysis rules2 = new PointsAnalysis() { Full = 80, GoalDif = 20, JustWinner = 10 };
            double expSum2 = 20;

            //Act
            double sum1 = matchRepository.calculateUserPoints(forecast1, DataStorage.fixtures, rules1);
            double sum2 = matchRepository.calculateUserPoints(forecast2, DataStorage.fixtures, rules2);

            //Assert
            Assert.AreEqual(expSum1, sum1);
            Assert.AreEqual(expSum2, sum2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testException()
        {
            MatchRepository matchRepository = new MatchRepository(null);

            List<Forecast> forecast1 = DataStorage.forecasts1;
            PointsAnalysis rules1 = new PointsAnalysis() { Full = -60, GoalDif = 30, JustWinner = 20 };
            double expSum1 = 0;

            //Act
            double sum1 = matchRepository.calculateUserPoints(forecast1, DataStorage.fixtures, rules1);
            //double sum2 = matchRepository.calculateUserPoints(forecast3, DataStorage.fixtures, rules2);

            //Assert
            Assert.AreEqual(expSum1, sum1);
        }
    }
}
