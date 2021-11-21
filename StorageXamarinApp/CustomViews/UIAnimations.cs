using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StorageXamarinApp.CustomViews
{
    public static class UIAnimations
    {
        public async static void AnimateInOutScale(Button button, double scale = 1.2)
        {
            await button.ScaleTo(scale, 250, Easing.CubicOut);
            await button.ScaleTo(1, 350, Easing.SinIn);
        }
        public async static void AnimateClickScale(Button button, double scale = 1.2)
        {
            await button.ScaleTo(scale, 150);
            await button.ScaleTo(1, 150);
        }
    }
}
