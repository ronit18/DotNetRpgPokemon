namespace dotNetPokemon.Models
{
	public class Pokemon
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime BirthDay { get; set; }

		public ICollection<Review> Reviews { get; set; }

		public ICollection<PokemonOwner> PokemonOwners { get; set; }
		public ICollection<PokemonCategory> PokemonCategory { get; set; }

	}

}