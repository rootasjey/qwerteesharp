namespace Qwerteesharp.Models {
    /// <summary>
    /// Represents a Hoodie.
    /// </summary>
    public class Hoodie {
        /// <summary>
        /// Hoodie's image's url.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Hoodie's prices.
        /// </summary>
        public Prices Prices { get; set; }
    }
}
