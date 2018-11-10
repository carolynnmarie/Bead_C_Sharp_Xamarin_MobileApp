using System;

using BeadCSharpMobileApp.Models;

namespace BeadCSharpMobileApp.ViewModels{

    public class BeadDetailViewModel : BaseViewModel{

        public Bead Bead { get; set; }

        public BeadDetailViewModel(Bead bead = null){
            Title = bead?.Description;
            Bead = bead;
        }
    }
}
