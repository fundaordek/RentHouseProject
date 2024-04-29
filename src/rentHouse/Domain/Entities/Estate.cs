using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Estate : Entity<Guid>
{
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public double Area { get; set; }
    public int RoomCount { get; set; }
    public int Floor { get; set; }
    public int BuildingFloor { get; set; }
    public string HeatingType { get; set; }
    public int RentTypeId { get; set; }
    public Guid BusinessId { get; set; } 
    public Guid CustomerId { get; set; }


    public virtual Business Business { get; set; }
    public virtual RentType RentType { get; set; }
    public virtual Customer Customer { get; set; }
    public ICollection<Rental> Rentals { get; set; }



}
