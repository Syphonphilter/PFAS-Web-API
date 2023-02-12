using System;
using System.Collections.Generic;

namespace PFAS_WEB_API.Models;

public partial class AuditLogger
{
    public Guid AuditId { get; set; }

    public Guid StaffId { get; set; }

    public string Action { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public virtual Staff Staff { get; set; } = null!;
}
