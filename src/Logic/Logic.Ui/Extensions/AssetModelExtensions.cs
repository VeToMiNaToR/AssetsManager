namespace devdeer.AssetsManager.Logic.Ui.Extensions
{
    using Logic.Models;

    using Models;

    /// <summary>
    /// Provides extension methods for the type <see cref="AssetModel" />.
    /// </summary>
    public static class AssetModelExtensions
    {
        #region methods

        /// <summary>
        /// Converts the given <paramref name="model" /> to the model used in the UI.
        /// </summary>
        /// <param name="model">The model from the backend.</param>
        /// <returns>The model for the frontend.</returns>
        public static AssetDialogModel ToDialogModel(this AssetModel model)
        {
            return new AssetDialogModel
            {
                Key = model.AssetKey,
                Model = model.ModelName,
                Aquisition = model.AcquisitionDate.ToDateTime(TimeOnly.MinValue)
            };
        }

        #endregion
    }
}