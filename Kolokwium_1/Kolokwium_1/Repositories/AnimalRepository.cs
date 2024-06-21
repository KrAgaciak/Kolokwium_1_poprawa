using Microsoft.Data.SqlClient;

namespace Kolokwium_1.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private readonly IConfiguration _configuration;
    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    
    public async Task<bool> DoesAnimalExist(int id)
    {
        var query = "SELECT 1 FROM Animal WHERE ID = @ID";

        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        await using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", id);

        await connection.OpenAsync();

        var res = await command.ExecuteScalarAsync();

        return res is not null;
    }
    
    
    public async Task<DTOs.DTOs.AnimalDto> GetAnimal(int id)
    {
	    var query = @"SELECT 
							Animal.ID AS AnimalID,
							Animal.Name AS AnimalName,
							AdmissionDate,
							Owner.ID as OwnerID,
							FirstName,
							LastName,
							Animal_Class.Name AS AnimalClass
						FROM Animal
						JOIN Owner ON Owner.ID = Animal.OwnerID
						JOIN Animal_Class ON Animal_Class.ID = Animal.AnimalClassID
						WHERE Animal.ID = @ID";
	    
	    await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
	    await using SqlCommand command = new SqlCommand();

	    command.Connection = connection;
	    command.CommandText = query;
	    command.Parameters.AddWithValue("@ID", id);
	    
	    await connection.OpenAsync();

	    var reader = await command.ExecuteReaderAsync();

	    var animalID = reader.GetOrdinal("AnimalID");
	    var animalName = reader.GetOrdinal("AnimalName");
	    var admissionDate = reader.GetOrdinal("AdmissionDate");
	    var ownerID = reader.GetOrdinal("OwnerID");
	    var firstName = reader.GetOrdinal("FirstName");
	    var lastName = reader.GetOrdinal("LastName");
	    var animalClass = reader.GetOrdinal("AnimalClass");


	    DTOs.DTOs.AnimalDto animalDto = null;

	    while (await reader.ReadAsync())
	    {
		    animalDto = new DTOs.DTOs.AnimalDto
			    {
				    ID = reader.GetInt32(animalID), Name = reader.GetString(animalName),
				    AnimalClass = reader.GetString(animalClass), AdmissionDate = reader.GetDateTime(admissionDate),
				    Owner = new DTOs.DTOs.OwnerDto
					    {
						    ID = reader.GetInt32(ownerID), FirstName = reader.GetString(firstName),
						    LastName = reader.GetString(lastName)
					    }
			    };
	    }
	    if (animalDto is null) throw new Exception();
	    return animalDto;
    }

}