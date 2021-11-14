using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StorageXamarinApp.CustomViews
{
    public class CustomViewCell: ViewCell
    {
        public static readonly BindableProperty SelectedItemBackhroundColorProperty =
            BindableProperty.Create("SelectedItemBackground", typeof(Color), typeof(CustomViewCell),Color.Default);
        public Color SelectedItemBackgroundColor 
        { 
            get { return (Color)GetValue(SelectedItemBackhroundColorProperty); }
            set { SetValue(SelectedItemBackhroundColorProperty, value); }
        }
    }
}
