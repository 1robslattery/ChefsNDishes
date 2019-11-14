using Microsoft.EntityFrameworkCore;
 
namespace ChefNDishes.Models
{
    public class MyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions options) : base(options) { }

		// 'Chef & 'Dish' are tables w/n ChefsNDishes database.
		// 'Chef & 'Dish' are also referenced from public class Chef and Dish w/n their respective .cs files.
		public DbSet<Chef> Chefs {get; set;}
		public DbSet<Dish> Dishes {get; set;}
    }
}