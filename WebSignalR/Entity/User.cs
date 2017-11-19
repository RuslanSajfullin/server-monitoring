namespace WebSignalR.Entity
{
    using System;

    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set;}
        public string Password { get; set; }
        public DateTime DateEdit { get; set; }

        //ctor
        public User()
        {
            DateEdit = DateTime.Now;
        }
    }
}