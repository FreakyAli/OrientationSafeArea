using Xamarin.Forms;

namespace OrientationExample
{
    public partial class LandscapePage : ContentPage
    {
        public static bool isFullScreen = false;

        public LandscapePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            isFullScreen = true;
            MessagingCenter.Send(this, MessagingCenterConstants.AllowLandscape);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            isFullScreen = false;
            MessagingCenter.Send(this, MessagingCenterConstants.PreventLandscape);
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}