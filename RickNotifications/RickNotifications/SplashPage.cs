using RickNotifications.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RickContacts
{
    public class SplashPage : ContentPage
    {
        Image splashImage;
        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "abertura.gif",
                WidthRequest = 100,
                HeightRequest = 100
            };

            AbsoluteLayout.SetLayoutFlags(splashImage, 
                AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage, 
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#000000");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();


            await splashImage.FadeTo(1, 5750, Easing.BounceOut);
            await splashImage.ScaleTo(2, 2500, Easing.CubicInOut);
            await splashImage.ScaleTo(1, 1500, Easing.Linear);
            await splashImage.ScaleTo(3, 2500, Easing.CubicInOut);
            await splashImage.ScaleTo(1, 1500, Easing.Linear);
            await splashImage.RotateTo(45, 500, Easing.Linear);
            await splashImage.RotateTo(90, 500, Easing.Linear);
            await splashImage.RotateTo(120, 500, Easing.Linear);
            await splashImage.RotateTo(180, 500, Easing.Linear);
            await splashImage.RotateTo(270, 500, Easing.Linear);


            //await splashImage.RotateTo(360, 100, Easing.Linear);
            //await splashImage.RotateTo(1, 100, Easing.Linear);
            //await splashImage.RotateTo(360, 100, Easing.Linear);
            //await splashImage.RotateTo(1, 100, Easing.Linear);
            //await splashImage.RotateTo(360, 100, Easing.Linear);
            //await splashImage.RotateTo(1, 100, Easing.Linear);
            //await splashImage.RotateTo(360, 100, Easing.Linear);
            //await splashImage.RotateTo(1, 100, Easing.Linear);
            //await splashImage.RotateTo(360, 100, Easing.Linear);
            //await splashImage.RotateTo(1, 100, Easing.Linear);
            //await splashImage.RotateTo(360, 100, Easing.Linear);
            //await splashImage.RotateTo(1, 100, Easing.Linear);


            Application.Current.MainPage = new NavigationPage(new LoginView());
               

        }
    }
}
