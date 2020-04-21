using System;
using System.Collections.Generic;

namespace WSVentaHdeleon.Models
{
    public partial class Concepto
    {
        public long Id { get; set; }
        public long VentaId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public int ProductoId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
