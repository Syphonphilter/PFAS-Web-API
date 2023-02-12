using System;
using System.Collections.Generic;

namespace PFAS_WEB_API.Models;

public partial class Bank
{
    public Guid BankId { get; set; }

    public string BankName { get; set; } = null!;

    public string BankCode { get; set; } = null!;

    public virtual ICollection<File> Files { get; } = new List<File>();
}
