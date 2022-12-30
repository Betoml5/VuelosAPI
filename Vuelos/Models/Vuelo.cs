using System;
using System.Collections.Generic;

namespace Vuelos.Models
{
    public partial class Vuelo
    {
        public int IdVuelo { get; set; }
        public DateTime Hora { get; set; }
        public string Destino { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string ClaveVuelo { get; set; } = null!;
    }
}
