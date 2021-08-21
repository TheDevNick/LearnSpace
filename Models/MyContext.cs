
using Microsoft.EntityFrameworkCore;

namespace LearnSpace.Models
{
    public class MyContext : DbContext
    {
        public MyContext (DbContextOptions options) : base(options) {}
        public DbSet<User> Users{get;set;}
        public DbSet<Topic> Topics {get;set;}
        public DbSet<Deck> Decks {get;set;}
        public DbSet<Card> Flashcards {get;set;}
        public DbSet<Accomplishment> Accomplishments {get;set;}
    }
}