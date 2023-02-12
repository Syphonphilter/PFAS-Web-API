using System;
using System.Collections.Generic;

namespace PFAS_WEB_API.Models;

public partial class RequestStatus
{
    public Guid RequestStatusId { get; set; }

    public string RequestStatus1 { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public Guid CreatedBy { get; set; }

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
