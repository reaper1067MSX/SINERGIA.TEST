using System;
using System.Collections.Generic;

namespace MainData.TEST.Entities
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Producto = new HashSet<Producto>();
        }

        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
