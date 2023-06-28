using AutoMapper;
using DotNetRpgPokemon.Dto;
using DotNetRpgPokemon.Models;

namespace DotNetRpgPokemon.Helper
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Pokemon, PokemonDto>();

			CreateMap<Category, CategoryDto>();

		}

	}
}