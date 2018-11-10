using System;
using System.Collections.Generic;

namespace BeadCSharpMobileApp.Models{

    public interface IBeadRepository{

        void Add(Bead bead);
        void Update(Bead bead);
        Bead Remove(string key);
        Bead Get(string id);
        IEnumerable<Bead> GetAll();
    }
}
