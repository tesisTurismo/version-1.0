using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTurs.Comun.Models
{
   public class Sucursal_EntretencionNocturna
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idSucursalEntretencionNoct { get; set; }
        public string calle { get; set; }
        public int numero { get; set; }
        public string telefono { get; set; }
        public float latitud { get; set; }
        public float longitud { get; set; }
        public int idEntretencionNoct { get; set; }
        public virtual EntretencionNocturna idEntretNoc { get; set; }
    }
}
