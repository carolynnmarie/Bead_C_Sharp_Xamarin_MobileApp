using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using BeadCSharpMobileApp.Models;
using BeadCSharpMobileApp.Views;

namespace BeadCSharpMobileApp.ViewModels{

    public class BeadsViewModel : BaseViewModel{

        public ObservableCollection<Bead> Beads { get; set; }
        public Command LoadBeadsCommand { get; set; }

        public BeadsViewModel(){
            Title = "Browse";
            Beads = new ObservableCollection<Bead>();
            LoadBeadsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            MessagingCenter.Subscribe<NewBeadPage, Bead>(this, "AddItem", async (obj, bead) =>{
                var newBead = bead as Bead;
                Beads.Add(newBead);
                await DataStore.AddItemAsync(newBead);
            });
        }

        async Task ExecuteLoadItemsCommand(){
            if (IsBusy)
                return;
            IsBusy = true;
            try{
                Beads.Clear();
                var beads = await DataStore.GetItemsAsync(true);
                foreach (var bead in beads){
                    Beads.Add(bead);
                }
            }catch (Exception ex){
                Debug.WriteLine(ex);
            }finally{
                IsBusy = false;
            }
        }
    }
}