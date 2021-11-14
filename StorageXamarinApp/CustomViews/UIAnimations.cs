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
        public async static void AnimateInOutScaleRotation(Button button, double scale = 1.2, double rotation = 420)
        {
            await Task.WhenAll(
                button.ScaleTo(scale, 250, Easing.CubicOut),
                button.RotateTo(rotation, 250, Easing.CubicOut));
            await Task.WhenAll(
                button.ScaleTo(1, 350, Easing.SinIn),
                button.RotateTo(360, 350, Easing.SinIn)
                );
        }
        public async static void AnimateClickScale(Button button, double scale = 1.2)
        {
            await button.ScaleTo(scale, 150);
            await button.ScaleTo(1, 150);
        }
    }
}
