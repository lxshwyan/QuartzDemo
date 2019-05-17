
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzDemo.Quarzs
{
    public class IOCJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public IOCJobFactory(IServiceProvider serviceProvider)
        {
           _serviceProvider = serviceProvider;      
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {    
            return _serviceProvider.GetService(bundle.JobDetail.JobType) as IJob; 
        }

        public void ReturnJob(IJob job)
        {
            var disposable = job as IDisposable;
            disposable?.Dispose();

        }
    }
}
