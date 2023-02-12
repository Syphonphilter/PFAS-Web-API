using System;
using System.Collections.Generic;

namespace PFAS_WEB_API.Models;

public partial class Department
{
    public Guid DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<File> Files { get; } = new List<File>();

    public virtual ICollection<PensionerType> PensionerTypes { get; } = new List<PensionerType>();

    public virtual ICollection<Unit> Units { get; } = new List<Unit>();
}
