﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinFirebaseAuth.ViewModel;

namespace XamarinFirebaseAuth
{
    public partial class GreetingPage : ContentPage
    {
        public GreetingPage()
        {
            InitializeComponent();
            BindingContext = new GreetingPageViewModel();
        }
    }
}
