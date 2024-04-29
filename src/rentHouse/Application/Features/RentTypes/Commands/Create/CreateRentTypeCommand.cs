using Application.Features.RentTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RentTypes.Commands.Create;

public class CreateRentTypeCommand : IRequest<CreatedRentTypeResponse>
{
    public string Name { get; set; }

    public class CreateRentTypeCommandHandler : IRequestHandler<CreateRentTypeCommand, CreatedRentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentTypeRepository _rentTypeRepository;
        private readonly RentTypeBusinessRules _rentTypeBusinessRules;

        public CreateRentTypeCommandHandler(IMapper mapper, IRentTypeRepository rentTypeRepository,
                                         RentTypeBusinessRules rentTypeBusinessRules)
        {
            _mapper = mapper;
            _rentTypeRepository = rentTypeRepository;
            _rentTypeBusinessRules = rentTypeBusinessRules;
        }

        public async Task<CreatedRentTypeResponse> Handle(CreateRentTypeCommand request, CancellationToken cancellationToken)
        {
            RentType rentType = _mapper.Map<RentType>(request);

            await _rentTypeRepository.AddAsync(rentType);

            CreatedRentTypeResponse response = _mapper.Map<CreatedRentTypeResponse>(rentType);
            return response;
        }
    }
}