namespace Qwerteesharp.Models {
    /// <summary>
    /// Represents a design containing a tee, hoodie and a sweater.
    /// </summary>
    public class Design {
        /// <summary>
        /// Design's id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Design's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Design's author.
        /// </summary>
        public User Author { get; set; }

        /// <summary>
        /// Design's URL.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Design's link.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Design's curent votes.
        /// </summary>
        public int Votes { get; set; }

        /// <summary>
        /// True if the design is on its last chance time.
        /// (A new tee more than 24 hours to be bought,
        ///  whereas a last chance design has less than 24 hours)
        /// </summary>
        public bool IsLastChance { get; set; }

        /// <summary>
        /// Design's tee.
        /// </summary>
        public Tee Tee { get; set; }

        /// <summary>
        /// Design's hoodie.
        /// </summary>
        public Hoodie Hoodie { get; set; }

        /// <summary>
        /// Design's sweater.
        /// </summary>
        public Sweater Sweater { get; set; }
    }
}
