using Application.Features.Estates.Constants;
using Application.Features.Estates.Constants;
using Application.Features.Estates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Estates.Constants.EstatesOperationClaims;

namespace Application.Features.Estates.Commands.Delete;

public class DeleteEstateCommand : IRequest<DeletedEstateResponse>,ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public class DeleteEstateCommandHandler : IRequestHandler<DeleteEstateCommand, DeletedEstateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEstateRepository _estateRepository;
        private readonly EstateBusinessRules _estateBusinessRules;

        public DeleteEstateCommandHandler(IMapper mapper, IEstateRepository estateRepository,
                                         EstateBusinessRules estateBusinessRules)
        {
            _mapper = mapper;
            _estateRepository = estateRepository;
            _estateBusinessRules = estateBusinessRules;
        }

        public async Task<DeletedEstateResponse> Handle(DeleteEstateCommand request, CancellationToken cancellationToken)
        {
            Estate? estate = await _estateRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _estateBusinessRules.EstateShouldExistWhenSelected(estate);

            await _estateRepository.DeleteAsync(estate!);

            DeletedEstateResponse response = _mapper.Map<DeletedEstateResponse>(estate);
            return response;
        }
    }
}