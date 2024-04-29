using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Business : Entity<Guid>
{
    public string Name { get; set; }
    public string AuthorizedPerson { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    public virtual ICollection<Estate> Estates { get; set; }
}
