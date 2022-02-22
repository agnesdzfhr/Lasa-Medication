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

using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration;
using Siloam.System;

using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using System.IO.Compression;
using Microsoft.AspNetCore.ResponseCompression;
using Siloam.Config;
using Siloam.Service.LasaMedication.Models.ViewModels;
using Siloam.Service.LasaMedication.Hub;
using Siloam.Service.LasaMedication.Common;

namespace Siloam.Service.LasaMedication
{
	public class Startup
	{
		public Startup(IHostingEnvironment env, ILoggerFactory factory)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddCloudFoundry()
				.AddEnvironmentVariables();

			Configuration = builder.Build();
		}
		//public Startup(IConfiguration configuration)
		//{
		//	Configuration = configuration;
		//}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
            SetApplicationSettings();

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(ApplicationSetting.ConnectionString));
            services.AddDiscoveryClient(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2.0", new Info
                {
                    Title = "Siloam Service User Management",
                    Version = "v1.0",
                    Description = "Build on the .NET Core 2.0 and SignalR - GTN"
                });
            });
            services.AddRouting(options => options.LowercaseUrls = true);
            //services.AddCors();
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddMvcCore().AddApiExplorer();
            services.AddMvc();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddOptions();
            services.AddSignalR();

            //mapper digunakan untuk mapping antar model agar properti dari model dapat digunakan di dalam function di repository untuk model lainnya.
            AutoMapper.Mapper.Initialize(mapper =>
            {
                //mapper.CreateMap<Models.Users, Models.ViewModels.UserMasters>().ReverseMap();
                //mapper.CreateMap<Models.UserContacts, Models.ViewModels.UserDetails>().ReverseMap();
                //mapper.CreateMap<Models.UserApplications, Models.ViewModels.UserApplicationDetails>().ReverseMap();
            });
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = new[]
                {
                    // Default section
                    "text/plain",
                    "text/css",
                    "application/javascript",
                    "text/html",
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json",
                    // Custom section
                    "image/svg+xml"
                };
            });

        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDiscoveryClient();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseSwagger();
            app.UseResponseCompression();
            app.UseMvc();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2.0/swagger.json", "Siloam Service User Management API");
            });
            app.UseSignalR(routes =>
            {
                routes.MapHub<MessageHub>("messagehub");
            });
        }

        private void SetApplicationSettings()
        {
            if (Configuration["Data:keyregistry"].ToString() == "1")
            {
                ApplicationSetting.ConnectionString = Siloam.Config.Configuration.Functions.GetValue("DB_Ums").ToString();
            }
            else
            {
                ApplicationSetting.ConnectionString = Configuration["Data:ConnectionString"];
            }
            AppSettingConfig.EncryptKey_Encrypt = Configuration["Data:EncryptionKey_Encrypt"];
            AppSettingConfig.EncryptKey_Decrypt = Configuration["Data:EncryptionKey_Decrypt"];
            AppSettingConfig.MaxLockCounter = Configuration["Data:MaxLockCounter"];
            AppSettingConfig.ExpPassCounter = Configuration["Data:ExpPassCounter"];
            AppSettingConfig.DefaultPassword = Configuration["Data:DefaultPassword"];
            AppSettingConfig.IsChangeGlobalPass = Configuration["Data:IsChangeGlobalPass"];
            AppSettingConfig.proInt_Domain = Configuration["Data:proInt_Domain"];
            AppSettingConfig.proInt_Username = Configuration["Data:proInt_Username"];
            AppSettingConfig.proInt_Password = Configuration["Data:proInt_Password"];
            AppSettingConfig.emailEngineService = Configuration["Data:emailEngineService"];
            AppSettingConfig.emailType = Configuration["Data:emailType"];
            AppSettingConfig.emailSender = Configuration["Data:emailSender"];
            AppSettingConfig.emailDisplayName = Configuration["Data:emailDisplayName"];
            AppSettingConfig.loginapiconfig = Configuration["Data:loginapiconfig"];
            AppSettingConfig.minPasswordLength = Configuration["Data:minPasswordLength"];

        }
    }
}
