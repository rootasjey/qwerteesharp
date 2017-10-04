namespace Qwerteesharp.Models {
    /// <summary>
    /// A price is composed of a value and a currency.
    /// </summary>
    public class Price {
        /// <summary>
        /// Value currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Actual price.
        /// </summary>
        public float Value { get; set; }
    }
}
