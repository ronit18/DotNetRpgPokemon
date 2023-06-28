using DotNetRpgPokemon.Models;

namespace DotNetRpgPokemon.Interfaces
{
	public interface IOwnerRepository
	{
		ICollection<Owner> GetOwners();
		Owner GetOwnerById(int id);
		ICollection<Owner> GetOwnerOfAPokemon(int pokeId);
		ICollection<Pokemon> GetPokemonByOwner(int ownerId);
		bool OwnerExists(int ownerId);
	}
}