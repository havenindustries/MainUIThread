using MainUIThread.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MainUIThread
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TimeWaster waster = new TimeWaster();

            MessagingCenter.Subscribe<string>(this, "TestMessage", (sender) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    lblMessage.Text = sender;
                });

            });

            Task.Run(async () =>
            {
                await waster.WasteTime();
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "TestMessage");
        }




    }
}
