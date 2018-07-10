using Model_Patterns;
using Model_Patterns.Interfaces;
using Patterns.App_Code;
using Patterns.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patterns.Models
{
    public class User : Model_Patterns.Models.User
    {
        [ExceptionHandlerAspect(AspectPriority = 1)]
        public override bool IsValid(string _username, string _password)
        {
            IUser user = GetUser(_username, _password);
            HttpContext.Current.Session["User"] = user;
            if (user != null)
                return true;
            else
                return false;
        }
        [ObjectNullArgumentAspect(AspectPriority = 0)]
        [ExceptionHandlerAspect(AspectPriority = 1)]
        public IUser GetUser(string _username, string _password)
        {
            DataProvider data = new DataProvider();
            return data.GetUserModelData(_username, _password);
        }

    }
}