using System;
using System.Collections.Generic;

namespace MainData.TEST.Entities
{
    public partial class HistoricoProducto
    {
        public int Id { get; set; }
        public Guid IdProducto { get; set; }
        public Guid Descripcion { get; set; }
        public Guid IdProveedor { get; set; }
        public Guid IdCategoria { get; set; }
        public Guid IdMarca { get; set; }
        public string Estado { get; set; }
        public decimal Precio { get; set; }
        public Guid IdMedidas { get; set; }
        public DateTime UltimaModificacion { get; set; }
    }
}
