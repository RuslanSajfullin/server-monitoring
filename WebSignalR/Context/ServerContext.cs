namespace WebSignalR.Context
{
    using System.Data.Entity;
    using WebSignalR.Entity;

    class ContextDb : DbContext
    {
        public ContextDb()
            : base("DbConnection")
        { }

        public DbSet<Server> Server { get; set; }
        public DbSet<User> User { get; set; }
    }
}
