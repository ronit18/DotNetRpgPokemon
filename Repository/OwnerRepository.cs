using DotNetRpgPokemon.Data;
using DotNetRpgPokemon.Interfaces;
using DotNetRpgPokemon.Models;

namespace DotNetRpgPokemon
{
	public class OwnerRepository : IOwnerRepository

	{
		private readonly DataContext _context;
		public OwnerRepository(DataContext context)
		{
			_context = context;

		}
		Owner IOwnerRepository.GetOwnerById(int id)
		{
			return _context.Owners.Where(o => o.Id == id).FirstOrDefault();
		}

		ICollection<Owner> IOwnerRepository.GetOwnerOfAPokemon(int pokeId)
		{
			return _context.PokemonOwners.Where(po => po.PokemonId == pokeId).Select(o => o.Owner).ToList();

		}

		ICollection<Owner> IOwnerRepository.GetOwners()
		{
			return _context.Owners.ToList();

		}

		ICollection<Pokemon> IOwnerRepository.GetPokemonByOwner(int ownerId)
		{
			return _context.PokemonOwners.Where(po => po.Owner.Id == ownerId).Select(p => p.Pokemon).ToList();
		}

		bool IOwnerRepository.OwnerExists(int ownerId)
		{
			return _context.Owners.Any(o => o.Id == ownerId);
		}
	}
}