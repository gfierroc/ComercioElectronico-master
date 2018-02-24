using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComercioElectronico.Models
{
    public class PagoCarritoModel
    {
        [Key]
        public int IdPago { get; set; }

        [Required]
        public string IdUsuario { get; set; }

        [Required]
        public string FormaPago { get; set; }

        [Required]
        public string CuponPago { get; set; }

        [Required]
        public double Total { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Fecha de pago")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaPago { get; set; }
    }
}