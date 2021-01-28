using System;
using System.Collections.Generic;
using System.Text;


namespace Common.TEST.SharedViewModels.Producto
{
    public class ProductoVM
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string IdProveedor { get; set; }
        public string IdCategoria { get; set; }
        public string IdMarca { get; set; }
        public string Estado { get; set; }
        public decimal Precio { get; set; }
        public string IdMedidas { get; set; }
    }
}
