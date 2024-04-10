using AutoMapper;
using devdeer.AssetsManager.Data.Entities;
using devdeer.AssetsManager.Logic.Interfaces.Repositories;
using devdeer.AssetsManager.Logic.Models;
using devdeer.AssetsManager.Repositories.Core.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Repositories.Core
{
    /// <summary>
    /// The default repository for asset data access.
    /// </summary>
    public class AssetRepository : BaseRepository<AssetModel, Asset>, IAssetRepository
    {
        #region constructors and destructors

        /// <inheritdoc />
        public AssetRepository(AssetsManagerContext dbContext, IMapper mapper, ILogger<AssetRepository> logger) : base(dbContext, mapper, logger)
        {
        }

        #endregion

        #region methods

        /// <inheritdoc />
        protected override Expression<Func<Asset, bool>> GetEntityFilterExpression(string filterText)
        {
            filterText = filterText.ToLower();
            return e =>
            e.AssetKey.ToLower().Contains(filterText) ||
            e.SerialNumber.ToLower().Contains(filterText) ||
            e.State.ToString().ToLower().Contains(filterText) ||
            e.AcquisitionDate.ToString("MM/dd/yyyy").Contains(filterText) ||
            e.Availability.ToString().ToLower().Contains(filterText) || 
            e.Ownership.ToString().ToLower().Contains(filterText) ||
            e.Comment.ToLower().Contains(filterText) ||
            e.ModelName.ToLower().Contains(filterText) ||
            e.PrimaryImagePath.ToLower().Contains(filterText) ||
            e.SecondaryImagePath.ToLower().Contains(filterText);
        }
        protected override void HandleEntityBeforeCreate(Asset entity)
        {   
            entity.AssetKey =
            base.HandleEntityBeforeCreate(entity);
        }
        protected override void HandleEntityBeforeUpdate(Asset entity, Asset convertedEntity, AssetModel model)
        {
            base.HandleEntityBeforeUpdate(entity, convertedEntity, model);
        }
        #endregion
    }
}
