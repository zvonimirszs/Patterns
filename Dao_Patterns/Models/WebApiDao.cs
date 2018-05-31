using Model_Patterns.Interfaces;
using Model_Patterns.Models;
using Model_Patterns.Models.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dao_Patterns.DaoModels
{
    public class WebApiDao : IDao
    {
        public IDocument GetTestDocument()
        {
            return new CaseLaw();
        }

        public User GetUserForLogin()
        {
            throw new NotImplementedException();
        }
    }
}
