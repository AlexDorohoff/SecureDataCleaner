using System;

namespace SecureDataLib
{
    public class ResultCreater
    {
        public static HttpResult CreateHttpResult(HttpResult httpResult) {

            httpResult = EriseUserName(httpResult);

            httpResult = ErisePassword(httpResult);

            return httpResult;
        }

        public static HttpResult ErisePassword(HttpResult httpResult) {
            if (!String.IsNullOrEmpty(httpResult.Url))
            {
                httpResult.Url = SearchAndErisePass(httpResult.Url);
            }
            if (!String.IsNullOrEmpty(httpResult.RequestBody))
            {
                httpResult.RequestBody = SearchAndErisePass(httpResult.RequestBody);
            }
            if (!String.IsNullOrEmpty(httpResult.ResponseBody))
            {
                httpResult.ResponseBody = SearchAndErisePass(httpResult.ResponseBody);
            }
            return httpResult;
        }

        private static string SearchAndErisePass(string passSting) {
            if (passSting.Contains("pass"))
            {
                int passStart = passSting.IndexOf("pass");

                string lastString = passSting;
                int conuntLaststring = passSting.Length;
                int i = passStart + 5;
                while (i < conuntLaststring)
                {
                    lastString = lastString.Remove(i, 1);
                    lastString = lastString.Insert(i, "X");
                    i++;
                };
                return lastString;
            }
            return passSting;
        }

        public static HttpResult EriseUserName(HttpResult httpResult) {
            if (!String.IsNullOrEmpty(httpResult.Url))
            {
                httpResult.Url = SearchAndEriseUserName(httpResult.Url);
            }
            if (!String.IsNullOrEmpty(httpResult.RequestBody))
            {
                httpResult.RequestBody = SearchAndEriseUserName(httpResult.RequestBody);
            }
            if (!String.IsNullOrEmpty(httpResult.ResponseBody))
            {
                httpResult.ResponseBody = SearchAndEriseUserName(httpResult.ResponseBody);
            }
            return httpResult;
        }

        private static string SearchAndEriseUserName(string userString) {
            if (userString.Contains("?user="))
            {
                int i = userString.IndexOf("=")+1;
                while (i < userString.Length) {
                    if (userString[i].Equals('&'))
                    {
                        break;
                    }
                    userString = userString.Remove(i, 1);
                    userString =userString.Insert(i, "X");
                    i++;
                }
                return userString;
            }
            if (userString.Contains("/users/"))
            {
                int userStart = userString.IndexOf("/users/");
                int conuntLaststring = userString.Length;
                int i = userStart + 7;
                while (i < conuntLaststring)
                {
                    if (userString[i].Equals('/'))
                    {
                        break;
                    }
                    userString = userString.Remove(i, 1);
                    userString = userString.Insert(i, "X");
                    i++;
                };
                return userString;
            }
            return userString;
        }
    }
}
