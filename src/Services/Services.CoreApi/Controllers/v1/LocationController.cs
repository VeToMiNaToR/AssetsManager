using Asp.Versioning;
using devdeer.AssetsManager.Logic.Interfaces.Logic;
using devdeer.AssetsManager.Logic.Models;
using devdeer.Libraries.Abstractions.Models;
using devdeer.Libraries.AspNetCore.RestApi.BaseTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace devdeer.AssetsManager.Services.CoreApi.Controllers.v1
{
    /// <summary>
    /// </summary>
    [ApiController]
    [ApiVersion("4.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LocationController : SimpleBaseCrudController<LocationModel, ILocationLogic>
    {
        #region constructors and destructors

        /// <inheritdoc />
        public LocationController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        #endregion

        #region methods

        /// <summary>
        /// Retrieves items filtered and sorted by the given <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The request containing the options for the desired result.</param>
        /// <returns>The information about the requested page including the data.</returns>
        [HttpPost("Paged")]
        public async ValueTask<ActionResult<PagedResponse<LocationModel>>> GetPagedAsync(PagedRequest request)
        {
            var result = await Logic.GetPagedAsync(request);
            return Ok(result);
        }

        #endregion
    }
}
