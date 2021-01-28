using System;
using System.Collections.Generic;

namespace MainData.TEST.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            BodegaPorProducto = new HashSet<BodegaPorProducto>();
        }

        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public Guid IdProveedor { get; set; }
        public Guid IdCategoria { get; set; }
        public Guid IdMarca { get; set; }
        public string Estado { get; set; }
        public decimal Precio { get; set; }
        public Guid IdMedidas { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual Medidas IdMedidasNavigation { get; set; }
        public virtual Proveedor IdProveedorNavigation { get; set; }
        public virtual ICollection<BodegaPorProducto> BodegaPorProducto { get; set; }
    }
}
