namespace devdeer.AssetsManager.Logic.Interfaces.Repositories
{
    using System;
    using System.Linq;

    using Libraries.Abstractions.Interfaces;

    using Models;

    /// <summary>
    /// Must be implemented by repositories dealing with brand data.
    /// </summary>
    public interface IBrandRepository : ISimpleRepository<BrandModel, long>
    {
    }
}