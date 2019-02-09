using AppTurs.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTurs.Respaldo.Models
{
    public class LocalDataContext: DataContext
    {
        public System.Data.Entity.DbSet<AppTurs.Comun.Models.Restaurante> Restaurantes { get; set; }

        public System.Data.Entity.DbSet<AppTurs.Comun.Models.Sucursal_Restaurante> Sucursal_Restaurante { get; set; }
        public System.Data.Entity.DbSet<AppTurs.Comun.Models.Hotel> Hotel { get; set; }

        public System.Data.Entity.DbSet<AppTurs.Comun.Models.Sucursal_hotel> Sucursal_hotel { get; set; }

        public System.Data.Entity.DbSet<AppTurs.Comun.Models.EntretencionNocturna> EntretencionNocturna { get; set; }

        public System.Data.Entity.DbSet<AppTurs.Comun.Models.Sucursal_EntretencionNocturna>Sucursal_EntretencionNocturna { get; set; }
        public System.Data.Entity.DbSet<AppTurs.Comun.Models.CentroSalud> CentroSalud { get; set; }

        public System.Data.Entity.DbSet<AppTurs.Comun.Models.Sucursal_CentrosSalud> Sucursal_CentrosSalud { get; set; }
        public System.Data.Entity.DbSet<AppTurs.Comun.Models.Lugar_Turistico> Lugar_Turistico { get; set; }



    }
}