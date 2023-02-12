using System;
using System.Collections.Generic;

namespace PFAS_WEB_API.Models;

public partial class Unit
{
    public Guid UnitId { get; set; }

    public Guid DepartmentId { get; set; }

    public string UnitName { get; set; } = null!;

    public string UnitDescription { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Staff> Staff { get; } = new List<Staff>();
}
