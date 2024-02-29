using System.Collections.Generic;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Xamarin.Forms;

namespace OrientationExample.Droid
{
    [Activity(Label = "OrientationExample", Icon = "@mipmap/icon", Theme = "@style/MainTheme",
        MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            OrientationHandlerSubriptions();
            LoadApplication(new App());
        }

        private void OrientationHandlerSubriptions()
        {
            // Force landscape
            MessagingCenter.Subscribe<LandscapePage>(this, MessagingCenterConstants.AllowLandscape, _ =>
            {
                this.Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
                this.RequestedOrientation = ScreenOrientation.Landscape;
            });

            // Force potrait
            MessagingCenter.Subscribe<LandscapePage>(this, MessagingCenterConstants.PreventLandscape, _ =>
            {
                this.Window.ClearFlags(WindowManagerFlags.Fullscreen);
                this.RequestedOrientation = ScreenOrientation.Portrait;
            });
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
