
using Quartz.Impl;
using Quartz;
using static Quartz.Logging.OperationName;
using ChatSJTU.Plugin.Services.Jaccount;
using ChatSJTU.Plugin.Services;

namespace ChatSJTU.Plugin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GlobalCookie.CookieContainer = new System.Net.CookieContainer();

            StdSchedulerFactory factory = new StdSchedulerFactory();
            //创建任务调度器
            IScheduler scheduler = factory.GetScheduler().GetAwaiter().GetResult();
            //启动任务调度器
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<JacTokenRefreshJob>()
                .WithIdentity("JacTokenRefreshJob", "Test")
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
               .WithIdentity("JacTokenRefreshJobTrigger", "Test")
               .WithSimpleSchedule(x =>
               {
                   x.WithIntervalInMinutes(59).RepeatForever();
               })
               .StartNow()
               .Build();
            //将创建的任务和触发器条件添加到创建的任务调度器当中
            scheduler.ScheduleJob(job, trigger);

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.WebHost.UseUrls("http://*:65472");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            
        }
    }
}