using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BeadCSharpMobileApp.Models;

namespace BeadCSharpMobileApp.Views{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewBeadPage : ContentPage{

        public Bead Bead { get; set; }

        public NewBeadPage(){
            InitializeComponent();
            Bead = new Bead{Material = "Jasper", Shape= "round", Color = "Black",Size_MM=10, Quantity= 7,
                Description = "10mm round Black Jasper bead, natural stone",Price_Point=0.1,Brand="Bead Gallery"};
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e) {
            MessagingCenter.Send(this, "AddBead", Bead);
            await Navigation.PopModalAsync();
        }
    }
}