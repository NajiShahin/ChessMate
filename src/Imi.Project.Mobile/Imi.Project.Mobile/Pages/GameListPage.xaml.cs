using FreshMvvm;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Mocking;
using Imi.Project.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameListPage : ContentPage
    {
        public GameListPage()
        {
            InitializeComponent();

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = (MainTabbedViewModel)this.BindingContext;
            viewModel?.GameFilter?.Execute(e?.NewTextValue);
        }
    }
}