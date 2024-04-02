namespace devdeer.AssetsManager.Data.Entities
{
    using System;
    using System.Linq;

    using Entities;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The EF Core context for the project.
    /// </summary>
    public class AssetsManagerContext : DbContext
    {
        #region constructors and destructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="options">The database context options for configuring access to the database.</param>
        public AssetsManagerContext(DbContextOptions<AssetsManagerContext> options) : base(options)
        {
        }

        #endregion

        #region methods

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Asset>()
                .HasIndex(a => a.AssetKey, "UX_Asset_AssetKey")
                .IsUnique();
        }

        #endregion

        #region properties

        /// <summary>
        /// Represents the referance to all assets in the datastore.
        /// </summary>
        public DbSet<Asset> Assets { get; set; }

        /// <summary>
        /// Represents the referance to all brands in the datastore.
        /// </summary>
        public DbSet<Brand> Brands { get; set; }

        /// <summary>
        /// Represents the referance to all categories in the datastore.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Represents the referance to all locations in the datastore.
        /// </summary>
        public DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Represents the referance to all workers in the datastore.
        /// </summary>
        public DbSet<Worker> Workers { get; set; }

        /// <summary>
        /// Represents the referance to all workplace in the datastore.
        /// </summary>
        public DbSet<Workplace> Workplaces { get; set; }

        #endregion
    }
}