using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Models
{
    public class ProductoModel
    {
        [Key]
        public int IdProducto {get;set;}

        [Required(ErrorMessage ="Nombre requerido")]
        [MaxLength(100, ErrorMessage = "Use un nombre mas corto")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "Descripción requerida.")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500,ErrorMessage = "Use una descripción corta")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage ="Precio requerido")]
        public double PrecioUnitario { get; set; }

        [DisplayName("Imagen")]
        [MaxLength]
        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Fecha de creación")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreación { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Fecha de actualización")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaActualizacion { get; set; }
    }
}