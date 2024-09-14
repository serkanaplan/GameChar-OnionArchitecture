namespace GameChar.Application.DTOs;

public class SkillDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Cooldown { get; set; }
    public string CharacterId { get; set; }
    public CharacterDto CharacterDto { get; set; }
}
