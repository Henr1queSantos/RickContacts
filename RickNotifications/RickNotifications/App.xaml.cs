﻿using RickContacts;
using RickNotifications.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RickNotifications
{
    public partial class App : Application
    {
        public App()
        {
            //InitializeComponent();

            MainPage = new NavigationPage(new LoginView());
            //MainPage = new LoginView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
