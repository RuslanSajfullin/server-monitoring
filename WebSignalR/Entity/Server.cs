namespace WebSignalR.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Server
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOperation { get; set; }
        public User UserId { get; set; }
        
        //ctor
        public Server()
        {
            DateOperation = DateTime.Now;
        }
    }
}