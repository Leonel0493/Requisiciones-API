using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Requisiciones.Models
{
    [Table("c_Puesto")]
    public class Positions
    {
        [Key]
        public int idPuesto { get; set; }
        public string puesto { get; set; }
    }
}
