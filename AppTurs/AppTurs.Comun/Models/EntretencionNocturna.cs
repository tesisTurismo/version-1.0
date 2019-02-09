using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTurs.Comun.Models
{
    public class EntretencionNocturna
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEntretencionNoct { get; set; }
        public string foto { get; set; }
        public string nombre_EntretencionNoct { get; set; }
        public string descripcion_EntretencionNoct { get; set; }
        public string sitio_web { get; set; }
    }
}
