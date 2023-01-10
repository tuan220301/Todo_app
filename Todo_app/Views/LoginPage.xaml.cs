using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_app;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }
        private void goToMain(object sender, EventArgs e) 
        {
            
        }
    }
}