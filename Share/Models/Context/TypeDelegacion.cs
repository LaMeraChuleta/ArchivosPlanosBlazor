using System;
using System.Collections.Generic;

namespace Share.Models.Context
{
    public partial class TypeDelegacion
    {
        public TypeDelegacion()
        {
            TypePlazas = new HashSet<TypePlaza>();
        }

        public int IdDelegacion { get; set; }
        public string? NumDelegacion { get; set; }
        public string? NomDelegacion { get; set; }

        public virtual ICollection<TypePlaza> TypePlazas { get; set; }
    }
}
