using devdeer.AssetsManager.Logic.Interfaces.Logic;
using devdeer.AssetsManager.Logic.Interfaces.Repositories;
using devdeer.AssetsManager.Logic.Models;
using devdeer.Libraries.Abstractions.BaseTypes;
using devdeer.Libraries.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Logic.Core
{
    /// <summary>
    /// Default business logic for category.
    /// </summary>
    public class CategoryLogic : SimpleLogicBase<CategoryModel, long>, ICategoryLogic
    {
        #region constructors and destructors

        /// <inheritdoc />
        public CategoryLogic(ICategoryRepository repository) : base(repository)
        {
        }
        #endregion
    }
}
