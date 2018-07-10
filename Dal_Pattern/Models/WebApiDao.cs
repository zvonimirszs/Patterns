using Model_Patterns.Abstract;
using Model_Patterns.Interfaces;
using Model_Patterns.Models;
using Model_Patterns.Models.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal_Patterns.Models
{
    public class WebApiDao : IDao
    {
        public Config Config { get; set; }

        public IDocument GetDocument(string Sopi)
        {
            throw new NotImplementedException();
        }

        public List<IDocument> GetDocuments()
        {
            throw new NotImplementedException();
        }
        public IUser GetUserModelData(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
