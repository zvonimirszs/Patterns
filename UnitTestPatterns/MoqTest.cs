using System;
using Model_Patterns;
using Model_Patterns.Interfaces;
using Moq;
using NUnit.Framework;
using Patterns.App_Code;
using Patterns.Models;
using Patterns.Models.Cache;

namespace UnitTestPatterns
{
    [TestFixture]
    public class MoqTest
    {
        User user;

        [SetUp]
        public void setupTest()
        {
            user = Mock.Of<User>();

        }

        [Test]
        public void korisnik_dohvacanje_iznimka_ako_argument_null()
        {
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => user.GetUser(null,null));
        }
    }
}
