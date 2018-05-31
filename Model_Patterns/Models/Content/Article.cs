﻿using Model_Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Models.Content
{
    public class Article : Abstract.Content, IDocument
    {
        public List<Segment> Segments { get; set; }
        public List<Package> Packages { get; set; }
        public int DocHeaderID { get; set; }
        public int DocTypeID { get; set; }
        public DateTime ValidFromDate { get; set; }
        public string SOPI { get; set; }
        public string DocTitle { get; set; }

        protected override void createHeader()
        {
            //TODO: kreiraj zaglavlje dokumenta
        }

        protected override void createSegments()
        {
            //TODO: kreiraj segmente dokumenta
        }
    }
}
