using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Models
{
    public class CarritoModel
    {
        [Key]
        public int IdCarrito { get; set; }

        [Required]
        public string IdUsuario { get; set; }

        public int? IdPago { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        [MinLength(1,ErrorMessage ="Debe seleccionar al menos uno")]
        public int Cantidad { get; set; }

        [DisplayName("Precio por cantidad")]
        public double PrecioXcantidad { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Fecha de compra")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaCompra { get; set; }
    }
}