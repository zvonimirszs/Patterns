using Model_Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Abstract
{
    public abstract class Content
    {
        protected IDocument doc;
        public void Create()
        {
            createHeader();
            createSegments();
            insert();
        }

        protected abstract void createHeader();

        protected abstract void createSegments();

        private void insert()
        {
            //TODO: insert into storage
            string title = doc.DocTitle;
        }
    }
}
