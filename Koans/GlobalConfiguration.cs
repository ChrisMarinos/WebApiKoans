using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Koans
{
    public static class GlobalConfiguration
    {
        public static readonly HttpConfiguration Configuration;
        private static bool _isDisposed;

        static GlobalConfiguration()
        {
            Configuration = new HttpConfiguration();

            // We will use the Microsoft.AspNet.WebApi.Tracing package to print
            // trace information from Web API. Check your output window so see
            // how Web API works.
            TraceConfig.Register(Configuration);
        }

        public static void Reset()
        {
            if (_isDisposed)
                throw new ObjectDisposedException("Configuration");

            JsonMediaTypeFormatter jsonFormatter = Configuration.Formatters.JsonFormatter;
            XmlMediaTypeFormatter xmlFormatter = Configuration.Formatters.XmlFormatter;
            Configuration.Formatters.Clear();
            Configuration.Formatters.Add(jsonFormatter);
            Configuration.Formatters.Add(xmlFormatter);
            Configuration.MessageHandlers.Clear();
            Configuration.Routes.Clear();
        }

        public static void Dispose()
        {
            if (Configuration != null && !_isDisposed)
            {
                Configuration.Dispose();
                _isDisposed = true;
            }
        }
    }

    public static class WebApiKoans
    {
        public static HttpServer Server = new HttpServer(GlobalConfiguration.Configuration);
        public static HttpClient Client = new HttpClient(Server, true);

        public static void Dispose()
        {
            try
            {
                if (Client != null)
                {
                    Client.Dispose();
                    Client = null;
                }
            }
            catch {}
        }
    }
}
