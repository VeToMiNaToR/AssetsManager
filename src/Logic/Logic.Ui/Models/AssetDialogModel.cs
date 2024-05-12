namespace devdeer.AssetsManager.Logic.Ui.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Is used as a model for asset-related operations in the UI.
    /// </summary>
    public class AssetDialogModel
    {
        #region properties

        [Required]
        public string Model { get; set; } = default!;

        public string? Key { get; set; }

        public DateTime? Aquisition { get; set; }

        #endregion
    }
}