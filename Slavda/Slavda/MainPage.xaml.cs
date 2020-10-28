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
        public List<string> images = new List<string> { "Water.png", "Fanta.png", "Coca.png", "Pepsi.png" };
        public MainPage()
        {
            InitializeComponent();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            description.Text = (sender as Picker)?.SelectedItem.ToString();
            all_count.Text = "0"; 
            image.Source = images[picker.SelectedIndex];
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            all_count.Text = (sender as Stepper)?.Value.ToString();
        }

        private async void Button_Clicked_Order(object sender, EventArgs e)
        {
            order.IsEnabled = false;
            await Navigation.PushAsync(new FirstPage());
            order.IsEnabled = true;
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

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (all_count.Text.Length == 0 || all_count.Text.Length > 3)
            {
                stepper.Value = 0;
            } else if (all_count.Text.Length > 0 && all_count.Text.All(char.IsDigit))
            {
                stepper.Value = Convert.ToInt32(all_count.Text);
            } else if (!all_count.Text.All(char.IsDigit))
            {
                all_count.Text = all_count.Text.Remove(all_count.Text.Length - 1);
            }
            if (stepper.Value == 0)
            {
                all_count.Text = "";
            }
        }
    }
}
