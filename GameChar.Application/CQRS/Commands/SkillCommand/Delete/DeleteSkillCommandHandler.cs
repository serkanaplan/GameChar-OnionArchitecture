using GameChar.Application.Abstractions.Repositories.SkillRepository;
using MediatR;

namespace GameChar.Application.CQRS.Commands.SkillCommand.Delete;


public class DeleteSkillCommandHandler(ISkillWriteRepository skillRepository) : IRequestHandler<DeleteSkillCommand, bool>
{
    private readonly ISkillWriteRepository _skillRepository = skillRepository;

    public async Task<bool> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
    {
         await _skillRepository.RemoveAsync(request.Id);
         await _skillRepository.SaveAsync();
        return true;
    }
}