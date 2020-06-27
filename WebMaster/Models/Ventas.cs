using System;
using System.Collections.Generic;

namespace WebMaster.Models
{
    public partial class Ventas
    {
        public int Id { get; set; }
        public int Correlativo { get; set; }
        public DateTime? Fecha { get; set; }
        public string NomCliente { get; set; }
        public decimal? Monto { get; set; }

        public virtual Productos IdNavigation { get; set; }
    }
}
