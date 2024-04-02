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
    [ApiVersion("4.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BrandController : SimpleBaseCrudController<BrandModel, IBrandLogic>
    {
        #region constructors and destructors

        /// <inheritdoc />
        public BrandController(IServiceProvider serviceProvider) : base(serviceProvider)
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
        public async ValueTask<ActionResult<PagedResponse<BrandModel>>> GetPagedAsync(PagedRequest request)
        {
            var result = await Logic.GetPagedAsync(request);
            return Ok(result);
        }

        #endregion
    }
}