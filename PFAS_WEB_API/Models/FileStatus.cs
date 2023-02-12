using System;
using System.Collections.Generic;

namespace PFAS_WEB_API.Models;

public partial class FileStatus
{
    public Guid FileStatusId { get; set; }

    public Guid FileId { get; set; }

    public Guid FileStatusTypeId { get; set; }

    public DateTime DateCreated { get; set; }

    public Guid CreatedBy { get; set; }

    public virtual File File { get; set; } = null!;

    public virtual FileStatusType FileStatusType { get; set; } = null!;
}
