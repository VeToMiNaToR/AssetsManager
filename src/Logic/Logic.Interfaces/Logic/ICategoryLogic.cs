using devdeer.AssetsManager.Logic.Models;
using devdeer.Libraries.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devdeer.AssetsManager.Logic.Interfaces.Logic
{
    /// <summary>
    /// Must be implemented by business logic components responsible for category.
    /// </summary>
    public interface ICategoryLogic : ISimpleLogic<CategoryModel, long>
    {
    }
}
