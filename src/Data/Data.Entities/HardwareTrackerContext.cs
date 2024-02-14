namespace Devdeer.AssetsManager.Data.Entities
{
    using System;
    using System.Linq;
    using Devdeer.AssetsManager.Logic.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The EF Core context for the project.
    /// </summary>
    public class AssetsManagerContext : DbContext
    {

        public DbSet<DataEntriesModel> DataEntries { get; set; }

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