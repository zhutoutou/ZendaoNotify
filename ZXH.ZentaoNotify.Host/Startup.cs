using System;
using System.Linq;
using Abp.AspNetCore;
using Abp.Extensions;
using Castle.Facilities.Logging;
using Castle.Services.Logging.NLogIntegration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz.Logging;
using ZXH.ZentaoNotify.Web.Core.Configuration;

namespace ZXH.ZentaoNotify.Host
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;
        private const string DefaultCorsPolicyName = "localhost";
        public Startup(
            IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                    options => options.Filters.Add(new CorsAuthorizationFilterFactory(DefaultCorsPolicyName)))
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddEntityFrameworkInMemoryDatabase();

            // Configure CORS for UI
            services.AddCors(options =>
                options.AddPolicy(
                    DefaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(
                            _appConfiguration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                ));

            services.AddSwaggerDocument(document =>
            {
                document.DocumentName = "NSwag";

                #region OAuth2

                #endregion

                // Post process the generated document
                document.PostProcess = d =>
                {
                    d.Info.Title = "Zentao Notify";
                    d.Info.Description = "To be better";
                };
            });
            // Register a OpenAPI v3.0 document generator
            services.AddOpenApiDocument(
                document => document.DocumentName = "OpenAPI");

            return services.AddAbp<ZentaoNotifyModule>(
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.LogUsing<NLogFactory>().WithConfig("NLog.config")
                )
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Initializes Abp framework
            app.UseAbp(options => { options.UseAbpRequestLocalization = false; });

            // Enable CORS!
            app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "defaultWithArea",
                    "{area}/{controller}/{action}/{id?}");

                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });

            #region Swagger Middleware
            //// Add OpenAPI/Swagger middleware to serve documents and web UIs

            // URLs:
            // - http://localhost:5000/swagger/nswag/swagger.json
            // - http://localhost:5000/swagger/openapi/swagger.json
            // - http://localhost:5000/swagger

            #region Location Route

            // Add Swagger 2.0 document serving middleware
            app.UseOpenApi();

            // Add web UIs to interact with the document
            app.UseSwaggerUi3(options =>
            {
                #region IIS Virtual Host

                options.TransformToExternalPath = (internalUiRoute, request) =>
                {
                    if (internalUiRoute.StartsWith("/") &&
                    internalUiRoute.StartsWith(request.PathBase) == false)
                    {
                        return request.PathBase + internalUiRoute;
                    }
                    return internalUiRoute;
                };
                #endregion

            });

            #endregion

            #endregion

        }
    }
}
