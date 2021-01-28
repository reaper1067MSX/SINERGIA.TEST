using System;
using System.Collections.Generic;

namespace MainData.TEST.Entities
{
    public partial class BodegaPorProducto
    {
        public Guid IdBodega { get; set; }
        public Guid IdProducto { get; set; }
        public int Existencia { get; set; }

        public virtual Bodega IdBodegaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
