using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTurs.Comun.Models
{
    public class Lugar_Turistico
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idLugarTuristico { get; set; }
        public string foto { get; set; }
        public string nombre_LugarTuristico { get; set; }
        public string descripcion_LugarTuristico { get; set; }
        public string sitio_web { get; set; }
        public float latitud { get; set; }
        public float longitud { get; set; }
    }
}
