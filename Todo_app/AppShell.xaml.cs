using System;
using System.Collections.Generic;

using Todo_app.Views;

using Xamarin.Forms;

namespace Todo_app
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
          
            Routing.RegisterRoute(nameof(UserDetail), typeof(UserDetail));
            Routing.RegisterRoute(nameof(ListNote), typeof(ListNote));
            
        }
        

    }
    
}
