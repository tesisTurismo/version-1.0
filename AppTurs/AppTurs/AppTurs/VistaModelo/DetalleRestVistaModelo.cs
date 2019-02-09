using AppTurs.Comun.Models;
using AppTurs.Servicios;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTurs.VistaModelo
{
    public class DetalleRestVistaModelo:BaseVistaModelo
    {
        private Restaurante restaurante;
        private ImageSource imageSource;
        private ApiServicio apiServicio;
        private bool isEnabled;
        private bool isRunning;

        public Restaurante Restaurante
        {

            get { return this.restaurante; }
            set { this.SetValue(ref this.restaurante, value); }
        }

        public ImageSource ImageSource
        {
            get { return this.imageSource; }
            set { this.SetValue(ref this.imageSource, value); }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }

        public DetalleRestVistaModelo(Restaurante restaurante)
        {
            this.restaurante = restaurante;
            this.apiServicio = new ApiServicio();
            this.IsEnabled = true;
            this.ImageSource = restaurante.imagenApp;
        }






    }
}
