using System;
using System.Collections.Generic;

namespace PFAS_WEB_API.Models;

public partial class File
{
    public Guid FileId { get; set; }

    public string FileName { get; set; } = null!;

    public string FileCode { get; set; } = null!;

    public Guid FileTypeId { get; set; }

    public Guid PensionTypeId { get; set; }

    public Guid BankId { get; set; }

    public Guid DepartmentId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public Guid? DeletedBy { get; set; }

    public virtual Bank Bank { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<FileStatus> FileStatuses { get; } = new List<FileStatus>();

    public virtual FileType FileType { get; set; } = null!;

    public virtual PensionerType PensionType { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
