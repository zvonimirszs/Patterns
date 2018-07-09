using Model_Patterns;
using Model_Patterns.Interfaces;
using Model_Patterns.Models.Comparer;
using Patterns.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patterns.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {

            DataProvider data = new DataProvider();
            List<IDocument> groupOfDocuments = data.GetDocuments();

            return View(groupOfDocuments);
        }

        public ActionResult Sort(int typeid)
        {
            //Pattern: Strategy
            DataProvider data = new DataProvider();
            List<IDocument> groupOfDocuments = data.GetDocuments();
            IComparer<IDocument> sort;
            switch (typeid)
            {
                case 1:// name
                    sort = new Document_SortByName();
                    break;
                case 2: // date
                    sort = new Document_SortByDateByDescendingOrder();
                    break;
                case 3: // type
                    sort = new Document_SortByTypeByAscendingOrder();
                    break;
                default:// name
                    sort = new Document_SortByName();
                    break;
            }
            groupOfDocuments.Sort(sort);
            return View("Index", groupOfDocuments);
        }
    }
}