namespace Qwerteesharp.Models {
    public class Design {
        public string Id { get; set; }

        public string Name { get; set; }

        public User Author { get; set; }

        public string ImageUrl { get; set; }

        public string Link { get; set; }

        public int Votes { get; set; }

        public Tee Tee { get; set; }

        public Hoodie Hoodie { get; set; }

        public Sweater Sweater { get; set; }
    }
}
