namespace WebSignalR.Jobs
{
    using Quartz;
    using Controllers;
    
    public class ServerAvailability : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            HomeController controller = new HomeController();
            controller.Start();
        }
    }
}