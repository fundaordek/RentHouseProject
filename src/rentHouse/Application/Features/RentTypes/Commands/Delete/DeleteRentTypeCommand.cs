using Application.Features.RentTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RentTypes.Commands.Delete;

public class DeleteRentTypeCommand : IRequest<DeletedRentTypeResponse>
{
    public int Id { get; set; }

    public class DeleteRentTypeCommandHandler : IRequestHandler<DeleteRentTypeCommand, DeletedRentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentTypeRepository _rentTypeRepository;
        private readonly RentTypeBusinessRules _rentTypeBusinessRules;

        public DeleteRentTypeCommandHandler(IMapper mapper, IRentTypeRepository rentTypeRepository,
                                         RentTypeBusinessRules rentTypeBusinessRules)
        {
            _mapper = mapper;
            _rentTypeRepository = rentTypeRepository;
            _rentTypeBusinessRules = rentTypeBusinessRules;
        }

        public async Task<DeletedRentTypeResponse> Handle(DeleteRentTypeCommand request, CancellationToken cancellationToken)
        {
            RentType? rentType = await _rentTypeRepository.GetAsync(predicate: rt => rt.Id == request.Id, cancellationToken: cancellationToken);
            await _rentTypeBusinessRules.RentTypeShouldExistWhenSelected(rentType);

            await _rentTypeRepository.DeleteAsync(rentType!);

            DeletedRentTypeResponse response = _mapper.Map<DeletedRentTypeResponse>(rentType);
            return response;
        }
    }
}