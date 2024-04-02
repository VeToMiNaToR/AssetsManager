namespace devdeer.AssetsManager.Repositories.Core
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using AutoMapper;

    using Base;

    using Data.Entities;
    using Data.Entities.Entities;

    using Logic.Interfaces.Repositories;
    using Logic.Models;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The default repository for brand data access.
    /// </summary>
    public class BrandRepository : BaseRepository<BrandModel, Brand>, IBrandRepository
    {
        #region constructors and destructors

        /// <inheritdoc />
        public BrandRepository(AssetsManagerContext dbContext, IMapper mapper, ILogger<BrandRepository> logger) : base(
            dbContext,
            mapper,
            logger)
        {
        }

        #endregion

        #region methods

        /// <inheritdoc />
        protected override Expression<Func<Brand, bool>> GetEntityFilterExpression(string filterText)
        {
            filterText = filterText.ToLower();
            return e => e.Label.ToLower()
                .Contains(filterText);
        }

        #endregion
    }
}