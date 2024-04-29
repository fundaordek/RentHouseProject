using Application.Features.RentTypes.Commands.Create;
using Application.Features.RentTypes.Commands.Delete;
using Application.Features.RentTypes.Commands.Update;
using Application.Features.RentTypes.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.RentTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RentType, CreateRentTypeCommand>().ReverseMap();
        CreateMap<RentType, CreatedRentTypeResponse>().ReverseMap();
        CreateMap<RentType, UpdateRentTypeCommand>().ReverseMap();
        CreateMap<RentType, UpdatedRentTypeResponse>().ReverseMap();
        CreateMap<RentType, DeleteRentTypeCommand>().ReverseMap();
        CreateMap<RentType, DeletedRentTypeResponse>().ReverseMap();
        CreateMap<RentType, GetByIdRentTypeResponse>().ReverseMap();
    }
}