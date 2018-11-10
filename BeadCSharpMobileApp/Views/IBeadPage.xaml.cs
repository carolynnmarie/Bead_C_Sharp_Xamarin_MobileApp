using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BeadCSharpMobileApp.Models;
using BeadCSharpMobileApp.Views;
using BeadCSharpMobileApp.ViewModels;

namespace BeadCSharpMobileApp.Views{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BeadsPage : ContentPage{

        BeadsViewModel viewModel;

        public BeadsPage(){
            InitializeComponent();
            BindingContext = viewModel = new BeadsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args){
            var bead = args.SelectedItem as Bead;
            if (bead == null)
                return;
            await Navigation.PushAsync(new BeadDetailPage(new BeadDetailViewModel(bead)));
            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e){
            await Navigation.PushModalAsync(new NavigationPage(new NewBeadPage()));
        }

        protected override void OnAppearing(){
            base.OnAppearing();
            if (viewModel.Beads.Count == 0)
                viewModel.LoadBeadsCommand.Execute(null);
        }
    }
}