namespace uni7.Domain
{
    public class Owner
    {
        public int Id { get; set; }
        public required string Name { get; set; }
       
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }

}
