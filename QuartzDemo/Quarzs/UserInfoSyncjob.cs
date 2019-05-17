
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo.Quarzs
{
    public class UserInfoSyncjob : IJob
    {
        private readonly ILogger<UserInfoSyncjob> _logger;
      //  private readonly ICache _cache;
        public UserInfoSyncjob(ILogger<UserInfoSyncjob> logger)
        {
            //_cache = cache;
            _logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
                        {  
                             //.....
                            // Console.WriteLine($"{DateTime.Now.ToString()}：开始执行同步第三方数据");
                            _logger.LogInformation ($"{DateTime.Now.ToString()}：开始执行同步第三方数据");
                             //....同步操作
                             //  我们都知道如果一个从构造方法中获取IOC容器里面的类型，必须该类型也要主要到IOC容器中；
                           
                        });
        }
    }
}
