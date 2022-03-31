namespace SampleArchitecture.Models
{
    /// <summary>
    /// The model.
    /// </summary>
    /// <typeparam name="TKey">The type of key.</typeparam>
    public interface IModel<TKey>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        TKey Id { get; set; }
    }
}