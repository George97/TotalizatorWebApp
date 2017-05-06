using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Abstraction.Repositories;
using TotalizatorWebApp.Database.Entity.MatchLayer;
using TotalizatorWebApp.DAL.Concrete.Repositories;

namespace UnitTestProject
{
    [TestClass]
    class MatchUnitTest
    {
        [TestMethod]
        public void GetLeague()
        {
            Mock<IMatchRepository> mockMatchRepositories = new Mock<IMatchRepository>();
            mockMatchRepositories.Setup(m => m.GetLeague(It.Is<int>(x => x > 0))).Returns<League>(l => l);

            //Arange
            MatchRepository repo = new MatchRepository()
        }
    }
}
