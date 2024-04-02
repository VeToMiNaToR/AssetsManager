namespace devdeer.AssetsManager.Logic.Core
{
    using System;
    using System.Linq;

    using Interfaces.Logic;
    using Interfaces.Repositories;

    using Libraries.Abstractions.BaseTypes;

    using Models;

    /// <summary>
    /// Default business logic for brands.
    /// </summary>
    public class BrandLogic : SimpleLogicBase<BrandModel, long>, IBrandLogic
    {
        #region constructors and destructors

        /// <inheritdoc />
        public BrandLogic(IBrandRepository repository) : base(repository)
        {
        }

        #endregion
    }
}