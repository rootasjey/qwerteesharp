using System.Collections.Generic;

namespace Qwerteesharp.Models {
    /// <summary>
    /// Represents an user or design author.
    /// </summary>
    public class User {
        /// <summary>
        /// User's id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User's link.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// User's designs up for voting.
        /// </summary>
        public List<Design> UpForVoting { get; set; }

        /// <summary>
        /// User's designs wich can't be voted anymore.
        /// </summary>
        public List<Design> FinishedVoting { get; set; }

        /// <summary>
        /// User's designs for which he/she voted for.
        /// </summary>
        public List<Design> VotedFor { get; set; }
    }
}
