﻿using RinconDelSaber.Modelo;
using RinconDelSaber.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RinconDelSaber.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageExplorar : ContentPage
	{

        public List<Categoria> oListaCategoria = new List<Categoria>();
        public PageExplorar ()
		{
			InitializeComponent ();
            obtenerCategorias();

        }

        private async void obtenerCategorias()
        {
            Dictionary<string, Categoria> oObjeto = new Dictionary<string, Categoria>();
            oObjeto = await ApiServiceFirebase.ObtenerCategorias();

            List<Categoria> oListaTemp = new List<Categoria>();

            if (oObjeto.Count > 0)
            {
                foreach (KeyValuePair<string, Categoria> item in oObjeto)
                {
                    oListaTemp.Add(new Categoria()
                    {
                        idcategoria = item.Key,
                        nombre = item.Value.nombre,
                        imagen = item.Value.imagen,

                    });
                }
                oListaCategoria = oListaTemp;
            }

            ListViewCategorias.ItemsSource = oListaCategoria;
        }

        private async void ListViewCategorias_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Categoria oCategoria = (Categoria)e.Item;
            await Navigation.PushAsync(new PageProductos(oCategoria.idcategoria));
        }
    }
}