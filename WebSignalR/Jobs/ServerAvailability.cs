namespace WebSignalR.Jobs
{
    using Quartz;
    using Controllers;
    using System.Threading.Tasks;

    public class ServerAvailability : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            HomeController controller = new HomeController();
            controller.Start();
        }

        Task IJob.Execute(IJobExecutionContext context)
        {
            HomeController controller = new HomeController();
            controller.Start();
            return Task.FromResult<object>(null);
        }
    }
}