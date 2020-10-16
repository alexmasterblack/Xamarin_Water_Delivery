﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Slavda
{
    public class Purchase
    {
        public string name { get; set; }
        public int count { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {
        public static SortedDictionary<string, Purchase> purchases = new SortedDictionary<string, Purchase>();
        public FirstPage()
        {
            InitializeComponent();
            list_cart.ItemsSource = purchases.Select((thing) => { return thing.Value; }).ToList();
        }

        private async void Button_Clicked_All(object sender, EventArgs e)
        {
            if (await DisplayAlert("Order", "Are you sure?", "Yes", "No"))
            {
                purchases.Clear();
                list_cart.ItemsSource = "";
                await Navigation.PopAsync();
            }
        }

        private void Button_Clicked_Clear(object sender, EventArgs e)
        {
            purchases.Remove()
        }
    }
}