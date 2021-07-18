using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Requisiciones.Models
{
    [Table("c_Empleado")]
    public class Employees
    {
        [Key]
        public int idEmpleado { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public int idPuesto { get; set; }
        public bool esActivo { get; set; }
    }
}
