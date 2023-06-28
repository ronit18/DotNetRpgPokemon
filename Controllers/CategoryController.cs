using DotNetRpgPokemon.Interfaces;
using DotNetRpgPokemon.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DotNetRpgPokemon.Dto;

namespace DotNetRpgPokemon.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;
		public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public IActionResult GetCategories()
		{
			try
			{
				var Categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				return Ok(Categories);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500, "Internal server error. Please try again later.");
			}
		}

		[HttpGet("{categoryId}")]
		[ProducesResponseType(200, Type = typeof(Category))]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		[ProducesResponseType(500)]
		public IActionResult GetCategory(int categoryId)
		{
			try
			{
				if (!_categoryRepository.CategoryExists(categoryId))
					return NotFound();

				var category = _mapper.Map<CategoryDto>(_categoryRepository.CategoryExists(categoryId));

				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				return Ok(category);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500, "Internal server error. Please try again later.");
			}
		}

		[HttpGet("pokemon/{categoryId}")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		[ProducesResponseType(500)]
		public IActionResult GetPokemonByCategory(int categoryId)
		{
			try
			{
				if (!_categoryRepository.CategoryExists(categoryId))
					return NotFound();

				var pokemons = _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonByCategory
				(categoryId));

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


	}
}