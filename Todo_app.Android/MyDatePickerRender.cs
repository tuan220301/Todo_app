using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CustomRenderer.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Todo_app;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
[assembly: ExportRenderer(typeof(MyDatePicker), typeof(MyDatePickerRenderer))]
namespace CustomRenderer.Android
{
    class MyDatePickerRenderer : DatePickerRenderer
    {
        public MyDatePickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);

            Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);

        }
    }
}