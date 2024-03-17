using Microsoft.EntityFrameworkCore;
using uni7.Domain;

namespace uni7.DataSource
{
    public class UniDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; } 
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Species> Species { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Uni7");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasData(
                new Owner() { Id = 1, Name = "John" },
                new Owner() { Id = 2, Name = "Alice" },
                new Owner() { Id = 3, Name = "Bob" },
                new Owner() { Id = 4, Name = "Emily" },
                new Owner() { Id = 5, Name = "Michael" },
                new Owner() { Id = 6, Name = "Sarah" },
                new Owner() { Id = 7, Name = "David" }
                    );
            modelBuilder.Entity<Breed>().HasData(
                new Breed() { Id = 1, Name = "Golden Retriever", IdealMaxWeight = 25.0m, SpeciesID = 1 },
                new Breed() { Id = 2, Name = "Siamese", IdealMaxWeight = 12.0m, SpeciesID = 2 },
                new Breed() { Id = 3, Name = "Parrot", IdealMaxWeight = 2.0m, SpeciesID = 3 },
                new Breed() { Id = 4, Name = "Labrador", IdealMaxWeight = 30.0m, SpeciesID = 1 },
                new Breed() { Id = 5, Name = "Persian", IdealMaxWeight = 15.0m, SpeciesID = 2 },
                new Breed() { Id = 6, Name = "Canary", IdealMaxWeight = 0.5m, SpeciesID = 3 },
                new Breed() { Id = 7, Name = "Poodle", IdealMaxWeight = 20.0m, SpeciesID = 1 },
                new Breed() { Id = 8, Name = "Maine Coon", IdealMaxWeight = 14.0m, SpeciesID = 2 },
                new Breed() { Id = 9, Name = "Cockatoo", IdealMaxWeight = 1.5m, SpeciesID = 3 },
                new Breed() { Id = 10, Name = "Bulldog", IdealMaxWeight = 28.0m, SpeciesID = 1 }
                );
            modelBuilder.Entity<Species>().HasData(
                new Species() { Id = 1, Name = "Dog" },
                new Species() { Id = 2, Name = "Cat" },
                new Species() { Id = 3, Name = "Bird" }
                );
            modelBuilder.Entity<Pet>().HasData(
                new Pet() { Id = 1, Name = "Pet1", Weight = 10.5m, Age = 2, BreedID = 1 },
                new Pet() { Id = 2, Name = "Pet2", Weight = 15.0m, Age = 3, BreedID = 2 },
                new Pet() { Id = 3, Name = "Pet3", Weight = 8.0m, Age = 1, BreedID = 3 },
                new Pet() { Id = 4, Name = "Pet4", Weight = 20.0m, Age = 4, BreedID = 4 },
                new Pet() { Id = 5, Name = "Pet5", Weight = 12.5m, Age = 2, BreedID = 5 },
                new Pet() { Id = 6, Name = "Pet6", Weight = 5.0m, Age = 1, BreedID = 6 },
                new Pet() { Id = 7, Name = "Pet7", Weight = 18.0m, Age = 3, BreedID = 7 },
                new Pet() { Id = 8, Name = "Pet8", Weight = 14.0m, Age = 2, BreedID = 8 },
                new Pet() { Id = 9, Name = "Pet9", Weight = 7.5m, Age = 1, BreedID = 9 },
                new Pet() { Id = 10, Name = "Pet10", Weight = 22.0m, Age = 4, BreedID = 10 }
                );
                
                 modelBuilder.Entity("OwnerPet").HasData(
                new[] {
                    new { OwnersId = 1, PetsId = 1},
                    new { OwnersId = 1, PetsId = 2},
                    new { OwnersId = 2, PetsId = 3},
                    new { OwnersId = 2, PetsId = 4},
                    new { OwnersId = 3, PetsId = 5},
                    new { OwnersId = 4, PetsId = 6},
                    new { OwnersId = 4, PetsId = 7 }
                    }
                );
        }
    }
}
