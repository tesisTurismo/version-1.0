


namespace AppTurs.VistaModelo
{
    using AppTurs.Comun.Models;
    using AppTurs.Servicios;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using AppTurs.Vistas;
    using Xamarin.Forms;
    public class RestauranteItem:Restaurante
    {
        private ApiServicio apiservicio;
        public RestauranteItem()
        {
            this.apiservicio = new ApiServicio();
        }




        public ICommand DetalleRestaurantesCommand
        {
            get
            {
                return new RelayCommand(DetalleRest);
            }
        }

        private async void DetalleRest()
        {
            VistaPrincipal.GetInstancia().DetalleRestaurante = new DetalleRestVistaModelo(this);
            await Application.Current.MainPage.Navigation.PushAsync(new DetalleRestaurantePage());
        }
    }
}
