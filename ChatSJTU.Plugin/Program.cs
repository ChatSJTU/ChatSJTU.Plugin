
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
            //�������������
            IScheduler scheduler = factory.GetScheduler().GetAwaiter().GetResult();
            //�������������
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
            //������������ʹ�����������ӵ��������������������
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