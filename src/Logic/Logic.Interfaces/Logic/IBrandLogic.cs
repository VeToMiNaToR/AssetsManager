namespace devdeer.AssetsManager.Logic.Interfaces.Logic
{
    using System;
    using System.Linq;

    using Libraries.Abstractions.Interfaces;

    using Models;

    /// <summary>
    /// Must be implemented by business logic components responsible for brands.
    /// </summary>
    public interface IBrandLogic : ISimpleLogic<BrandModel, long>
    {
    }
}