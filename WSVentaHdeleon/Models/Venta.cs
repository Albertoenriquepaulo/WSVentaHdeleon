using System;
using System.Collections.Generic;

namespace WSVentaHdeleon.Models
{
    public partial class Venta
    {
        public Venta()
        {
            Concepto = new HashSet<Concepto>();
        }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public decimal? Total { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Concepto> Concepto { get; set; }
    }
}
