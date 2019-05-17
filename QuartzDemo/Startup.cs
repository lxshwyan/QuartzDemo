using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using QuartzDemo.Quarzs;

namespace QuartzDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //注入 Quartz调度类
            services.AddSingleton<QuartzStartup>();
            services.AddTransient<UserInfoSyncjob>();      // 这里使用瞬时依赖注入
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();//注册ISchedulerFactory的实例。
         
            services.AddSingleton<IJobFactory, IOCJobFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IApplicationLifetime appLifetime )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //获取前面注入的Quartz调度类
            var quartz = app.ApplicationServices.GetRequiredService<QuartzStartup>();
            appLifetime.ApplicationStarted.Register(() =>
             {
              quartz.Start().Wait(); //网站启动完成执行
             });
          
            appLifetime.ApplicationStopped.Register(() =>
            {
                quartz.Stop();  //网站停止完成执行
               
            });
            app.UseMvc();
        }
    }
}
