using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PenAndPaperDay.Core.Configuration;
using PenAndPaperDay.Core.Interfaces.Services;
using PenAndPaperDay.Core.Mailing;
using PenAndPaperDay.Data;
using PenAndPaperDay.Data.Repositories;
using PenAndPaperDay.Service.Services;

namespace PenAndPaperDay.Web
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
            services.Configure<PenAndPaperConfiguration>(Configuration.GetSection("AppSettings"));

            services.AddDbContext<PenAndPaperDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Connection")));

            //services.AddSingleton(Configuration);

            //Repos
            services.AddScoped<ITimeRangeRepository, TimeRangeRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IErrorLogEntryRepository, ErrorLogEntryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOfferedGameRepository, OfferedGameRepository>();
            services.AddScoped<IUserOnOfferedGameRepository, UserOnOfferedGameRepository>();
            services.AddScoped<IOfferedGameOnTagRepository, OfferedGameOnTagRepository>();
            services.AddScoped<INewsletterRepository, NewsletterRepository>();
            services.AddScoped<IUserOnTimeRangeRepository, UserOnTimeRangeRepository>();

            services.AddAutoMapper();

            //Services
            services.AddScoped<IEmailSenderService, SendGridEmailSender>();
            services.AddScoped<ITimeRangeService, TimeRangeService>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IErrorLogEntryService, ErrorLogEntryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOfferedGameService, OfferedGameService>();
            services.AddScoped<INewsletterService, NewsletterService>();
            services.AddScoped<IUserOnTimeRangeService, UserOnTimeRangeService>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
