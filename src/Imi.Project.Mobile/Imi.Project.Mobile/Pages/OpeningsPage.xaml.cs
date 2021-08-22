using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpeningsPage : ContentPage
    {
        public OpeningsPage()
        {
            InitializeComponent();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = (MainTabbedViewModel)this.BindingContext;
            viewModel?.OpeningFilter?.Execute(null);
        }
    }
}