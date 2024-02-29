using Xamarin.Forms;

namespace OrientationExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LandscapePage());
        }
    }
}

