using GameChar.Domain.Common;
using GameChar.Domain.ValueObjects;

namespace GameChar.Domain.Entities;

public class Character : BaseEntity
{
    public Character() => Skills = [];
    public string Name { get; set; }
    public int Health { get; set; }
    public int Armor { get; set; }
    public Location Location { get; set; }
    public List<Skill?>? Skills { get; set; }
}
