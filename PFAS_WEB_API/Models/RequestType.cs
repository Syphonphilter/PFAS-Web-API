using System;
using System.Collections.Generic;

namespace PFAS_WEB_API.Models;

public partial class RequestType
{
    public Guid RequestTypeId { get; set; }

    public string Request { get; set; } = null!;

    public Guid CreatedBy { get; set; }

    public DateTime DateCreated { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? DateModified { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
