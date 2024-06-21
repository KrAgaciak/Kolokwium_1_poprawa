using Kolokwium_1.DTOs;

namespace Kolokwium_1.Repositories;

public interface IAnimalRepository
{
    public Task<bool> DoesAnimalExist(int id);
    public Task<DTOs.DTOs.AnimalDto> GetAnimal(int id);
    public Task<bool> DoesOwnerExist(int id);
    public Task<bool> DoesProceduresExist(int id);
    public Task<bool> DoesAnimalClassExist(int id);
    public Task PostAnimal(NewAnimalDTO newAnimal);

}