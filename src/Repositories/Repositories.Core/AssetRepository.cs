namespace devdeer.AssetsManager.Repositories.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using AutoMapper;

    using Base;

    using Data.Entities;

    using Logic.Interfaces.Repositories;
    using Logic.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The default repository for asset data access.
    /// </summary>
    public class AssetRepository : BaseRepository<AssetModel, Asset>, IAssetRepository
    {
        #region constructors and destructors

        /// <inheritdoc />
        public AssetRepository(
            AssetsManagerContext dbContext,
            IMapper mapper,
            ILogger<AssetRepository> logger,
            ICategoryRepository categoryRepository) : base(dbContext, mapper, logger)
        {
            CategoryRepository = categoryRepository;
        }

        #endregion

        #region methods

        /// <inheritdoc />
        protected override Expression<Func<Asset, bool>> GetEntityFilterExpression(string filterText)
        {
            filterText = filterText.ToLower();
            return e => e.AssetKey.ToLower()
                .Contains(filterText) || e.SerialNumber.ToLower()
                .Contains(filterText) || e.Comment.ToLower().Contains(filterText) || e.ModelName.ToLower().Contains(filterText);
        }

        /// <inheritdoc />
        protected override Task HandleEntityAfterCreateAsync(Asset entity, AssetsManagerContext createContext)
        {
            var category = CategoryRepository.GetByIdAsync(entity.CategoryId)
                .GetAwaiter()
                .GetResult();
            entity.AssetKey =
                $"DD-{category!.Label.ToUpperInvariant().Substring(0, 2)}-{entity.Id.ToString("0000", CultureInfo.InvariantCulture)}";
            var model = GetModel(entity);
            UpdateAsync(model!)
                .GetAwaiter()
                .GetResult();
            return base.HandleEntityAfterCreateAsync(entity, createContext);
        }

        protected override void HandleEntityBeforeCreate(Asset entity)
        {
            entity.AssetKey = Guid.NewGuid()
                .ToString("N")
                .Substring(0, 10);
            base.HandleEntityBeforeCreate(entity);
        }

        /// <inheritdoc />
        protected override IQueryable<Asset> InternalGetBaseQuery(AssetsManagerContext? ctx = null)
        {
            return base.InternalGetBaseQuery(ctx)
                .Include(a => a.Category)
                .Include(a => a.Location)
                .Include(a => a.Worker)
                .Include(a => a.Workplace)
                .Include(a => a.Brand);
        }

        #endregion

        #region properties

        private ICategoryRepository CategoryRepository { get; }

        #endregion
    }
}