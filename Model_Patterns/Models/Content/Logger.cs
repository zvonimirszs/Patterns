using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Models.Content
{
    public class Logger
    {
        public string DocumentKey { get; set; }
        public int PageId { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public override string ToString()
        {
            return String.Format("PageId: {0}. DocumentKey: {1}. Url: {2}. Date: {3}", PageId, DocumentKey, Url, Date.ToString());
        }
    }
}
