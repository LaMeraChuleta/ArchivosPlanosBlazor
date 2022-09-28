using System;
using System.Collections.Generic;

namespace Share.Models.Context
{
    public partial class TypeCarril
    {
        public int IdCarril { get; set; }
        public string? NumGea { get; set; }
        public string? NumCapufe { get; set; }
        public string? NumTramo { get; set; }
        public int PlazaId { get; set; }

        public virtual TypePlaza Plaza { get; set; } = null!;
    }
}
