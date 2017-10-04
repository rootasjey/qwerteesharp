using System.Collections.Generic;

namespace Qwerteesharp.Models {
    public class User {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public List<Design> UpForVoting { get; set; }

        public List<Design> FinishedVoting { get; set; }

        public List<Design> VotedFor { get; set; }
    }
}
