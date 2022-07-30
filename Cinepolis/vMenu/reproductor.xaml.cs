using System.ComponentModel;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinepolis.vMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class reproductor : ContentPage
    {
    
        public reproductor(string video__)
        {
            InitializeComponent();
            wb_Video.Source = video__;
            // UriVideoSource uriVideoSurce = new UriVideoSource()
            // {
            //     Uri = video_
            //  };
            //  wb_Video.Source = video_;
            // videoPlayer.Source = uriVideoSurce;
        }

        async void CloseButton_Clicked(System.Object sender, System.EventArgs e)
        {
           // videoPlayer.Pause();
           //
            //await Navigation.PopAsync();
        }

        void videoPlayer_PlayCompletion(System.Object sender, System.EventArgs e)
        {
            //Do what ever you want 

        }
    }
}