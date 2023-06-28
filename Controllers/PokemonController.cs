using DotNetRpgPokemon.Interfaces;
using DotNetRpgPokemon.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DotNetRpgPokemon.Dto;

namespace DotNetRpgPokemon.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PokemonController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly IPokemonRepository _pokemonRepository;
		private readonly IMapper _mapper;
		public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
		{
			_pokemonRepository = pokemonRepository;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public IActionResult GetPokemons()
		{
			try
			{
				var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				return Ok(pokemons);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500, "Internal server error. Please try again later.");
			}
		}

		[HttpGet("{pokeId}")]
		[ProducesResponseType(200, Type = typeof(Pokemon))]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		[ProducesResponseType(500)]
		public IActionResult GetPokemon(int pokeId)
		{
			try
			{
				if (!_pokemonRepository.PokemonExists(pokeId))
					return NotFound();

				var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));

				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				return Ok(pokemon);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500, "Internal server error. Please try again later.");
			}
		}

		[HttpGet("{pokeId}/rating")]
		[ProducesResponseType(200, Type = typeof(decimal))]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		[ProducesResponseType(500)]
		public IActionResult GetPokemonRating(int pokeId)
		{
			try
			{
				if (!_pokemonRepository.PokemonExists(pokeId))
					return NotFound();

				var rating = _pokemonRepository.GetPokemonRating(pokeId);

				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				return Ok(rating);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500, "Internal server error. Please try again later.");
			}
		}


	}
}