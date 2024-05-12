namespace devdeer.AssetsManager.Logic.Ui.Extensions
{
    using Logic.Models;

    using Models;

    public static class AssetDialogModelExtensions
    {
        #region methods

        /// <summary>
        /// Converts the given <paramref name="model" /> to the model used in the UI.
        /// </summary>
        /// <param name="model">The model from the backend.</param>
        /// <returns>The model for the frontend.</returns>
        public static AssetModel ToModel(this AssetDialogModel model)
        {
            return new AssetModel
            {
                AssetKey = model.Key,
                ModelName = model.Model,
                AcquisitionDate = new DateOnly(
                    model.Aquisition!.Value.Year,
                    model.Aquisition.Value.Month,
                    model.Aquisition.Value.Day)
            };
        }

        #endregion
    }
}