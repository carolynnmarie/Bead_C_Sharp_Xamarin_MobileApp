using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace BeadCSharpMobileApp.Models{

    public class BeadRepository : IBeadRepository {

        private static ConcurrentDictionary<string, Bead> beads =new ConcurrentDictionary<string, Bead>();

        public BeadRepository(){
            Add(new Bead { Id = Guid.NewGuid().ToString(), Material = "Jasper", Shape= "round", Color = "Black",Size_MM=10,
                Quantity= 7, Description = "10mm round Black Jasper bead, natural stone",Price_Point=0.1,Brand="Bead Gallery" });
            Add(new Bead { Id = Guid.NewGuid().ToString(), Material = "Amethyst", Shape = "round", Color= "Purple",Size_MM=10,
                Quantity=15, Description = "10 mm round Amethyst bead", Price_Point=0.08,Brand = "Bead Gallery" });
            Add(new Bead { Id = Guid.NewGuid().ToString(), Material = "Amethyst",Shape = "round",Color = "Purple",Size_MM = 8,
                Quantity = 15,Description = "10 mm round Amethyst bead",Price_Point = 0.08, Brand = "Bead Gallery"});
        }

        public Bead Get(string id){
            return beads[id];
        }

        public IEnumerable<Bead> GetAll(){
            return beads.Values;
        }

        public void Add(Bead bead){
            bead.Id = Guid.NewGuid().ToString();
            beads[bead.Id] = bead;
        }

        public Bead Find(string id){
            Bead bead;
            beads.TryGetValue(id, out bead);
            return bead;
        }

        public Bead Remove(string id){
            Bead bead;
            beads.TryRemove(id, out bead);
            return bead;
        }

        public void Update(Bead bead){
            beads[bead.Id] = bead;
        }
    }
}
