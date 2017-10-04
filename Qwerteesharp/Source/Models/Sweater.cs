namespace Qwerteesharp.Models {
    /// <summary>
    /// Represents a sweater.
    /// </summary>
    public class Sweater {
        /// <summary>
        /// Sweater's image's url.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Sweater's prices.
        /// </summary>
        public Prices Prices { get; set; }
    }
}
