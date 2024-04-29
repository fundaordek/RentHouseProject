using Application.Features.Estates.Commands.Create;
using Application.Features.Estates.Commands.Delete;
using Application.Features.Estates.Commands.Update;
using Application.Features.Estates.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Estates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Estate, CreateEstateCommand>().ReverseMap();
        CreateMap<Estate, CreatedEstateResponse>().ReverseMap();
        CreateMap<Estate, UpdateEstateCommand>().ReverseMap();
        CreateMap<Estate, UpdatedEstateResponse>().ReverseMap();
        CreateMap<Estate, DeleteEstateCommand>().ReverseMap();
        CreateMap<Estate, DeletedEstateResponse>().ReverseMap();
        CreateMap<Estate, GetByIdEstateResponse>().ReverseMap();
    }
}