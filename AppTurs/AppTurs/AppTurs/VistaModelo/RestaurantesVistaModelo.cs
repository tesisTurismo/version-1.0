using System;
using System.Collections.Generic;
using System.Text;


namespace AppTurs.VistaModelo
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using AppTurs.Comun.Models;
    using AppTurs.Servicios;
    using Xamarin.Forms;
    using GalaSoft.MvvmLight.Command;
    using System.Linq;
    using Vistas;
    using System.Threading.Tasks;

    public class RestaurantesVistaModelo : BaseVistaModelo
    {
        

        private ApiServicio apiServicio;

        private bool isRefreshing;

        private ObservableCollection<RestauranteItem> rest;
        public ObservableCollection<RestauranteItem> restaurantes
        {
            get { return this.rest; }
            set { this.SetValue(ref this.rest, value); }
        }
        private string filtro;

        public string Filtro
        {
            get { return this.filtro; }
            set
            {
                this.filtro = value;
                this.RefreshList();
            }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }

        }
        public RestaurantesVistaModelo()
        {
            this.apiServicio = new ApiServicio();
            this.LoadRestaurantes();
        }

        private async void LoadRestaurantes()
        {
            this.IsRefreshing = true;
            var conexion = await this.apiServicio.ValidacionInternet();
            if (!conexion.respExitosa)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", conexion.mensaje,"Aceptar");
                return;
            }
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefijo = Application.Current.Resources["UrlPrefix"].ToString();
            var controlador = Application.Current.Resources["UrlRestauranteController"].ToString();
            var response = await this.apiServicio.mostrarLista<Restaurante>(url, prefijo, controlador);

            if (!response.respExitosa)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.mensaje, "Aceptar");
                return;
            }

            this.myRestaurante = (List<Restaurante>)response.resultado;
            this.RefreshList();
            this.IsRefreshing = false;
        }
        
        public void RefreshList()
        {
            if (string.IsNullOrEmpty(this.Filtro))
            {
                var mylistaRVM = this.myRestaurante.Select(p => new RestauranteItem
                {
                    idrestaurante=p.idrestaurante,
                    foto=p.foto,
                    nombre_rest=p.nombre_rest,
                    descripcion_rest=p.descripcion_rest,
                    sitio_web=p.sitio_web,




                });
                this.restaurantes = new ObservableCollection<RestauranteItem>(
                    mylistaRVM.OrderBy(p => p.nombre_rest));
            }
            else
            {

                var mylistaRVM = this.myRestaurante.Select(p => new RestauranteItem
                {
                    idrestaurante = p.idrestaurante,
                    foto = p.foto,
                    nombre_rest = p.nombre_rest,
                    descripcion_rest = p.descripcion_rest,
                    sitio_web = p.sitio_web,




                }).Where(p => p.nombre_rest.ToLower().Contains(this.filtro.ToLower())).ToList();
                this.restaurantes = new ObservableCollection<RestauranteItem>(
                    mylistaRVM.OrderBy(p => p.nombre_rest));



            }
        }

        public List<Restaurante> myRestaurante { get; set; }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(RefreshList);
            }
        }

       

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadRestaurantes);
            }
        }


    }
}
