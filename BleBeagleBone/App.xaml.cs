using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BleBeagleBone.Services;
using BleBeagleBone.Views;

namespace BleBeagleBone
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<ConnectedDeviceStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
