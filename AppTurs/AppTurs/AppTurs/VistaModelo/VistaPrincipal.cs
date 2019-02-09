using System;
using System.Collections.Generic;
using System.Text;

namespace AppTurs.VistaModelo
{
    public class VistaPrincipal
    {
        public DetalleRestVistaModelo DetalleRestaurante { get; set; }
        public RestaurantesVistaModelo restaurantes { get; set; }
       
       
        public VistaPrincipal()
        {
            instancia = this;
            this.restaurantes = new RestaurantesVistaModelo();
            
        }

        private static VistaPrincipal instancia;

        public static VistaPrincipal GetInstancia()
        {
            if (instancia==null)
            {
                return new VistaPrincipal();
            }
            return instancia;
        }





    }
}
