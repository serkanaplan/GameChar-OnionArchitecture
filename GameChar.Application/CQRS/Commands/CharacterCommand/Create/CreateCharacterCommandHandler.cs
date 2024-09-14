using GameChar.Application.Abstractions.Repositories.CharacterRepository;
using GameChar.Domain.Entities;
using MediatR;

namespace GameChar.Application.CQRS.Commands.CharacterCommand.Create;

public class CreateCharacterCommandHandler(ICharacterWriteRepository characterRepository) : IRequestHandler<CreateCharacterCommand, Guid>
{
    private readonly ICharacterWriteRepository _characterRepository = characterRepository;

    public async Task<Guid> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = new Character
        {
            Name = request.Name,
            Health = request.Health,
            Armor = request.Armor,
            Location = request.Location,
        };

        await _characterRepository.AddAsync(character);
        await _characterRepository.SaveAsync();
        return character.Id; // Yeni oluşturulan karakterin ID'sini döndür
    }
}
