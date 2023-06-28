using DotNetRpgPokemon.Interfaces;
using DotNetRpgPokemon.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DotNetRpgPokemon.Dto;

namespace DotNetRpgowner.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OwnerController : Controller
	{
		private readonly IOwnerRepository _ownerRepository;
		private readonly IMapper _mapper;
		public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
		{
			_ownerRepository = ownerRepository;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public IActionResult Getowners()
		{
			try
			{
				var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				return Ok(owners);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500, "Internal server error. Please try again later.");
			}
		}

		[HttpGet("{ownerId}")]
		[ProducesResponseType(200, Type = typeof(Owner))]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		[ProducesResponseType(500)]
		public IActionResult Getowner(int ownerId)
		{
			try
			{
				if (!_ownerRepository.OwnerExists(ownerId))
					return NotFound();

				var owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwnerById(ownerId));

				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				return Ok(owner);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500, "Internal server error. Please try again later.");
			}
		}

		[HttpGet("{ownerId}/pokemon")]
		[ProducesResponseType(200, Type = typeof(Owner))]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		[ProducesResponseType(500)]
		public IActionResult GetPokemonByOwner(int ownerId)
		{
			try
			{
				if (!_ownerRepository.OwnerExists(ownerId))
					return NotFound();

				var owner = _mapper.Map<List<PokemonDto>>(_ownerRepository.GetPokemonByOwner(ownerId));

				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				return Ok(owner);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500, "Internal server error. Please try again later.");
			}
		}




	}
}