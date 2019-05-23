using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using NLog.Web;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using QuartzDemo.Core;
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
            
         // EnginContext.Initialize(new GeneralEngine(services.BuildServiceProvider()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,IApplicationLifetime appLifetime )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region AddNLog
            //添加NLog  
            loggerFactory.AddNLog();
            //读取Nlog配置文件 
            env.ConfigureNLog("nlog.config");
            #endregion
            EnginContext.Initialize(new GeneralEngine(app.ApplicationServices));
            //获取前面注入的Quartz调度类
            var quartz = app.ApplicationServices.GetRequiredService<QuartzStartup>();
            #region 远程读取日志
            FileExtensionContentTypeProvider provider = new FileExtensionContentTypeProvider(); 
          //  provider.Mappings[".log"] = "text/plain;charset=utf-8";
          provider.Mappings[".log"] = "text/plain;charset=utf-8";
            string basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(basePath, "logs")),
                ServeUnknownFileTypes = true,
                RequestPath = new PathString("/logs"),
                ContentTypeProvider = provider,
                DefaultContentType = "application/x-msdownload", // 设置未识别的MIME类型一个默认z值

            });
            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(basePath, "logs")),
                RequestPath = new PathString("/logs"),
            });
            #endregion

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
