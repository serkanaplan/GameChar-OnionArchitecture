namespace GameChar.Application.DTOs;

public class CreateSkillDto
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Cooldown { get; set; }
    public string CharacterId { get; set; }
}
