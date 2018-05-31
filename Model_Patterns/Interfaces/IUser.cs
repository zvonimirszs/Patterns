using Model_Patterns.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Interfaces
{
    public interface IUser
    {
        string UserName { get; set; }
        string Password { get; set; }
        bool RememberMe { get; set; }
        List<Package> Packages { get; set; }
        bool IsValid(string _username, string _password);
    }
}
