namespace devdeer.AssetsManager.Services.CoreApi.Controllers.v1
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Asp.Versioning;

    using Libraries.Abstractions.Models;
    using Libraries.AspNetCore.RestApi.BaseTypes;

    using Logic.Interfaces.Logic;
    using Logic.Models;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AssetController : SimpleBaseCrudController<AssetModel, IAssetLogic>
    {
        #region constructors and destructors

        /// <inheritdoc />
        public AssetController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        #endregion

        #region methods

        /// <summary>
        /// Checks if a given <paramref name="key" /> is already taken.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns><c>true</c> if the key is taken otherwise <c>false</c>.</returns>
        [HttpGet("KeyExists/{key}")]
        public async ValueTask<ActionResult<bool>> GetKeyExistsAsync(string key)
        {
            var result = await SpecificLogic.GetKeyExistsAsync(key);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves items filtered and sorted by the given <paramref name="request" />.
        /// </summary>
        /// <param name="request">The request containing the options for the desired result.</param>
        /// <returns>The information about the requested page including the data.</returns>
        [HttpPost("Paged")]
        public async ValueTask<ActionResult<PagedResponse<AssetModel>>> GetPagedAsync(PagedRequest request)
        {
            var result = await Logic.GetPagedAsync(request);
            return Ok(result);
        }

        #endregion

        #region properties

        private IAssetLogic SpecificLogic => (IAssetLogic)Logic;

        #endregion
    }
}