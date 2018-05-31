using Model_Patterns.Abstract;
using Model_Patterns.Models;
using Model_Patterns.Models.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Interfaces
{
    public interface IDao
    {
        Config Config { get; set; }
        #region Documents
        List<IDocument> GetDocuments();
        IDocument GetDocument(string Sopi);
        #endregion

        #region Users
        IUser UserAutorization(string username, string password);        
        #endregion
    }
}
