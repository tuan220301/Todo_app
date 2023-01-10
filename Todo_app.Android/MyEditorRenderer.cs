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

[assembly: ExportRenderer(typeof(MyEditor), typeof(MyEditorRenderer))]
namespace CustomRenderer.Android
{
    class MyEditorRenderer : EditorRenderer
    {
        public MyEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);

        }
    }
}