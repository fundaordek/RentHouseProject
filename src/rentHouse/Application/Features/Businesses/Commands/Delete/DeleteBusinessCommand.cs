using Application.Features.Businesses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Businesses.Commands.Delete;

public class DeleteBusinessCommand : IRequest<DeletedBusinessResponse>
{
    public Guid Id { get; set; }

    public class DeleteBusinessCommandHandler : IRequestHandler<DeleteBusinessCommand, DeletedBusinessResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusinessRepository _businessRepository;
        private readonly BusinessBusinessRules _businessBusinessRules;

        public DeleteBusinessCommandHandler(IMapper mapper, IBusinessRepository businessRepository,
                                         BusinessBusinessRules businessBusinessRules)
        {
            _mapper = mapper;
            _businessRepository = businessRepository;
            _businessBusinessRules = businessBusinessRules;
        }

        public async Task<DeletedBusinessResponse> Handle(DeleteBusinessCommand request, CancellationToken cancellationToken)
        {
            Business? business = await _businessRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _businessBusinessRules.BusinessShouldExistWhenSelected(business);

            await _businessRepository.DeleteAsync(business!);

            DeletedBusinessResponse response = _mapper.Map<DeletedBusinessResponse>(business);
            return response;
        }
    }
}