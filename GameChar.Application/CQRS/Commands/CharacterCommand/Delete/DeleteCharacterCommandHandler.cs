using GameChar.Application.Abstractions.Repositories.CharacterRepository;
using MediatR;

namespace GameChar.Application.CQRS.Commands.CharacterCommand.Delete;

public class DeleteCharacterCommandHandler(ICharacterWriteRepository characterRepository) : IRequestHandler<DeleteCharacterCommand, bool>
{
    private readonly ICharacterWriteRepository _characterRepository = characterRepository;

    public async Task<bool> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
    {
        await _characterRepository.RemoveAsync(request.Id);
        await _characterRepository.SaveAsync();
        return true; // Silme işlemi başarılı
    }
}
