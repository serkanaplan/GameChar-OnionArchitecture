using GameChar.Domain.ValueObjects;

namespace GameChar.Application.DTOs;

public class CharacterDto
{
    public CharacterDto() => Skills = [];
    public string Id { get; set; }
    public string Name { get; set; }
    public int Health { get; set; }
    public int Armor { get; set; }
    public Location Location { get; set; }
    public List<SkillDto?>? Skills { get; set; }
}
