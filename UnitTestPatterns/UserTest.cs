using System;
using msunit = Microsoft.VisualStudio.TestTools.UnitTesting;
using nunit = NUnit.Framework;
using Patterns.Models;
using Model_Patterns;
using System.Collections.Generic;
using Model_Patterns.Models;

namespace UnitTestPatterns
{
    [msunit.TestClass]
    public class UserTest
    {
        [msunit.TestMethod]
        public void korisnik_aktivan()
        {
            msunit.Assert.AreEqual(true, Utilities.IsUserEnabled(1));
        }

        [nunit.TestCase(1, 2500, false)]
        [nunit.TestCase(0,0, false)]
        [nunit.TestCase(2650, 2500, true)]
        [nunit.TestCase(400, -1, false)]
        public void korisnik_prekoracio_broj_dokumenata(int currentNumberOfDocuments, int maxNumberOfDocuments, bool result)
        {
            nunit.Assert.AreEqual(result, Utilities.IsUserOverUsedByDocuments(currentNumberOfDocuments, maxNumberOfDocuments));
        }

        [nunit.TestCase(1, 2500, false)]
        [nunit.TestCase(0, 0, true)]
        [nunit.TestCase(2650, 2500, true)]
        [nunit.TestCase(400, -1, false)]
        public void korisnik_prekoracio_broj_bodova(int currentNumberOfPoints, int maxNumberOfPoints, bool result)
        {
            nunit.Assert.AreEqual(result, Utilities.IsUserOverUsedByPoints(currentNumberOfPoints, maxNumberOfPoints));
        }

        [nunit.TestCase(null, "89.164.228.154", false)]
        [nunit.TestCase("89.164.228.154", "89.164.228.154", false)]
        [nunit.TestCase("89.164.228.150", "89.164.228.154", true)]
        [nunit.TestCase("", "89.164.228.154", false)]
        [nunit.TestCase("172.1.1219", "89.164.228.154", true)]
        public void korisnik_restrikcija_po_ip_adresi(string userIpAddress, string locationIpAddress, bool result)
        {
            nunit.Assert.AreEqual(result, Utilities.IsUserIpRestricted(userIpAddress, locationIpAddress));
        }

        static object[] PackageCases =
        {
            new object[] {
                new List<Package>(){
                    new Package { Id = 101, Name = "" },
                    new Package { Id = 106, Name = "" },
                    new Package { Id = 109, Name = "" },
                },
                new List<Package>(){
                    new Package { Id = 101, Name = "" },
                    new Package { Id = 110, Name = "" },
                },
                true
            },
            new object[] {
                new List<Package>(){
                    new Package { Id = 101, Name = "" },
                    new Package { Id = 109, Name = "" },
                },
                new List<Package>(){
                    new Package { Id = 106, Name = "" },
                },
                false
            }
        };

        [nunit.Test, nunit.TestCaseSource("PackageCases")]
        public void korisnik_u_paketu_kao_i_dokument(List<Package> userPackages, List<Package> documentPackages, bool result)
        {
            nunit.Assert.AreEqual(result, Utilities.IsUserInPackage(userPackages, documentPackages));
        }
    }
}
