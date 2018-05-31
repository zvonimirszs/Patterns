using Model_Patterns;
using Model_Patterns.Interfaces;
using Patterns.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patterns.Models
{
    public class User : Model_Patterns.Models.User
    {
        public override bool IsValid(string _username, string _password)
        {
            // TODO: provjeriti da li su akreditacije OK i nadopuniti model
            DataProvider data = new DataProvider();
            IUser user =  data.UserAutorization(_username,_password);
            HttpContext.Current.Session["User"] = user;
            if (user != null)
                return true;
            else
                return false;

        }

    }
}