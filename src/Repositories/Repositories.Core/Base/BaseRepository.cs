namespace devdeer.AssetsManager.Repositories.Core.Base
{
    using System;
    using System.Linq;

    using AutoMapper;

    using Data.Entities;

    using devdeer.Libraries.Abstractions.Interfaces;
    using devdeer.Libraries.Repository.EntityFrameworkCore.Repositories;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The repository to access service data using EF Core.
    /// </summary>
    public abstract class
        BaseRepository<TModel, TEntity> : SimpleEntityFrameworkRepositoryBase<AssetsManagerContext, TModel, TEntity>
        where TModel : IModel<long> where TEntity : class, IEntity<long>

    {
        #region constructors and destructors

        /// <inheritdoc />
        protected BaseRepository(AssetsManagerContext dbContext, IMapper mapper, ILogger logger) : base(dbContext)
        {
            Mapper = mapper;
            Logger = logger;
        }

        #endregion

        #region methods

        /// <inheritdoc />
        protected override TEntity? GetEntity(TModel? model)
        {
            return Mapper.Map<TEntity>(model);
        }

        /// <inheritdoc />
        protected override TEntity? GetEntity(TEntity entity, TModel? model)
        {
            return Mapper.Map(model, entity);
        }

        /// <inheritdoc />
        protected override TModel? GetModel(TEntity? entity)
        {
            return Mapper.Map<TModel>(entity);
        }

        #endregion

        #region properties

        /// <inheritdoc />
        public override bool IsSoftDeleteEnabled => false;

        /// <summary>
        /// The AutoMapper to use.
        /// </summary>
        protected IMapper Mapper { get; }

        /// <summary>
        /// The logger to use.
        /// </summary>
        protected ILogger Logger { get; }

        #endregion
    }
}