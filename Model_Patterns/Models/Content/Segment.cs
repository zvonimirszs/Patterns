using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Models.Content
{
    public class Segment
    {
        public int DocSegmentID { get; set; }
        public string SegmentNum { get; set; }
        public int DocID { get; set; }
        public string SegmentType { get; set; }
	    public string ProcessedBy { get; set; }
        public DateTime ProcessedDateTime { get; set; }
        public string Status { get; set; }
        public DateTime ValidStartDate { get; set; }
        public DateTime ValidEndDate { get; set; }
        public string SegmentContent { get; set; }
        public int CoInDocSegmentID { get; set; }
        public int DocHeaderID { get; set; }
        public int SegmentOrder { get; set; }
        public string SegmentRef { get; set; }
        public int PrivateSegmentID { get; set; }
        public bool SegmentActive { get; set; }
    }
}
