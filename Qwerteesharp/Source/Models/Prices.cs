namespace Qwerteesharp.Models {
    /// <summary>
    /// Group of prices from different currencies.
    /// </summary>
    public class Prices {
        /// <summary>
        /// Euro price.
        /// </summary>
        public Price EUR { get; set; }

        /// <summary>
        /// England price.
        /// </summary>
        public Price GBP { get; set; }

        /// <summary>
        /// US price.
        /// </summary>
        public Price USD { get; set; }
    }
}
