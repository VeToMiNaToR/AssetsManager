namespace devdeer.AssetsManager.Data.Entities
{
    using System;
    using System.Linq;
    using devdeer.AssetsManager.Data.Entities.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The EF Core context for the project.
    /// </summary>
    public class AssetsManagerContext : DbContext
    {
        //<inherit.doc>//
        public DbSet<Asset> Assets { get; set; }

        //<inherit.doc>//
        public DbSet<Brand> Brands { get; set; }

        //<inherit.doc>//
        public DbSet<Category> Categories { get; set; }

        //<inherit.doc>//
        public DbSet<Location> Locations { get; set; }

        //<inherit.doc>//
        public DbSet<Worker> Workers { get; set; }

        //<inherit.doc>//
        public DbSet<Workplace> Workplaces { get; set; }

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
        }

        #endregion
    }
}