using System;
using SecureDataLib;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Http;

namespace SecureDataCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintResult();
        }

        static readonly HttpClient client = new HttpClient();

        public static void PrintResult()
        {
        
            try
            {
            HttpResult httpResult = new HttpResult
            {
                Url = "http://test.com/users/max/info?pass=123456",
                RequestBody = "http://test.com?user=max&pass=123456",
                ResponseBody = "http://test.com?user=max&pass=123456",
            };
                httpResult = ResultCreater.CreateHttpResult(httpResult);
                Console.WriteLine(httpResult.Url);
                Console.WriteLine(httpResult.RequestBody);
                Console.WriteLine(httpResult.ResponseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            try
            {
                HttpResult httpResult = new HttpResult
                {
                    Url = "http://test.com/users/max/info?pass=123456"
                };
                httpResult = ResultCreater.CreateHttpResult(httpResult);
                Console.WriteLine(httpResult.Url);
                Console.WriteLine(httpResult.RequestBody);
                Console.WriteLine(httpResult.ResponseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }             
    }
}
