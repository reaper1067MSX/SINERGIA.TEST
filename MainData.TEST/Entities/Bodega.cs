using System;
using System.Collections.Generic;

namespace MainData.TEST.Entities
{
    public partial class Bodega
    {
        public Bodega()
        {
            BodegaPorProducto = new HashSet<BodegaPorProducto>();
        }

        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public string Encargado { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<BodegaPorProducto> BodegaPorProducto { get; set; }
    }
}
