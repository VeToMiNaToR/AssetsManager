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
    /// The default repository for worker data access.
    /// </summary>
    public class WorkerRepository : BaseRepository<WorkerModel, Worker>, IWorkerRepository
    {
        #region constructors and destructors

        /// <inheritdoc />
        public WorkerRepository(AssetsManagerContext dbContext, IMapper mapper, ILogger<WorkerRepository> logger) : base(dbContext, mapper, logger)
        {
        }
        #endregion

        #region methods
        /// <inheritdoc />
        protected override Expression<Func<Worker, bool>> GetEntityFilterExpression(string filterText)
        {
            filterText = filterText.ToLower();
            return e => e.Label.ToLower()
                .Contains(filterText);
        }
        #endregion
    }
}
