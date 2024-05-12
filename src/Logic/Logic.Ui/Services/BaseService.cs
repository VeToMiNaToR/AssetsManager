namespace devdeer.AssetsManager.Logic.Ui.Services
{
    using System.Net;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Abstract base type for all frontend services.
    /// </summary>
    public abstract class BaseService<TModel>
    {
        #region constructors and destructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="httpClient">The ready-to-use HTTP client.</param>
        public BaseService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        #endregion

        #region methods

        /// <summary>
        /// Sends a POST request to the API to create a new entry using the data in <paramref name="model" />.
        /// </summary>
        /// <param name="model">The data for the creation.</param>
        /// <returns>The created element data or <c>null</c> if something went wrong.</returns>
        public async Task<TModel?> CreateAsync(TModel model)
        {
            var body = JsonSerializer.Serialize(model, JsonSerializerOptions);
            var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(ApiRoute, requestContent)
                .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TModel>(content, JsonSerializerOptions);
        }

        /// <summary>
        /// Retrieves a list of all elements from the API using the default GET endpoint.
        /// </summary>
        /// <returns>The list of elements.</returns>
        public async Task<IReadOnlyCollection<TModel>> GetAllAsync()
        {
            var response = await HttpClient.GetAsync(ApiRoute)
                .ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return [];
            }
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TModel[]>(content, JsonSerializerOptions) ?? [];
            return result.AsReadOnly();
        }

        #endregion

        #region properties

        /// <summary>
        /// The options for JSON serialization.
        /// </summary>
        protected JsonSerializerOptions JsonSerializerOptions { get; } = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };

        /// <summary>
        /// The route at the backend API to which this service is communicating to.
        /// </summary>
        protected abstract string ApiRoute { get; }

        /// <summary>
        /// The injected HTTP client.
        /// </summary>
        protected HttpClient HttpClient { get; }

        #endregion
    }
}