using DotNetRpgPokemon.Interfaces;
using DotNetRpgPokemon.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DotNetRpgPokemon.Dto;

namespace DotNetRpgPokemon.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CountryController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly ICountryRepository _countryRepository;
		private readonly IMapper _mapper;
		public CountryController(ICountryRepository countryRepository, IMapper mapper)
		{
			_countryRepository = countryRepository;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public IActionResult GetCountries()
		{
			try
			{
				var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				return Ok(countries);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500, "Internal server error. Please try again later.");
			}
		}

		[HttpGet("{countryId}")]
		[ProducesResponseType(200, Type = typeof(Category))]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		[ProducesResponseType(500)]
		public IActionResult GetCountry(int countryId)
		{
			try
			{
				if (!_countryRepository.CountryExists(countryId))
					return NotFound();

				var country = _mapper.Map<CountryDto>(_countryRepository.CountryExists(countryId));

				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				return Ok(country);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500, "Internal server error. Please try again later.");
			}
		}

		[HttpGet("owners/{ownerId}")]
		[ProducesResponseType(200, Type = typeof(Country))]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		[ProducesResponseType(500)]
		public IActionResult GetCountryByOwner(int ownerId)
		{
			try
			{
				var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(ownerId));

				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				return Ok(country);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500, "Internal server error. Please try again later.");
			}
		}


	}
}