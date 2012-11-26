using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using FSharpKoans.Core;

namespace Koans
{
    /**
     * Lesson 1: About Basics
     * 
     * Unlike many koans programs, Web API requires a bit of setup
     * in order to start learning how to use it. Each of the concepts
     * below will be inspected in further detail as you progress.
     */

    [Koan(Sort = 1)]
    public static class AboutBasics
    {
        [Koan]
        public static void UsingHttpClientToGetResponse()
        {
            // Send a GET message. The Web API API is asynchronous.
            // You should avoid calling .Result, but for testing, this is okay.
            // What is the status code of the returned response?
            // Did you expect to get an error?
            using (var response = WebApiKoans.Client.GetAsync("http://go.com/").Result)
                Helpers.AssertEquality(Helpers.__, response.StatusCode);
        }
    }
}
