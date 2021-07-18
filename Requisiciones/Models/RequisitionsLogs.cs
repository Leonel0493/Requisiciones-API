using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Requisiciones.Models
{
    [Table("t_RequisicionesBitacora")]
    public class RequisitionsLogs
    {
        [Key]
        public int idBitacoraReq { get; set; }
        public int? idRequisicion { get; set; }
        public int? idEstadoAnterior { get; set; }
        public int? idEstadoNuevo { get; set; }
        public DateTime? fechaRegistro { get; set; }
        public string observacion { get; set; }
        public int? idEmpleadoRegistra { get; set; }
    }
}
