using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTurs.Comun.Models
{
    public class Restaurante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idrestaurante { get; set; }
        public string foto { get; set; }
        public string nombre_rest { get; set; }
        public string descripcion_rest { get; set; }
        public string sitio_web { get; set; }

        public string imagenApp
        {
            get
            {
                if (string.IsNullOrEmpty(this.foto))
                {
                    return "noImagen";
                }
                 
                return $"https://apptursrespaldo20190127021350.azurewebsites.net/{this.foto.Substring(1)}";
            }
        }
        public override string ToString()
        {
            return this.nombre_rest;
        }
    }
}
