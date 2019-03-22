namespace WebSignalR.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.SignalR;
    using System;
    using System.Collections.Generic;
    using Context;
    using System.Net.NetworkInformation;
    using Entity;
    using System.Web.Script.Serialization;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void Start()
        {
            var server = GetServerList();

            // получим объекты из БД и добавим их к листу из стат. объектов
            using (ContextDb db = new ContextDb())
            {
                var serverDb = db.Server;
                server.AddRange(serverDb);
            }

            var severList = GetPingServer(server);

            var json = new JavaScriptSerializer().Serialize(severList);

            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<SimpleHub>();
            context.Clients.All.showTextessage(json);
        }

        private List<Server> GetServerList()
        {
            var serverList = new List<Server>
            {
                new Server
                {
                    Id = 1,
                    Name = "Google.ru",
                    UserId = new User{Id = 1, Login = "admin" , Password = "123", Name = "Mark", DateEdit = DateTime.Now}
                },
                new Server
            {
                    Id = 2,
                    Name = "Mail.ru",
                    UserId = new User{Id = 1, Login = "admin" , Password = "123", Name = "Mark", DateEdit = DateTime.Now}
                },
                new Server
                {
                    Id = 3,
                    Name = "Ya.ru",
                    UserId = new User{Id = 1, Login = "admin" , Password = "123", Name = "Mark", DateEdit = DateTime.Now}
                }
            };

            return serverList;
        }

        private List<ProxyServerByIsAvailable> GetPingServer(List<Server> serverList)
        {
            Ping ping = new Ping();

            List<ProxyServerByIsAvailable> serverByIsAvailables = new List<ProxyServerByIsAvailable>();

            foreach (var serv in serverList)
            {
                try
                {
                    var pingReply = ping.Send(serv.Name, 444);

                    serverByIsAvailables.Add(new ProxyServerByIsAvailable
                    {
                        ServerName = serv.Name,
                        IsAvailable = pingReply?.Status == IPStatus.Success
                    });
                }
                catch (PingException)
                {
                    serverByIsAvailables.Add(new ProxyServerByIsAvailable
                    {
                        ServerName = serv.Name,
                        IsAvailable = false
                    });
                }
            }
            return serverByIsAvailables;
        }
    }

    class ProxyServerByIsAvailable
    {
        public string ServerName { get; set; }
        public bool IsAvailable { get; set; }
    }
}