﻿using Model_Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model_Patterns.Models
{
    public class User : IUser
    {
        [Required]
        [Display(Name = "Korisničko ime")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }
        [Display(Name = "Zapamti moje podatke")]
        public bool RememberMe { get; set; }
        public List<Package> Packages { get; set; }

        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="_username">User name</param>
        /// <param name="_password">User password</param>
        /// <returns>True if user exist and password is correct</returns>
        public virtual bool IsValid(string _username, string _password)
        {

           return false;
        }
    }
}
