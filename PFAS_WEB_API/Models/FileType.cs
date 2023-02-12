using System;
using System.Collections.Generic;

namespace PFAS_WEB_API.Models;

public partial class FileType
{
    public Guid FileTypeId { get; set; }

    public string FileType1 { get; set; } = null!;

    public Guid CreatedBy { get; set; }

    public DateTime DateCreated { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? DateModified { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual ICollection<File> Files { get; } = new List<File>();
}
