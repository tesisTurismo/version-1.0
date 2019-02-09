
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTurs.Infraestructura
{
    using VistaModelo;
    public class LocalizadorInstancias
    { 
        public VistaPrincipal Main { get; set;}

        public LocalizadorInstancias()
        {
            this.Main = new VistaPrincipal();
        }
    }
}
