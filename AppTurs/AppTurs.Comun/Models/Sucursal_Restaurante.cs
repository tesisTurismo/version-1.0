using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTurs.Comun.Models
{
    public class Sucursal_Restaurante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idSucursalRest { get; set; }
        public string calle { get; set; }
        public int numero { get; set; }
        public string telefono { get; set; }
        public float latitud { get; set; }
        public float longitud { get; set; }
        public int idrestaurante { get; set; }
        public virtual Restaurante idRest { get; set; }
    }
}
