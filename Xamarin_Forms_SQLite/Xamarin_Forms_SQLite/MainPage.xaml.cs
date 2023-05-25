using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin_Forms_SQLite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void HumeurButton_OnClicked(object sender, EventArgs e)
        {
            await App.HumeurRepository.AjouterHumeurAsync(humeurEntry.Text, bonneHumeurRadio.IsChecked ? 1 : 0, DateTime.Now);
        }
    }
}