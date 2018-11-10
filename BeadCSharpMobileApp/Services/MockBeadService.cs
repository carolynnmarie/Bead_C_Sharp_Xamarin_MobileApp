using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeadCSharpMobileApp.Models;

namespace BeadCSharpMobileApp.Services{

    public class MockBeadService : IBeadRepo<Bead>{

        List<Bead> beads;

        public MockBeadService(){
            beads = new List<Bead>();
            var mockItems = new List<Bead>{
                new Bead { Id = Guid.NewGuid().ToString(), Material = "Jasper", Shape= "round", Color = "Black",Size_MM=10,
                    Quantity= 7, Description = "10mm round Black Jasper bead, natural stone",Price_Point=0.1,Brand="Bead Gallery"},
                new Bead { Id = Guid.NewGuid().ToString(), Material = "Amethyst", Shape = "round", Color= "Purple",Size_MM=10,
                    Quantity=15, Description = "10 mm round Amethyst bead", Price_Point=0.08,Brand = "Bead Gallery" },
                new Bead { Id = Guid.NewGuid().ToString(), Material = "Amethyst",Shape = "round",Color = "Purple",Size_MM = 8,
                    Quantity = 15,Description = "10 mm round Amethyst bead",Price_Point = 0.08, Brand = "Bead Gallery"},
            };
            foreach (var bead in mockItems){
                beads.Add(bead);
            }
        }

        public async Task<bool> AddItemAsync(Bead bead){
            beads.Add(bead);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Bead bead){
            var oldBead = beads.Where((Bead arg) => arg.Id == bead.Id).FirstOrDefault();
            beads.Remove(oldBead);
            beads.Add(bead);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id){
            var oldBead = beads.Where((Bead arg) => arg.Id == id).FirstOrDefault();
            beads.Remove(oldBead);
            return await Task.FromResult(true);
        }

        public async Task<Bead> GetItemAsync(string id){
            return await Task.FromResult(beads.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Bead>> GetItemsAsync(bool forceRefresh = false){
            return await Task.FromResult(beads);
        }
    }
}