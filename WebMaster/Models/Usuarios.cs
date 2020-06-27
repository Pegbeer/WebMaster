using System;
using System.Collections.Generic;

namespace WebMaster.Models
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Rol { get; set; }
        public string Password { get; set; }
    }
}
