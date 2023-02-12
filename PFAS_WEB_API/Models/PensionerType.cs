using System;
using System.Collections.Generic;

namespace PFAS_WEB_API.Models;

public partial class PensionerType
{
    public Guid PensionerTypeId { get; set; }

    public string PensionerType1 { get; set; } = null!;

    public Guid DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<File> Files { get; } = new List<File>();
}
