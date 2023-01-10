using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_app.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo_app.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserDetail : ContentPage
	{
		
		public UserDetail ()
		{
			InitializeComponent ();
			
		}
        protected override void OnAppearing()
		{
			base.OnAppearing();
            

        }

    }
}