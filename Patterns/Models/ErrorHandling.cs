using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Patterns.Models
{
    public class ErrorHandling
    {
        public static NameValueCollection GetPortalErrorData()
        {

            NameValueCollection nvcError = new NameValueCollection();
            try
            {
                nvcError.Add("BrowserType", HttpContext.Current.Request.Browser.Type);
                nvcError.Add("BrowserPlatform", HttpContext.Current.Request.Browser.Platform);
                nvcError.Add("BrowserBeta", HttpContext.Current.Request.Browser.Beta.ToString());
                nvcError.Add("BrowserCrawler", HttpContext.Current.Request.Browser.Crawler.ToString());
                nvcError.Add("BrowserWin16", HttpContext.Current.Request.Browser.Win16.ToString());
                nvcError.Add("BrowserWin32", HttpContext.Current.Request.Browser.Win32.ToString());
                nvcError.Add("BrowserFrames", HttpContext.Current.Request.Browser.Frames.ToString());
                nvcError.Add("BrowserTables", HttpContext.Current.Request.Browser.Tables.ToString());
                nvcError.Add("BrowserCookies", HttpContext.Current.Request.Browser.Cookies.ToString());
                nvcError.Add("BrowserVBScript", HttpContext.Current.Request.Browser.VBScript.ToString());
                nvcError.Add("BrowserEcmaScriptVersion", HttpContext.Current.Request.Browser.EcmaScriptVersion.ToString());
                nvcError.Add("BrowserJScriptVersion", HttpContext.Current.Request.Browser.JScriptVersion.ToString());
                nvcError.Add("BrowserJavaApplets", HttpContext.Current.Request.Browser.JavaApplets.ToString());
                nvcError.Add("BrowserCDF", HttpContext.Current.Request.Browser.CDF.ToString());
                nvcError.Add("BrowserActiveXControls", HttpContext.Current.Request.Browser.ActiveXControls.ToString());
                nvcError.Add("BrowserID", HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]);

                nvcError.Add("UserIP", HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
                nvcError.Add("UserHost", HttpContext.Current.Request.ServerVariables["REMOTE_HOST"]);
                nvcError.Add("UserName", HttpContext.Current.Request.ServerVariables["REMOTE_USER"]);
                nvcError.Add("ServerName", HttpContext.Current.Request.ServerVariables["SERVER_NAME"]);
                nvcError.Add("ServerName2", HttpContext.Current.Request.Url.Authority);
                nvcError.Add("ServerOS", HttpContext.Current.Request.ServerVariables["SERVER_SOFTWARE"]);
                nvcError.Add("Url", HttpContext.Current.Request.Url.AbsoluteUri);
                nvcError.Add("QueryString", HttpContext.Current.Request.ServerVariables["QUERY_STRING"]);
                nvcError.Add("Referer", HttpContext.Current.Request.ServerVariables["HTTP_REFERER"]);
                nvcError.Add("AuthUser", HttpContext.Current.Request.ServerVariables["AUTH_USER"]);
                nvcError.Add("LogonUser", HttpContext.Current.Request.ServerVariables["LOGON_USER"]);
                nvcError.Add("AuthType", HttpContext.Current.Request.ServerVariables["AUTH_TYPE"]);
                nvcError.Add("IISId", HttpContext.Current.Request.ServerVariables["INSTANCE_ID"]);
            }
            catch
            {
            }
            return nvcError;
        }
    }
}