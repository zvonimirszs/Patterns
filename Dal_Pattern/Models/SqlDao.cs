using Dal_Pattern.Models;
using Model_Patterns.Abstract;
using Model_Patterns.Interfaces;
using Model_Patterns.Models;
using Model_Patterns.Models.Content;
using Model_Patterns.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Dal_Patterns.Models
{
    public class SqlDao : IDao
    {
        public Config Config { get; set; }

        //TODO: implementirati Repository
        public IDocument GetDocument(string Sopi)
        {
            try
            {
                string conn = Config.DictConfig["DbConn"];
                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Sopi", SqlDbType.VarChar, 256);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Sopi;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "GetDocument", spParameter);

                DataTable dtHeader = ds.Tables[0];
                DataTable dtSegment = ds.Tables[1];
                DataTable dtPackage = ds.Tables[2];
                List<Segment> segments = new List<Segment>();
                List<Package> packages = new List<Package>();

                IDocument doc = CreateDocument(dtHeader.Rows[0]);
                foreach (DataRow item in dtSegment.Rows)
                {
                    segments.Add(CreateSegment(item));
                }
                doc.Segments = segments;
                foreach (DataRow item in dtPackage.Rows)
                {
                    packages.Add(CreatePackage(item));
                }
                doc.Packages = packages;
                return doc;
            }
            catch (Exception e)
            {
                throw new DataProviderException("Error in GetDocument method", e);
            }

        }

        public List<IDocument> GetDocuments()
        {
            try
            {
                string conn = Config.DictConfig["DbConn"];
            
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "GetDocuments");
                List<IDocument> list = new List<IDocument>();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    list.Add(CreateDocument(item));
                }
                return list;
            }
            catch (Exception e)
            {
                throw new DataProviderException("Error in GetDocuments method", e);
            }
        }
        public IUser GetUserModelData(string username, string password)
        {
            try
            {
                string conn = Config.DictConfig["DbConn"];
                IUser user = null;
                SqlParameter[] spParameter = new SqlParameter[2];

                spParameter[0] = new SqlParameter("@username", SqlDbType.VarChar, 8);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = username;

                spParameter[1] = new SqlParameter("@password", SqlDbType.VarChar, 70);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = password;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure , "GetUserForLogin", spParameter);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    DataTable dtPackage = ds.Tables[1];
                    List<Package> packages = new List<Package>();


                    user = new User
                    {
                        UserName = ds.Tables[0].Rows[0]["UserName"].ToString(),
                        Password = ds.Tables[0].Rows[0]["Password"].ToString()
                    };

                    foreach (DataRow item in dtPackage.Rows)
                    {
                        packages.Add(CreatePackage(item));
                    }
                    user.Packages = packages;


                    return user;
                }
                else
                    return user;
            }
            catch (Exception e)
            {
                throw new DataProviderException("Error in GetUserModelData method", e);
            }

        }
        #region Private methods
        private IDocument CreateDocument(DataRow row)
        {
            int iType = Convert.ToInt32(row["DocTypeId"]);

            IDocument doc;

            switch (iType)
            {
                case 5000:// zakon
                    doc = new Law();
                    break;
                case 6200: // odluka
                    doc = new CaseLaw();
                    break;
                case 8000: // članak
                    doc = new Article();
                    break;
                default:
                    doc = new Law();
                    break;
            }
            
            doc.DocTitle = row["DocTitle"].ToString();
            doc.SOPI = row["SOPI"].ToString();
            doc.DocTypeID = iType;

            return doc;

        }
        private Segment CreateSegment(DataRow row)
        {
            Segment segment = new Segment
            {
                SegmentNum = row["SegmentNum"].ToString(),
                SegmentContent = row["SegmentContent"].ToString()
            };
            return segment;
        }
        private Package CreatePackage(DataRow row)
        {
            Package package = new Package
            {
                Id = Convert.ToInt32(row["PackageID"])
                //, Name = row["DocTypeID"].ToString()
            };
            return package;
        }
        #endregion

    }
}
