using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Requisiciones.Models
{
    [Table("t_Requisiciones")]
    public class Requisitions
    {
        [Key]
        public int idRequisicion { get; set; }
        public string detalleRequisicion { get; set; }
        public decimal cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal total { get; set; }
        public int idEmpleadoSolicita { get; set; }
        public DateTime fechaSolicita { get; set; }
        public int idEstado { get; set; }
        public DateTime? fechaGraba { get; set; }
    }
}
