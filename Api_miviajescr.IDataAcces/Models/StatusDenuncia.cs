using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class StatusDenuncia
{
    public int IdStatusDenuncia { get; set; }

    public string StatusDenuncia1 { get; set; } = null!;

    public bool EstaActivo { get; set; }

    public virtual ICollection<Denuncias> Denuncias { get; set; } = new List<Denuncias>();
}
