using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Driver : BaseEntity
{

    public string? Name { get; set; }

    public int? Age { get; set; }

    public virtual ICollection<Team> IdTeams { get; set; } = new List<Team>();
}
