using Model_Patterns.Models;
using Model_Patterns.Models.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Interfaces
{
    public interface IDocument
    {

        int DocHeaderID { get; set; }
        int DocTypeID { get; set; }
        DateTime ValidFromDate { get; set; }
        string SOPI { get; set; }
        string DocTitle { get; set; }
        List<Segment> Segments { get; set; }
        List<Package> Packages { get; set; }

        //  [DocHeaderID]
        //,[DocStatusID]
        //,[DocTypeID]
        //,[ValidFromDate]
        //,[DocSourceID]
        //,[RefNum]
        //,[ProcessedBy]
        //,[ProcessedDateTime]
        //,[ValidStartDate]
        //,[ValidEndDate]
        //,[DocID]
        //,[SOPI]
        //,[VersionNum]
        //,[DocTitle]
        //,[MinorVersionNum]
        //,[DocActive]
    }
}
