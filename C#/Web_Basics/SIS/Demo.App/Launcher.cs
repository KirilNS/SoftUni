using Demo.App.Controllers;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer;
using SIS.WebServer.Routing;
using SIS.WebServer.Routing.Contracts;
using System;
using System.Globalization;
using System.Text;

namespace Demo.App
{
    class Launcher
    {
        static void Main(string[] args)
        {
            //string request = "Get /url/asd?name=JohnDoe&id=1#fragment HTTP/1.1\r\n" +
            //    "Authorization: Basic 52324653\r\n" +
            //    "Date: " + DateTime.Now + "\r\n" +
            //    "Host: localhost:5000\r\n" +
            //    "\r\n" +
            //    "username=johndoe&password=123";

            //HttpRequest httpRequest = new HttpRequest(request);

            //HttpResponseStatusCode statusCode = HttpResponseStatusCode.Ok;
            //HttpResponse response = new HttpResponse(statusCode);

            //response.AddHeader(new HttpHeader("Host", "localhost: 500"));
            //response.AddHeader(new HttpHeader("Date", DateTime.Now.ToString(CultureInfo.InvariantCulture)));

            //response.Content = Encoding.UTF8.GetBytes("<h1> Hello World! </h1>");

            //Console.WriteLine(Encoding.UTF8.GetString(response.GetBytes()));

            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Add(HttpRequestMethod.Get, "/", request => new HomeController().Home(request));

            Server server = new Server(8000, serverRoutingTable);

            server.Run();

        }
    }
}
