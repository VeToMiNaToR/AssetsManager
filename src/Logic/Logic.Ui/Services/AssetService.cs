namespace devdeer.AssetsManager.Logic.Ui.Services
{
    using System.Text.Json;

    using Logic.Models;

    /// <summary>
    /// Service for communication to backend asset endpoints.
    /// </summary>
    public class AssetService : BaseService<AssetModel>
    {
        #region constructors and destructors

        /// <inheritdoc />
        public AssetService(HttpClient httpClient) : base(httpClient)
        {
        }

        #endregion

        #region methods

        /// <summary>
        /// Checks if a given <paramref name="key" /> is already taken.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns><c>true</c> if the key is taken otherwise <c>false</c>.</returns>
        public async Task<bool> GetKeyExistsAsync(string key)
        {
            var response = await HttpClient.GetAsync($"{ApiRoute}/KeyExists/{key}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<bool>(content);
            return result;
        }

        #endregion

        #region properties

        /// <inheritdoc />
        protected override string ApiRoute => "Asset";

        #endregion
    }
}