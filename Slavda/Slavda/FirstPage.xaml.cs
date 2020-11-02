using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Slavda
{
    public class Purchase
    {
        public string image { get; set; }
        public string name { get; set; }
        public int count { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {
        public static ObservableCollection<Purchase> purchases = new ObservableCollection<Purchase>();
        public FirstPage()
        {
            InitializeComponent();
            list_cart.ItemsSource = purchases;
        }

        private async void Button_Clicked_All(object sender, EventArgs e)
        {
            if (purchases.Any())
            {
                if (await DisplayAlert("Order", "Are you sure?", "Yes", "No"))
                {
                    purchases.Clear();
                    await Navigation.PopAsync();
                }
            }
        }

        private void Button_Clicked_Clear(object sender, EventArgs e)
        {
            purchases.Remove(purchases.Where(item => item.name == (sender as Button)?.CommandParameter.ToString()).First());
        }
    }
}