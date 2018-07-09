using Model_Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Models.Comparer
{
 
    public class Document_SortByTypeByAscendingOrder : IComparer<IDocument>
    {
        public int Compare(IDocument first, IDocument second)
        {
            if (first.DocTypeID > second.DocTypeID) return 1;
            else if (first.DocTypeID < second.DocTypeID) return -1;
            else return 0;
        }
    }
    public class Document_SortByDateByDescendingOrder : IComparer<IDocument>
    {
        public int Compare(IDocument first, IDocument second)
        {
            if (first.ValidFromDate < second.ValidFromDate) return 1;
            else if (first.ValidFromDate > second.ValidFromDate) return -1;
            else return 0;
        }
    }
    public class Document_SortByName : IComparer<IDocument>
    {
        public int Compare(IDocument first, IDocument second)
        {
            return string.Compare(first.DocTitle, second.DocTitle);
        }
    }
}
