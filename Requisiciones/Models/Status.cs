using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Requisiciones.Models
{
    [Table("c_Estado")]
    public class Status
    {
        [Key]
        public int idEstado { get; set; }
        public string estado { get; set; }
    }
}
