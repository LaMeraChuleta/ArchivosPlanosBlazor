using System;
using System.Collections.Generic;

namespace Share.Models.Context
{
    public partial class TypePlaza
    {
        public TypePlaza()
        {
            TypeCarrils = new HashSet<TypeCarril>();
            TypeOperadores = new HashSet<TypeOperadore>();
        }

        public int IdPlaza { get; set; }
        public string? NumPlaza { get; set; }
        public string? NomPlaza { get; set; }
        public int DelegacionId { get; set; }

        public virtual TypeDelegacion Delegacion { get; set; } = null!;
        public virtual ICollection<TypeCarril> TypeCarrils { get; set; }
        public virtual ICollection<TypeOperadore> TypeOperadores { get; set; }
    }
}
