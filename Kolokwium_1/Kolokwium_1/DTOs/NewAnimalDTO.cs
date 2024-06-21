namespace Kolokwium_1.DTOs;

public class NewAnimalDTO
{
    public string Name { get; set; } = string.Empty;
    public string Class { get; set; }
    public DateTime AdmissionDate { get; set; }
    public int OwnerId { get; set; }
    public IEnumerable<ProceduresDTO> Procedures { get; set; } = new List<ProceduresDTO>();
}

public class ProceduresDTO
{
    public int ProcedureID { get; set; }
    public DateTime Dtae { get; set; }
}