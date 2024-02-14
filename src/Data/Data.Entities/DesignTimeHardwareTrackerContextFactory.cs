namespace devdeer.AssetsManager.Data.Entities
{
    using System;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    /// <inheritdoc />
    public class DesignTimeAssetsManagerContextFactory : IDesignTimeDbContextFactory<AssetsManagerContext>
    {
        #region explicit interfaces

        /// <inheritdoc />
        public AssetsManagerContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<AssetsManagerContext>().UseSqlServer(
                    "Server=localhost,1433;Database=AssetsManager;User Id=sa;Password=Sql-Server-Dev;App=LocalDev-Service.Api;Encrypt=True;TrustServerCertificate=True",
                    o =>
                    {
                        o.MigrationsHistoryTable("MigrationHistory", "SystemData");
                        o.CommandTimeout(3600);
                    })
                .Options;
            return new AssetsManagerContext(options);
        }

        #endregion
    }
}