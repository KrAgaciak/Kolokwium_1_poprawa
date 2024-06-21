using Kolokwium_1.DTOs;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnimalByID(int id)
    {
        if (!await _repository.DoesAnimalExist(id))
            return NotFound($"Animal with given ID - {id} doesn't exist");

        var animal = await _repository.GetAnimal(id);

        return Ok(animal);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAnimal(NewAnimalDTO newAnimal)
    {
        if (!await _repository.DoesOwnerExist(newAnimal.OwnerId))
            return NotFound($"Animal with given ID - {newAnimal.OwnerId} doesn't exist");
        // if (!await _repository.DoesAnimalClassExist(newAnimal.Class))
        //     return NotFound($"Animal with given ID - {id} doesn't exist");


        return Ok();
    }
}