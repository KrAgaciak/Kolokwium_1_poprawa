using Kolokwium_1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private readonly IAnimalRepository _repository;
    public AnimalController(IAnimalRepository animalsRepository)
    {
        _repository = animalsRepository;
    }

    [HttpGet("animals/{id}")]
    public async Task<IActionResult> GetAnimalByID(int id)
    {
        if (!await _repository.DoesAnimalExist(id))
            return NotFound($"Animal with given ID - {id} doesn't exist");

        var animal = await _repository.GetAnimal(id);

        return Ok(animal);
    }
}