using GameChar.Domain.Common;

namespace GameChar.Domain.Entities;

public class Skill : BaseEntity
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Cooldown { get; set; }
    public Guid CharacterId { get; set; }
    public Character Character { get; set; }
}