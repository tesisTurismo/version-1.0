using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AppTurs.Comun.Models
{
    public class CentroSalud
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCentroSalud { get; set; }
        public string foto { get; set; }
        public string nombre_CentroSalud { get; set; }
        public string descripcion_CentroSalud { get; set; }
        public string sitio_web { get; set; }
    }
}
