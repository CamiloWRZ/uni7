namespace uni7.Domain
{
    public class Pet
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal? Weight { get; set; }
        public int? Age { get; set; } 
        public Breed Breed { get; set; }
        public int BreedID { get; set; }
        public List<Owner> Owners { get; set;} = new List<Owner>();
    }
}
