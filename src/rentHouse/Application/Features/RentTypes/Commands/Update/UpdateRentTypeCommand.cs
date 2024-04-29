using Application.Features.RentTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RentTypes.Commands.Update;

public class UpdateRentTypeCommand : IRequest<UpdatedRentTypeResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateRentTypeCommandHandler : IRequestHandler<UpdateRentTypeCommand, UpdatedRentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentTypeRepository _rentTypeRepository;
        private readonly RentTypeBusinessRules _rentTypeBusinessRules;

        public UpdateRentTypeCommandHandler(IMapper mapper, IRentTypeRepository rentTypeRepository,
                                         RentTypeBusinessRules rentTypeBusinessRules)
        {
            _mapper = mapper;
            _rentTypeRepository = rentTypeRepository;
            _rentTypeBusinessRules = rentTypeBusinessRules;
        }

        public async Task<UpdatedRentTypeResponse> Handle(UpdateRentTypeCommand request, CancellationToken cancellationToken)
        {
            RentType? rentType = await _rentTypeRepository.GetAsync(predicate: rt => rt.Id == request.Id, cancellationToken: cancellationToken);
            await _rentTypeBusinessRules.RentTypeShouldExistWhenSelected(rentType);
            rentType = _mapper.Map(request, rentType);

            await _rentTypeRepository.UpdateAsync(rentType!);

            UpdatedRentTypeResponse response = _mapper.Map<UpdatedRentTypeResponse>(rentType);
            return response;
        }
    }
}