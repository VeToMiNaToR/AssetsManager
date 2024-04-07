using AutoMapper;
using devdeer.AssetsManager.Data.Entities;
using devdeer.AssetsManager.Data.Entities.Entities;
using devdeer.AssetsManager.Logic.Interfaces.Repositories;
using devdeer.AssetsManager.Logic.Models;
using devdeer.AssetsManager.Repositories.Core.Base;
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
    /// The default repository for workplace data access.
    /// </summary>
    public class WorkplaceRepository : BaseRepository<WorkplaceModel, Workplace>, IWorkplaceRepository
    {
        #region constructors and destructors

        /// <inheritdoc />
        public WorkplaceRepository(AssetsManagerContext dbContext, IMapper mapper, ILogger<WorkplaceRepository> logger) : base(dbContext, mapper, logger)
        {
        }

        #endregion

        #region methods

        /// <inheritdoc />
        protected override Expression<Func<Workplace, bool>> GetEntityFilterExpression(string filterText)
        {
            filterText = filterText.ToLower();
            return e => e.Label.ToLower()
                .Contains(filterText);
        }
        #endregion
    }
}
