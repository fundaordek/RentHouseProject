using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities;
public class Rental : Entity<Guid>
{
    public Guid CustomerId { get; set; }
    public Guid EstateId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime RentalEndDate { get; set; }


    public virtual Customer Customer { get; set; }
    public virtual Estate Estate { get; set; }


}
