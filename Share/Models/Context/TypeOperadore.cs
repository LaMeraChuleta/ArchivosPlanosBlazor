using System;
using System.Collections.Generic;

namespace Share.Models.Context
{
    public partial class TypeOperadore
    {
        public int IdOperador { get; set; }
        public string? NumCapufe { get; set; }
        public string? NumGea { get; set; }
        public string? NomOperador { get; set; }
        public int PlazaId { get; set; }

        public virtual TypePlaza Plaza { get; set; } = null!;
    }
}
