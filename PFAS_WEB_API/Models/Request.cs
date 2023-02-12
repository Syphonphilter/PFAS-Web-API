using System;
using System.Collections.Generic;

namespace PFAS_WEB_API.Models;

public partial class Request
{
    public Guid RequestId { get; set; }

    public Guid FileId { get; set; }

    public Guid RequestedBy { get; set; }

    public DateTime DateRequested { get; set; }

    public Guid RequestTypeId { get; set; }

    public Guid RequestStatusId { get; set; }

    public Guid? RequestProcessedBy { get; set; }

    public virtual File File { get; set; } = null!;

    public virtual RequestStatus RequestStatus { get; set; } = null!;

    public virtual RequestType RequestType { get; set; } = null!;
}
