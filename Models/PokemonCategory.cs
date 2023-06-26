namespace dotNetPokemon.Models
{
	public class PokemonCategory
	{
		public int Id { get; set; }

		public int CatergoryId { get; set; }

		public Pokemon Pokemon { get; set; }

		public Category Category { get; set; }

		public ICollection<PokemonCategory> PokemonCategories { get; set; }

	}

}