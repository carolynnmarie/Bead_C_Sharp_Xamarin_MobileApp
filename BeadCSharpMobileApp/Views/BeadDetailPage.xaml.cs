using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BeadCSharpMobileApp.Models;
using BeadCSharpMobileApp.ViewModels;

namespace BeadCSharpMobileApp.Views{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BeadDetailPage : ContentPage{

        BeadDetailViewModel viewModel;

        public BeadDetailPage(BeadDetailViewModel viewModel){
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public BeadDetailPage(){
            InitializeComponent();
            var bead = new Bead{Material = "Jasper",Shape = "round",Color = "Black",Size_MM = 10,Quantity = 7,
                Description = "10mm round Black Jasper bead, natural stone",Price_Point = 0.1,Brand = "Bead Gallery"};
            viewModel = new BeadDetailViewModel(bead);
            BindingContext = viewModel;
        }
    }
}