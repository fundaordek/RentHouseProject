using Application.Features.Businesses.Commands.Create;
using Application.Features.Businesses.Commands.Delete;
using Application.Features.Businesses.Commands.Update;
using Application.Features.Businesses.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Businesses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Business, CreateBusinessCommand>().ReverseMap();
        CreateMap<Business, CreatedBusinessResponse>().ReverseMap();
        CreateMap<Business, UpdateBusinessCommand>().ReverseMap();
        CreateMap<Business, UpdatedBusinessResponse>().ReverseMap();
        CreateMap<Business, DeleteBusinessCommand>().ReverseMap();
        CreateMap<Business, DeletedBusinessResponse>().ReverseMap();
        CreateMap<Business, GetByIdBusinessResponse>().ReverseMap();
    }
}