using System.Web.Mvc;
using System;
using System.Linq;
using WebSignalR.Context;
using WebSignalR.Entity;
using Newtonsoft.Json;
using WebGrease.Css.Extensions;

namespace WebSignalR.Controllers
{
    public class ServerController : Controller
    {
        //добавление нового сервера 
        public void StartLongProcess3(string server)
        {
            //создаем новый экземпляр класса «Server» и инициализируем его «Name» значением
            Server newServer = JsonConvert.DeserializeObject<Server>(server);

            newServer.UserId = new User
            {
                Id = 1,
                Login = "admin",
                Password = "123",
                Name = "Mark",
                DateEdit = DateTime.Now
            };

            using (ContextDb db = new ContextDb())
            {
                db.Server.Add(newServer);
                db.SaveChanges();
            }         
        }

        //удаление сервера из БД по имени
        public void DeleteServer(string server)
        {
            //создаем новый экземпляр класса «Server» и инициализируем его «Name» значением
            Server newServer = JsonConvert.DeserializeObject<Server>(server);

            newServer.UserId = new User
            {
                Id = 1,
                Login = "admin",
                Password = "123",
                Name = "Mark",
                DateEdit = DateTime.Now
            };

            using (ContextDb db = new ContextDb())
            {
                var serverToDelete =  db.Server.FirstOrDefault(x => x.Name == newServer.Name);

                if (serverToDelete != null)
                {
                    db.Server.Remove(serverToDelete);
                }
                db.SaveChanges();
            }            
        }

        //Удаляем все объекты "Server" из БД
        public void DeleteAllServersDb()
        {
            using (ContextDb db = new ContextDb())
            {
                var serversToDelete = db.Server;

                serversToDelete.ForEach(x =>
                {
                    db?.Server.Remove(x);
                });
               
                db.SaveChanges();               
            }       
        }

    }
}
