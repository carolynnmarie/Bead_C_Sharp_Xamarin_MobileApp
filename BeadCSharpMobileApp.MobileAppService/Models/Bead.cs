using System;

namespace BeadCSharpMobileApp.Models{

    public class Bead{

        public string Id { get; set; }
        public string Material { get; set; }
        public string Shape { get; set; }
        public string Color { get; set; }
        public int Size_MM { get; set; }
        public long Quantity { get; set; }
        public string Description { get; set; }
        public double Price_Point { get; set; }
        public string Brand { get; set; }
    }
}
