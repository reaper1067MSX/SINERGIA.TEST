using System;
using System.Collections.Generic;

namespace MainData.TEST.Entities
{
    public partial class Medidas
    {
        public Medidas()
        {
            Producto = new HashSet<Producto>();
        }

        public Guid Id { get; set; }
        public string Alto { get; set; }
        public string Ancho { get; set; }
        public string Peso { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
