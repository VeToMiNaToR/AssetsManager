using devdeer.AssetsManager.Logic.Models;
using devdeer.Libraries.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Logic.Interfaces.Repositories
{
    /// <summary>
    /// Must be implemented by repositories dealing with category data.
    /// </summary>
    public interface ICategoryRepository : ISimpleRepository<CategoryModel, long>
    {
    }
}
