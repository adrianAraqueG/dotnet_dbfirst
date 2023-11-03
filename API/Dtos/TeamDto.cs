namespace API.Dtos;
public class TeamDto
{
    public string  Name { get; set; }
    public  ICollection<DriverDto> Drivers { get; set; }
}