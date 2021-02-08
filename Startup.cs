using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using CQRSApi.Repository;
using CQRSApi.Helper;
using CQRSApi.Responses;
using static CQRSApi.Helper.MongoDbSettings;
using Microsoft.Extensions.Options;
using FluentValidation;
using CQRSApi.Behaviors;

namespace CQRSApi
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
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MongoLogBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            services.AddTransient<IBaseRepository<Audit>, BaseRepository<Audit>>();
            services.AddTransient<IBaseRepository<Log>, BaseRepository<Log>>();

            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMediatR(typeof(Startup));
            services.AddHttpClient();
            
            //services.AddSingleton<IClientHelper, ClientHelper>();
            services.Configure<RemPeopleMongoDbSettings>(Configuration.GetSection(nameof(RemPeopleMongoDbSettings)));
            services.AddSingleton<IRemPeopleMongoDbSettings>(sp => sp.GetRequiredService<IOptions<RemPeopleMongoDbSettings>>().Value);
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
