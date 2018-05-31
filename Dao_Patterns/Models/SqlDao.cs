using Model_Patterns.Interfaces;
using Model_Patterns.Models;
using Model_Patterns.Models.Content;
//using System.Data;
using System.Data.SqlClient;

namespace Dao_Patterns.DaoModels
{
    public class SqlDao : IDao
    {
        public IDocument GetTestDocument()
        {
            string conn = "server='RAZVOJLPT06\\SQL2016';database=Patterns;Pooling=true;Max Pool Size=200;Min Pool Size=1;Application Name=MailerService;Connect Timeout=220;Integrated Security=True";
            System.Data.
            SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(conn);
            DataSet ds = Models.SqlTest.ExecuteDataset(sqlConnection, System.Data.CommandType.StoredProcedure, "GetDocuments");

            return null;
        }

        public User GetUserForLogin()
        {
            string conn = "server='RAZVOJLPT06\\SQL2016';database=Patterns;Pooling=true;Max Pool Size=200;Min Pool Size=1;Application Name=MailerService;Connect Timeout=220;Integrated Security=True";

            SqlConnection sqlConnection = new SqlConnection(conn);
            DataSet ds = Models.SqlTest.ExecuteDataset(sqlConnection, System.Data.CommandType.StoredProcedure , "GetUserForLogin");
            
            return null;
        }
    }
}
