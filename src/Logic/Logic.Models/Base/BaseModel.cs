namespace Devdeer.AssetsManager.Logic.Models.Base
{
    using System;
    using System.Linq;

    using devdeer.Libraries.Abstractions.Interfaces;

    /// <summary>
    /// Abstract base class for all models that represent database entities.
    /// </summary>
    public class BaseModel : IModel<long>
    {
        #region explicit interfaces

        /// <inheritdoc />
        public int CompareTo(object? obj)
        {
            if (obj is IModel<long> other)
            {
                return CompareTo(other);
            }
            throw new InvalidOperationException("Cannot compare to object of this type.");
        }

        /// <inheritdoc />
        public int CompareTo(IModel<long>? other)
        {
            return other == null ? -1 : Id.CompareTo(other.Id);
        }

        /// <inheritdoc />
        public bool Equals(IModel<long>? other)
        {
            return other != null && Id == other.Id;
        }

        /// <inheritdoc />
        public long Id { get; set; }

        #endregion
    }
}