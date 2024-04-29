using Application.Features.Rentals.Commands.Create;
using Application.Features.Rentals.Commands.Delete;
using Application.Features.Rentals.Commands.Update;
using Application.Features.Rentals.Queries.GetById;
using AutoMapper;
using Domain.Entities;


namespace Application.Features.Rentals.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Rental, CreateRentalCommand>().ReverseMap();
        CreateMap<Rental, CreatedRentalResponse>().ReverseMap();
        CreateMap<Rental, UpdateRentalCommand>().ReverseMap();
        CreateMap<Rental, UpdatedRentalResponse>().ReverseMap();
        CreateMap<Rental, DeleteRentalCommand>().ReverseMap();
        CreateMap<Rental, DeletedRentalResponse>().ReverseMap();
        CreateMap<Rental, GetByIdRentalResponse>().ReverseMap();
    }
}