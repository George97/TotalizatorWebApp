using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Concrete.Repositories;
using TotalizatorWebApp.Database.Entity.BusinessLayer;

namespace UnitTestProject
{
    [TestClass]
    public class TotalizatorValidDateTest
    {
        [TestMethod]
        public void ValidTotalizatorsTest()
        {
            //Arange
            TotalizatorRepository totalRepository = new TotalizatorRepository(null);

            DateTime date = DateTime.Now;
            int userId = 1;

            List<Totalizator> expectedTotal = new List<Totalizator>() { DataStorage.totalizators[5] };

            //Act
            List<Totalizator> resTotal = totalRepository.getValidForUser(userId, date, DataStorage.totalizators, DataStorage.tManagers, DataStorage.forecasts3);

            //Assert
            CollectionAssert.AreEqual(expectedTotal, resTotal);
        }
    }
}
