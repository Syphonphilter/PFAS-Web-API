using System;
using System.Collections.Generic;

namespace PFAS_WEB_API.Models;

public partial class Staff
{
    public Guid StaffId { get; set; }

    public string StaffName { get; set; } = null!;

    public string? PasswordHash { get; set; }

    public Guid? UnitId { get; set; }

    public string? StaffEmail { get; set; }

    public virtual ICollection<AuditLogger> AuditLoggers { get; } = new List<AuditLogger>();

    public virtual Unit? Unit { get; set; }
}
