namespace devdeer.AssetsManager.Services.CoreApi
{
    using System;
    using System.Linq;

    using Data.Entities;

    using Helper;

    using Libraries.AspNetCore.RestApi.Extensions;
    using Libraries.AspNetCore.RestApi.Models;
    using Libraries.Repository.EntityFrameworkCore.Extensions;
    using Libraries.Repository.EntityFrameworkCore.Models;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Contains logic for initial app configuration.
    /// </summary>
    public class Startup
    {
        #region member vars

        private readonly ConfigurationOptions _options = new()
        {
            SkipAutomaticHealthCheckConfig = false,
            AutoRegisterDefaultServices = true,
            AutoRegisterModelMapping = true,
            SkipSwaggerCommentsMerge = false
        };

        #endregion

        #region constructors and destructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="configuration">Injected app-configuration-access.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region methods

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Pre-configured injected application builder to be customized here.</param>
        public void Configure(IApplicationBuilder app)
        {
            app.UseSession();
            app.ConfigureDefaults(_options);
            app.UseDbContext<AssetsManagerContext>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The injected service collection to be extended by custom services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // perform DEVDEER-lib-init
            services.ConfigureServices(Configuration, _options);
            services.ConfigureSqlServer<AssetsManagerContext>(
                Configuration,
                new SqlServerConfigurationOptions
                {
                    CodeFirstMigrationAssemblyName = typeof(AssetsManagerContext).Assembly.FullName,
                    ConnectionStringKey = "AssetsManager",
                    ConfigureLogging = false,
                    ConfigAction = b => b.CommandTimeout(300)
                });
            services.AddDistributedMemoryCache();
            services.AddSession(
                options =>
                {
                    options.IdleTimeout = TimeSpan.FromMinutes(20);
                    options.Cookie.IsEssential = true;
                });
            services.AddHealthChecks()
                .AddDbContextCheck<AssetsManagerContext>();
            ConfigureCustomServices(services);
        }

        /// <summary>
        /// Is responsible of service registration for custom services.
        /// </summary>
        /// <param name="services">The injected service collection to be extended by custom services.</param>
        private static void ConfigureCustomServices(IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(typeof(AutoMapperDefaultProfile));
            // Config.
        }

        #endregion

        #region properties

        /// <summary>
        /// Injected app-configuration-access.
        /// </summary>
        private IConfiguration Configuration { get; }

        #endregion
    }
}