
using System;
using System.Collections.Generic;
using System.Linq;


namespace AppTurs.Respaldo.Models
{
    using System.Web;
    using AppTurs.Comun.Models;
    public class RestauranteView:Restaurante
    
    {
        public HttpPostedFileBase fotoFile { get; set; }
    }
}