using Microsoft.EntityFrameworkCore;
using Menu.Models;

namespace Menu.Data
{
    public class MenuContext: DbContext
    {
        public MenuContext( DbContextOptions<MenuContext> options) :base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.Dishingredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.Dishingredients).HasForeignKey(i => i.IngredientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id =1, Name="Margheritta", Price=7.50, ImageUrl= "https://ooni.com/cdn/shop/articles/20220211142347-margherita-9920_ba86be55-674e-4f35-8094-2067ab41a671.jpg?crop=center&height=800&v=1737104576&width=800" }
                
                );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name ="Tomato Sauce"},
                new Ingredient { Id = 2, Name = "Mozzarella"});
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2 });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes {  get; set; }
        public DbSet<Ingredient> Ingredients {  get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
