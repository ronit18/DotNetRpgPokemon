using DotNetRpgPokemon.Models;
using DotNetRpgPokemon.Data;

namespace DotNetRpgPokemon.Interfaces
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly DataContext _context;
		public CategoryRepository(DataContext context)
		{
			_context = context;
		}

		public ICollection<Category> GetCategories()
		{
			return _context.Categories.ToList();
		}

		public Category GetCategory(int id)
		{
			return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
		}

		public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
		{

			return _context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(e => e.Pokemon).ToList();

		}

		public bool CategoryExists(int id)
		{
			return _context.Categories.Any(c => c.Id == id);
		}
	}

}