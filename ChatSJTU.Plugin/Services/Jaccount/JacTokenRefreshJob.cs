using Quartz;
using System.Diagnostics;

namespace ChatSJTU.Plugin.Services.Jaccount
{
    public class JacTokenRefreshJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Debug.WriteLine("JacTokenRefreshJob start");

            GlobalCookie.Read();
            //TokenService.ReadTokenA();
            //TokenService.ReadTokenB();

            //var res1 = TokenService.RefreshTokenA();
            //if (!res1.success)
            //{
            //    Debug.WriteLine($"JacTokenRefreshJob fail: {res1.result}");
            //    return Task.FromResult(false);
            //}
               
            //var res2 = TokenService.RefreshTokenB();
            //if (!res2.success)
            //{
            //    Debug.WriteLine($"JacTokenRefreshJob fail: {res2.result}");
            //    return Task.FromResult(false);
            //}

            GlobalCookie.Save();
            Debug.WriteLine($"JacTokenRefreshJob succ");
            return Task.FromResult(true);
        }
    }
}
