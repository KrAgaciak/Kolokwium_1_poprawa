namespace Kolokwium_1.Repositories;

public interface IAnimalRepository
{
    public Task<bool> DoesAnimalExist(int id);
    public Task<DTOs.DTOs.AnimalDto> GetAnimal(int id);

}