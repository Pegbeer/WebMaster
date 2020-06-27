using System;
using System.Collections.Generic;

namespace WebMaster.Models
{
    public partial class Categorias
    {
        public Categorias()
        {
            Productos = new HashSet<Productos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
