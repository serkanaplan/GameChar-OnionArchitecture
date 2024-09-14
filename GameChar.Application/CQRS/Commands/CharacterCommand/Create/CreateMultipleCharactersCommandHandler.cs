using GameChar.Application.Abstractions.Repositories.CharacterRepository;
using GameChar.Domain.Entities;
using MediatR;

namespace GameChar.Application.CQRS.Commands.CharacterCommand.Create;

public class CreateMultipleCharactersCommandHandler(ICharacterWriteRepository characterRepository) : IRequestHandler<CreateMultipleCharactersCommand, List<Guid>>
{
    private readonly ICharacterWriteRepository _characterRepository = characterRepository;

    public async Task<List<Guid>> Handle(CreateMultipleCharactersCommand request, CancellationToken cancellationToken)
    {
        // CharacterDto listesinden yeni karakterleri oluştur
        var characters = request.CreateCharactersDto.Select(characterDto => new Character
        {
            Name = characterDto.Name,
            Health = characterDto.Health,
            Armor = characterDto.Armor,
            Location = characterDto.Location
        }).ToList();

        // AddRangeAsync ile karakterleri ekle
        await _characterRepository.AddRangeAsync(characters);
        await _characterRepository.SaveAsync();

        // Eklenen karakterlerin ID'lerini geri döndür
        return characters.Select(c => c.Id).ToList();
    }
}
