using System.Collections.Generic;

namespace Qwerteesharp.Models {
    /// <summary>
    /// Represents a tee.
    /// </summary>
    public class Tee {
        /// <summary>
        /// List of images' urls (men, women, kids).
        /// </summary>
        public List<string> ImagesUrls { get; set; }

        /// <summary>
        /// Tee's prices.
        /// </summary>
        public Prices Prices { get; set; }
    }
}
