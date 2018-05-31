using Model_Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Models.Comparer
{
 
    public class Document_SortByTypeByAscendingOrder : IComparer<IDocument>
    {
        public int Compare(IDocument x, IDocument y)
        {
            if (x.DocTypeID > y.DocTypeID) return 1;
            else if (x.DocTypeID < y.DocTypeID) return -1;
            else return 0;
        }
    }

    public class Document_SortByDateByDescendingOrder : IComparer<IDocument>
    {
        public int Compare(IDocument x, IDocument y)
        {
            if (x.ValidFromDate < y.ValidFromDate) return 1;
            else if (x.ValidFromDate > y.ValidFromDate) return -1;
            else return 0;
        }

    }

    public class Document_SortByName : IComparer<IDocument>
    {
        public int Compare(IDocument x, IDocument y)
        {
            return string.Compare(x.DocTitle, y.DocTitle);
        }
    }
}
