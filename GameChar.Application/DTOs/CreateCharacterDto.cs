using GameChar.Domain.ValueObjects;

namespace GameChar.Application.DTOs;

public class CreateCharacterDto
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Armor { get; set; }
    public Location Location { get; set; }
}
