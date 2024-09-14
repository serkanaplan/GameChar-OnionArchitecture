using GameChar.Application.Abstractions.Repositories.CharacterRepository;
using MediatR;

namespace GameChar.Application.CQRS.Commands.CharacterCommand.Update;

public class UpdateCharacterCommandHandler(ICharacterWriteRepository writeRepository,ICharacterReadRepository readRepository) : IRequestHandler<UpdateCharacterCommand, bool>
{
    private readonly ICharacterWriteRepository _writeRepository = writeRepository;
    private readonly ICharacterReadRepository _readRepository = readRepository;

    public async Task<bool> Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = await _readRepository.GetByIdAsync(request.Id);

        if (character == null)
            return false;

        // Güncelleme işlemi
        character.Name = request.Name;
        character.Health = request.Health;
        character.Armor = request.Armor;
        character.Location = request.Location;

        _writeRepository.Update(character);
        await _writeRepository.SaveAsync();

        return true;
    }
}
