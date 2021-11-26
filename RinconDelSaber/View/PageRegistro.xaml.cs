using AppNotas.Modelo;
using RinconDelSaber.Modelo;
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
	public partial class PageRegistro : ContentPage
	{
		public PageRegistro ()
		{
			InitializeComponent ();
		}

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            Usuario oUsuario = new Usuario()
            {
                Nombres = txtNombre.Text,
                Apellidos = txtApellido.Text,
                Documento = txtDocumento.Text,
                Email = txtEmail.Text,
                Clave = txtContrasena.Text
            };

            bool respuesta = await ApiServiceAuthentication.RegistrarUsuario(oUsuario);

            if (respuesta)
            {
                await DisplayAlert("Correcto", "Usuario registrado", "Aceptar");
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Oops", "No se pudo registrar", "Aceptar");
            }
            
        }

        private void TapBackArrow_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void TapLabelTerminosCondiciones_Tapped(object sender, EventArgs e)
        {
            popupTerminosCondiciones.IsVisible = true;
            //await Navigation.PushModalAsync(new PagePopup());
        }

        private void BtnCerrarModal_Clicked(object sender, EventArgs e)
        {
            popupTerminosCondiciones.IsVisible = false;
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PageLogin());

        }
    }
}