using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Slavda
{
    public partial class MainPage : ContentPage
    {
        List<string> images = new List<string> { "Water.png", "Fanta.png", "Coca.png", "Pepsi.png" };
        public MainPage()
        {
            InitializeComponent();
        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            description.Text = (sender as Picker)?.SelectedItem.ToString();
            image.Source = images[picker.SelectedIndex];
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            all_count.Text = (sender as Stepper)?.Value.ToString();
        }

        private async void Button_Clicked_Order(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FirstPage());
        }

        private async void Button_Clicked_Confirm(object sender, EventArgs e)
        {
            if (picker.SelectedIndex == -1 || stepper.Value == 0)
            {
                await DisplayAlert("Error", "Invalid input", "Ok");
            }
            else
            {
                FirstPage.purchases[picker.SelectedItem?.ToString()] = new Purchase()
                {
                    image = images[picker.SelectedIndex].ToString(),
                    name = picker.SelectedItem?.ToString(),
                    count = Convert.ToInt32(all_count.Text)
                };
                await DisplayAlert("Order", "Successful!", "Ok");
            }
        }
    }
}
