using System;
using System.Collections.Generic;

namespace WebMaster.Models
{
    public partial class Productos
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public int? IdCategoria { get; set; }
        public int? Cantidad { get; set; }

        public virtual Categorias IdCategoriaNavigation { get; set; }
        public virtual Ventas Ventas { get; set; }
    }
}
