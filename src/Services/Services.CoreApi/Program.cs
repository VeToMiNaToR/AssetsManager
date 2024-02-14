namespace devdeer.AssetsManager.Services.CoreApi
{
    using System;
    using System.Linq;

    using devdeer.Libraries.AspNetCore.RestApi.Extensions;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Provides main entry point for the app.
    /// </summary>
    public class Program
    {
        #region methods

        /// <summary>
        /// The main entry point of the app.
        /// </summary>
        /// <param name="args">Optional command line arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        /// <summary>
        /// Prepares the web host using the logic in <see cref="Startup" />.
        /// </summary>
        /// <param name="args">Optional command line arguments.</param>
        /// <returns>The prepared web host.</returns>
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    })
                .ConfigureLogging();
        }

        #endregion
    }
}